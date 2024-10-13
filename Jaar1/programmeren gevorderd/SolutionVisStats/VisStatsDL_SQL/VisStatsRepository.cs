using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisStatsBL.Interfaces;
using VisStatsBL.Model;

namespace VisStatsDL_SQL
{
    public class VisStatsRepository : IVisStatsRepository
    {
        private string connectionString;

        public VisStatsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool HeeftVissoort(Vissoort vis)
        {
            string SQL = "SELECT count(*) FROM Soort WHERE naam=@naam";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@naam", vis.Naam);
                    int n = (int)cmd.ExecuteScalar();
                    if (n > 0) return true; else return false;
                }
                catch (Exception ex)
                {

                    throw new Exception("HeeftVisSoort", ex);
                }
            }
        }

        public bool HeeftHaven(Haven haven)
        {
            string SQL = "SELECT count(*) FROM haven WHERE naam=@naam";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@naam", haven.Naam);
                    int n = (int)cmd.ExecuteScalar();
                    if (n > 0) return true; else return false;
                }
                catch (Exception ex)
                {

                    throw new Exception("HeeftHaven", ex);
                }
            }
        }

        public bool isOpgeladen(string fileName)
        {
            string SQL = "SELECT count(*) FROM upload WHERE filename=@filename";
            List<Vissoort> soorten = new();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@filename", fileName.Substring(fileName.LastIndexOf("\\")+1));
                    int n = (int)cmd.ExecuteScalar();
                    if (n > 0) return true; else return false;
                }
                catch (Exception ex)
                {

                    throw new Exception("isOpgeladen", ex);
                }
            }
        }

        public List<Haven> LeesHavens()
        {
            string SQL = "SELECT * FROM haven";
            List<Haven> havens = new();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = SQL;
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        havens.Add(new Haven((int)reader["id"], (string)reader["naam"]));
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception("LeesHavens", ex);
                }
            }
            return havens;
        }

        public List<Vissoort> LeesVissoorten()
        {
            string SQL = "SELECT * FROM soort";
            List<Vissoort> soorten = new();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = SQL;
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        soorten.Add(new Vissoort((string)reader["naam"], (int)reader["id"]));
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception("LeesVissoorten", ex);
                }
            }
            return soorten;
        }

        public void SchrijfSoort(Vissoort vis)
        {
            string SQL = "INSERT INTO Soort(naam) VALUES(@naam)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = SQL;
                    cmd.Parameters.Add(new SqlParameter("@naam", SqlDbType.NVarChar));
                    cmd.Parameters["@naam"].Value = vis.Naam;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw new Exception("SchrijfSoorten", ex);
                }
            }
        }

        public void SchrijfHaven(Haven haven)
        {
            int aantalHavens = LeesHavens().Count;
            string SQL = "INSERT INTO Haven(id, naam) VALUES(@id, @naam)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = SQL;
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    cmd.Parameters["@id"].Value = aantalHavens +1;
                    cmd.Parameters.Add(new SqlParameter("@naam", SqlDbType.NVarChar));
                    
                    cmd.Parameters["@naam"].Value = haven.Naam;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw new Exception("SchrijfHaven", ex);
                }
            }
        }

        public void SchrijfStatistieken(List<VisStatsDataRecord> data, string fileName)
        {
            string SQLdata = " INSERT INTO VisStats(jaar, maand, haven_id, soort_id, gewicht, waarde) VALUES (@jaar, @maand, @haven_id, @soort, @gewicht, @waarde)";
            string SQLupload = "INSERT INTO upload(filename, datum, pad) VALUEs (@filename, @datum, @pad)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = SQLdata;
                    cmd.Transaction = conn.BeginTransaction();
                    //Schrijf in visstats
                    cmd.Parameters.Add(new SqlParameter("@jaar", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@maand", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@haven_id", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@soort", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@gewicht", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlParameter("@waarde", SqlDbType.Float));



                    foreach (VisStatsDataRecord dataRecord in data)
                    {
                        cmd.Parameters["@jaar"].Value = dataRecord.Jaar;
                        cmd.Parameters["@maand"].Value = dataRecord.Maand;
                        cmd.Parameters["@haven_id"].Value = dataRecord.Haven.ID;
                        cmd.Parameters["@soort"].Value = dataRecord.Vissoort.Id;
                        cmd.Parameters["@gewicht"].Value = dataRecord.Gewicht;
                        cmd.Parameters["@waarde"].Value = dataRecord.Waarde;
                        cmd.ExecuteNonQuery();
                    }

                    //schrijf in upload
                    cmd.CommandText = SQLupload;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@filename", fileName.Substring(fileName.LastIndexOf("\\") + 1));
                    cmd.Parameters.AddWithValue("@pad", fileName.Substring(0, fileName.LastIndexOf("\\") + 1));

                    cmd.Parameters.AddWithValue("@datum", DateTime.Now);
                    cmd.ExecuteNonQuery();

                    cmd.Transaction.Commit();
                    
                    
                }
                catch (Exception ex)
                {
                    cmd.Transaction.Rollback();
                    throw new Exception("SchrijfStatistieken", ex);
                }
            }
        }

        public List<int> LeesJaartallen()
        {
            List<int> jaren = new List<int>();
            string SQL = "SELECT jaar FROM visStats";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = SQL;
                    IDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        if (!jaren.Contains((int)reader["jaar"]))
                        {
                            jaren.Add((int)reader["jaar"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("LeesHavens", ex);
                }
            }
            return jaren;   
        }

        public List<Vissoort> GeefVissoorten()
        {
            string SQL = "SELECT * FROM soort";
            List<Vissoort> soorten = new();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = SQL;
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        soorten.Add(new Vissoort((string)reader["naam"], (int)reader["id"]));
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception("LeesVissoorten fjdklsmqjfdklmsqf", ex);
                }
            }
            return soorten;
        }

        public List<JaarVangst> LeesStatistieken(int jaar, Haven haven, List<Vissoort> vissoorten, Eenheid eenheid)
        {
            string kolom = "";
            switch (eenheid)
            {
                case Eenheid.kg: kolom = "gewicht"; break;
                case Eenheid.euro: kolom = "waarde"; break;
            }

            string paramSoorten = "";
            List<SqlParameter> parameters = new List<SqlParameter>();

            for (int i = 0; i < vissoorten.Count; i++)
            {
                string paramName = $"@ps{i}";
                paramSoorten += paramName + ",";
                parameters.Add(new SqlParameter(paramName, vissoorten[i])); // Assuming vissoorten is a list of values for IN clause
            }

            // Remove the trailing comma
            paramSoorten = paramSoorten.TrimEnd(',');

            string SQL = $"SELECT soort_id, t2.naam as soortnaam, jaar, " +
             $"SUM({kolom}) as totaal, MIN({kolom}) as minimum, MAX({kolom}) as maximum, AVG({kolom}) as gemiddelde " +
             $"FROM VisStats t1 " +
             $"LEFT JOIN Soort t2 ON t1.soort_id = t2.id " +
             $"WHERE jaar = 2016 AND soort_id IN ({paramSoorten}) AND haven_id = 1 " +
             $"GROUP BY soort_id, t2.naam, jaar";


            List<JaarVangst> vangst = new();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@haven_id", haven.ID);
                    cmd.Parameters.AddWithValue("@jaar", jaar);
                    for (int i = 0; i < vissoorten.Count; i++)
                    {
                        cmd.Parameters.AddWithValue($"@ps{i}", vissoorten[i].Id);
                    }
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        vangst.Add(new JaarVangst((string)reader["soortnaam"],
                            (double)reader["totaal"], (double)reader["minimum"],
                            (double)reader["maximum"], (double)reader["gemiddelde"]));
                    }
                    return vangst;
                }
                catch (Exception ex)
                {

                    throw new Exception("GeefJaarVangst", ex);
                }
            }
        }


        public MaandVangst LeesStatistiekenMaand(int jaar, List<Haven> havens, Eenheid eenheid, int maand, Vissoort visSoort)
        {
            string kolom = "";
            switch (eenheid)
            {
                case Eenheid.kg: kolom = "gewicht"; break;
                case Eenheid.euro: kolom = "waarde"; break;
            }

            string paramSoorten = "";
            List<SqlParameter> parameters = new List<SqlParameter>();

            for (int i = 0; i < havens.Count; i++)
            {
                string paramName = $"@ps{i}";
                paramSoorten += paramName + ",";
                parameters.Add(new SqlParameter(paramName, havens[i].ID));
            }

            paramSoorten = paramSoorten.Substring(0,paramSoorten.Length-1);

            // Verwijderd de laatse comma
            paramSoorten = paramSoorten.TrimEnd(',');
           
            string SQL = $"SELECT jaar, maand, " +
             $"SUM({kolom}) as totaal " +
             $"FROM VisStats t1 " +
             $"LEFT JOIN Soort t2 ON t1.soort_id = t2.id " +
             $"WHERE jaar = @jaar AND haven_id IN ({paramSoorten}) AND soort_id = @vissoort AND maand = @maand " +
             $"GROUP BY jaar, maand ";

            double totaalVangst = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = SQL;

                    cmd.Parameters.AddWithValue("@vissoort", visSoort.Id);
                    cmd.Parameters.AddWithValue("@jaar", jaar);
                    cmd.Parameters.AddWithValue("@maand", maand);

                    for (int i = 0; i < havens.Count; i++)
                    {
                        cmd.Parameters.AddWithValue($"@ps{i}", havens[i].ID);
                    }

                    IDataReader reader = cmd.ExecuteReader();

                    int jaarReader = 0;
                    int maandReader = 0;
                    
                    if (reader.Read())
                    {
                        totaalVangst += Convert.ToDouble(reader[2]);
                        jaarReader = Convert.ToInt32(reader[0]);
                        maandReader = Convert.ToInt32(reader[1]);

                        while (reader.Read())
                        {
                            totaalVangst += Convert.ToDouble(reader[2]);
                        }
                    }
                    string lijstHavens = string.Join(", ", havens);
                    return new MaandVangst(totaalVangst, jaarReader, maandReader, lijstHavens);
                }
                catch (Exception ex)
                {

                    throw new Exception("GeefMaandVangst", ex);
                }
            }
        }
    }
}
