﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisStatsBL.Exceptions;

namespace VisStatsBL.Model
{
    public class VisStatsDataRecord
    {
        private int _jaar;
        public int Jaar
        {
            get { return _jaar; }
            set { if (value < 2000 || value > 2100) throw new DomeinException("jaar niet correct"); _jaar = value; }
        }
        private int _maand;
        public int Maand
        {
            get { return _maand; }
            set { if (value > 12 || value < 1) throw new DomeinException("maand niet correct"); _maand = value; }
        }
        private double _gewicht;
        public double Gewicht
        {
            get { return _gewicht; }
            set { if (value < 0) throw new DomeinException("gewicht niet correct"); _gewicht = value; }
        }
        private double _waarde;
        public double Waarde
        {
            get { return _waarde; }
            set { if (value < 0) throw new DomeinException("waarde niet correct"); _waarde = value; }
        }
        private Haven _haven;
        public Haven Haven
        {
            get { return _haven; }
            set { if (value == null) throw new DomeinException("haven niet correct"); _haven = value; }
        }
        private Vissoort _vissoort;
        public Vissoort Vissoort
        {
            get { return _vissoort; }
            set { if (value == null) throw new DomeinException("vissoort niet correct"); _vissoort = value; }
        }

        public VisStatsDataRecord(Vissoort vissoort, Haven haven, int jaar, int maand, double gewicht, double waarde)
        {
            Jaar = jaar;
            Maand = maand;
            Gewicht = gewicht;
            Waarde = waarde;
            Haven = haven;
            Vissoort = vissoort;
        }
    }
}
