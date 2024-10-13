using AdresbeheerDomain.Interfaces;
using AdresbeheerDomain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerADO
{
    public class GemeenteRepositoryADO : IGemeenteRepository
    {
        private string connectionString;

        public GemeenteRepositoryADO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Gemeente GeefGemeente(int id)
        {
            string sql = "SELECT * FROM gemeente WHERE niscode=@niscode";
            using(SqlConnection conn = new SqlConnection(connectionString))
            using(SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@niscode", id);
                IDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                Gemeente g = new Gemeente((int)dataReader["niscode"], (string)dataReader["gemeentenaam"]);
                dataReader.Close();
                return g;
            }
        }
    }
}
