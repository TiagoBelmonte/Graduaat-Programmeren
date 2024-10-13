using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisStatsBL.Exceptions;
using VisStatsBL.Interfaces;
using VisStatsBL.Model;

namespace VisStatsBL.Managers
{
    public class VisStatsManager
    {
      private IFileProcessor fileProcessor;
        private IVisStatsRepository visStatsRepository;

        public VisStatsManager(IFileProcessor fileProcessor, IVisStatsRepository visStatsRepository)
        {
            this.fileProcessor = fileProcessor;
            this.visStatsRepository = visStatsRepository;
        }

        public void UploadVissoorten(string fileName)
        {
            List<string> soorten = fileProcessor.LeesSoorten(fileName);
            List<Vissoort> vissoorten = MaakVissoorten(soorten);
            foreach (Vissoort vis in vissoorten)
            {
                if (!visStatsRepository.HeeftVissoort(vis))
                {
                    visStatsRepository.SchrijfSoort(vis);
                }
            }
        }

        public void UploadHaven(string fileName)
        {
            List<string> havens = fileProcessor.LeesHavens(fileName);
            List<Haven> havens2 = MaakHavens(havens);
            foreach (Haven haven in havens2)
            {
                if (!visStatsRepository.HeeftHaven(haven))
                {
                    visStatsRepository.SchrijfHaven(haven);
                }
            }
        }

        private List<Vissoort> MaakVissoorten(List<string> soorten)
        {
            Dictionary<string, Vissoort> visSoorten = new();
            foreach (string s in soorten)
            {
                if (!visSoorten.ContainsKey(s))
                { 
                    try
                    { 
                        visSoorten.Add(s, new Vissoort(s));
                    }catch (DomeinException) { }
                }
            }
            return visSoorten.Values.ToList();
        }

        private List<Haven> MaakHavens(List<string> havens)
        {
            Dictionary<string, Haven> havens2 = new();
            foreach (string s in havens)
            {
                if (!havens2.ContainsKey(s))
                {
                    try
                    {
                        havens2.Add(s, new Haven(s));
                    }
                    catch (DomeinException) { }
                }
            }
            return havens2.Values.ToList();
        }

        public void UploadStatistieken(string fileName)
        {
            try
            {
                if (!visStatsRepository.isOpgeladen(fileName))
                {
                    List<Vissoort> soorten = visStatsRepository.LeesVissoorten();

                    List<Haven> havens = visStatsRepository.LeesHavens();
                    List<VisStatsDataRecord> data = fileProcessor.LeesStatistieken(fileName, soorten, havens);
                    visStatsRepository.SchrijfStatistieken(data, fileName);
                }
            }
            catch(Exception ex) { throw new ManagerException("UploadStatistieken", ex); }

        }

        public List<Haven> GeefHavens()
        {
            try {
            return visStatsRepository.LeesHavens().ToList();
            }
             catch(Exception ex) { throw new ManagerException("GeefHavens", ex); }
        }

        public List<int> geefJaartallen()
        {
            try
            {
                return visStatsRepository.LeesJaartallen(); ;
            }
            catch (Exception ex) { throw new ManagerException("GeefJaartallen", ex); }
        }

        public List<Vissoort> GeefVissoorten()
        {
            try
            {
                return visStatsRepository.GeefVissoorten(); ;
            }
            catch (Exception ex) { throw new ManagerException("GeefVissoorten", ex); }
        }

        public List<JaarVangst> GeefVangst(int jaar, Haven haven, List<Vissoort> vissoorten, Eenheid eenheid)
        {
            try
            { 
                return visStatsRepository.LeesStatistieken(jaar, haven, vissoorten, eenheid);
            }
            catch(Exception ex) { throw new ManagerException("GeefVangst", ex); }
        }

        public MaandVangst GeefVangstMaand(int jaar, List<Haven> havens, Eenheid eenheid, int maand, Vissoort visSoort)
        {
            try
            {
                return visStatsRepository.LeesStatistiekenMaand(jaar ,havens, eenheid, maand, visSoort);
            }
            catch (Exception ex) { throw new ManagerException("GeefVangstMaand", ex); }
        }
    }
}
