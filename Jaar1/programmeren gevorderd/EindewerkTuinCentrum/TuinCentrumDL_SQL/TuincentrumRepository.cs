using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TuinCentrumBL.Interfaces;
using TuinCentrumBL.Model;

namespace TuinCentrumDL_SQL
{
    public class TuincentrumRepository : ITuincentrumRepository
    {
        private string connectionString;

        public TuincentrumRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Product> GeefProducten()
        {
            string SQL = "SELECT * FROM Product";
            List<Product> producten = new();
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
                        producten.Add(new Product((int)reader["ID"], (string)reader["NederlandseNaam"], (string)reader["WetenschapelijkeNaam"], Convert.ToDouble(reader["Prijs"]), (string)reader["Beschrijving"]));
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception("LeesProducten", ex);
                }
            }
            return producten;
        }

        public Product GeefProductViaID(int id)
        {
            string SQL = "SELECT * FROM Product WHERE ID=@ID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {

                try
                {
                    Product product = new Product();
                    conn.Open();
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@ID", id);

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        product = new Product((int)reader["ID"], (string)reader["NederlandseNaam"], (string)reader["WetenschapelijkeNaam"], Convert.ToDouble(reader["Prijs"]), (string)reader["Beschrijving"]);
                    }

                    return product;
                }
                catch (Exception ex)
                {

                    throw new Exception("LeesKlantViaID", ex);
                }
            }
        }

        public bool HeeftKlant(string klant)
        {
            string SQL = "SELECT count(*) FROM Klant WHERE naam=@naam";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@naam", klant);
                    int n = (int)cmd.ExecuteScalar();
                    if (n > 0) return true; else return false;
                }
                catch (Exception ex)
                {

                    throw new Exception("HeeftKlant", ex);
                }
            }
        }

        public bool HeeftKlantID(int id)
        {
            string SQL = "SELECT count(*) FROM Klant WHERE ID=@id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@ID", id);
                    int n = (int)cmd.ExecuteScalar();
                    if (n > 0) return true; else return false;
                }
                catch (Exception ex)
                {

                    throw new Exception("HeeftKlant", ex);
                }
            }
        }

        public bool HeeftProduct(Product product)
        {
            string SQL = "SELECT count(*) FROM Product WHERE NederlandseNaam=@NEDnaam";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@NEDnaam", product.NederlandseNaam);
                    int n = (int)cmd.ExecuteScalar();
                    if (n > 0) return true; else return false;
                }
                catch (Exception ex)
                {

                    throw new Exception("HeeftProduct", ex);
                }
            }
        }

        public Klant LeesKlantViaID(int id)
        {
            string SQL = "SELECT * FROM Klant WHERE ID=@id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {

                try
                {
                    Klant klant = new Klant();
                    conn.Open();
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@ID", id);
                    int n = (int)cmd.ExecuteScalar();

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        klant = new Klant((int)reader["ID"], (string)reader["Naam"], (string)reader["Adres"]);
                    }

                    return klant;
                }
                catch (Exception ex)
                {

                    throw new Exception("LeesKlantViaID", ex);
                }
            }
        }

        public Klant LeesKlantViaNaam(string naam)
        {
            string SQL = "SELECT * FROM Klant WHERE naam=@naam";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {

                try
                {
                    Klant klant = new Klant();
                    conn.Open();
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@naam", naam);
                    int n = (int)cmd.ExecuteScalar();

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        klant = new Klant((int)reader["ID"], (string)reader["Naam"], (string)reader["Adres"]);
                    }

                    return klant;
                }
                catch (Exception ex)
                {

                    throw new Exception("LeesKlantViaNaam", ex);
                }
            }
        }
        public void SchrijfKlant(Klant klant)
        {
            string SQL = "INSERT INTO Klant(id, naam, adres) VALUES(@id, @naam, @adres)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = SQL;
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    cmd.Parameters["@id"].Value = klant.ID;
                    cmd.Parameters.Add(new SqlParameter("@naam", SqlDbType.NVarChar));
                    cmd.Parameters["@naam"].Value = klant.Naam;
                    cmd.Parameters.Add(new SqlParameter("@adres", SqlDbType.NVarChar));
                    cmd.Parameters["@adres"].Value = klant.Adres;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw new Exception("Schrijfklanten", ex);
                }
            }
        }
        public void schrijfOfferte(Offerte offerte)
        {
            string sql1 = "INSERT INTO Offerte(ID, Datum, klantnr, Afhaal, Aanleg, Aantal, Prijs) VALUES(@ID, @Datum, @klantnr, @Afhaal, @Aanleg, @Aantal, @Prijs)";
            string sql2 = "INSERT INTO OfferteProducten(OfferteID, ProductID, Aantal) VALUES(@OfferteID, @ProductID, @Aantal)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand command1 = new SqlCommand(sql1, conn, trans))
                            {
                                command1.Parameters.AddWithValue("@ID", offerte.ID);
                                command1.Parameters.AddWithValue("@Datum", offerte.Datum);
                                command1.Parameters.AddWithValue("@klantnr", offerte.klantnummer);
                                command1.Parameters.AddWithValue("@Afhaal", offerte.afhaal);
                                command1.Parameters.AddWithValue("@Aanleg", offerte.aanleg);
                                command1.Parameters.AddWithValue("@Aantal", offerte.Aantal);
                                command1.Parameters.AddWithValue("@Prijs", offerte.Prijs);

                                command1.ExecuteNonQuery();
                            }

                            using (SqlCommand command2 = new SqlCommand(sql2, conn, trans))
                            {
                                foreach (int product in offerte.Producten.Keys)
                                {
                                    command2.Parameters.Clear();
                                    command2.Parameters.AddWithValue("@OfferteID", offerte.ID);
                                    command2.Parameters.AddWithValue("@ProductID", product);
                                    command2.Parameters.AddWithValue("@Aantal", offerte.Producten[product]);

                                    command2.ExecuteNonQuery();
                                }
                            }

                            trans.Commit(); // Commit de transactie als alles goed gaat
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback(); // Rollback de transactie bij een fout
                            Console.WriteLine("Fout bij het uitvoeren van transactie: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fout bij het openen van de verbinding: " + ex.Message);
            }
        }
        public Dictionary<int, int> GeefInfoOfferte(int id)
        {
            string SQL = "SELECT * FROM OfferteProducten WHERE OfferteID=@ID";
            Dictionary<int, int> Producten = new Dictionary<int, int>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {

                try
                {
                    Product product = new Product();
                    conn.Open();
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@ID", id);
                    int n = (int)cmd.ExecuteScalar();

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Producten.Add((int)reader["ProductID"], (int)reader["Aantal"]);
                    }

                    return Producten;
                }
                catch (Exception ex)
                {

                    throw new Exception("LeesKlantViaID", ex);
                }
            }
        }
        public void SchrijfProduct(Product product)
        {
            string SQL = "INSERT INTO Product(id, NederlandseNaam, WetenschapelijkeNaam, Prijs, Beschrijving) VALUES(@id, @NederlandseNaam, @WetenschapelijkeNaam, @Prijs, @Beschrijving)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = SQL;
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    cmd.Parameters["@id"].Value = product.ID;
                    cmd.Parameters.Add(new SqlParameter("@NederlandseNaam", SqlDbType.NVarChar));
                    cmd.Parameters["@NederlandseNaam"].Value = product.NederlandseNaam;
                    cmd.Parameters.Add(new SqlParameter("@WetenschapelijkeNaam", SqlDbType.NVarChar));
                    cmd.Parameters["@WetenschapelijkeNaam"].Value = product.WetenschappelijkeNaam;
                    cmd.Parameters.Add(new SqlParameter("@Prijs", SqlDbType.Decimal));
                    cmd.Parameters["@Prijs"].Value = product.Prijs;
                    cmd.Parameters.Add(new SqlParameter("@Beschrijving", SqlDbType.NVarChar));
                    cmd.Parameters["@Beschrijving"].Value = product.Beschrijving;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw new Exception("SchrijfProducten", ex);
                }
            }
        }
        public Offerte GeefOfferteViaID(int id)
        {
            string SQL = "SELECT * FROM Oferte WHERE ID=@ID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {

                try
                {
                    Offerte offerte = new Offerte();
                    conn.Open();
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@ID", id);
                    int n = (int)cmd.ExecuteScalar();

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        offerte = new Offerte((int)reader["ID"], (DateTime)reader["Datum"], (int)reader["klantnr"], (bool)reader["Afhaal"], (bool)reader["Aanleg"], (int)reader["Aantal"], Convert.ToDouble(reader["Prijs"]));
                    }

                    return offerte;
                }
                catch (Exception ex)
                {

                    throw new Exception("LeesKlantViaID", ex);
                }
            }
        }
        public List<Offerte> GeefOffertes()
        {
            string SQL = "SELECT * FROM Offerte";
            List<Offerte> offertes = new();
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
                        offertes.Add(new Offerte((int)reader["ID"], (DateTime)reader["Datum"], (int)reader["klantnr"], (bool)reader["Afhaal"], (bool)reader["Aanleg"], (int)reader["Aantal"], Convert.ToDouble(reader["Prijs"])));
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception("LeesProducten", ex);
                }
            }
            return offertes;
        }
        public void UpdateOfferteInDatabase(Offerte offerte)
        {
            string sql = "UPDATE Offerte SET Prijs = @Prijs WHERE ID = @ID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Prijs", offerte.Prijs);
                    cmd.Parameters.AddWithValue("@ID", offerte.ID);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<Offerte> GeefOfferteViaKlantID(int id)
        {
            string SQL = "SELECT * FROM Offerte WHERE klantnr=@ID";
            List<Offerte> offertes = new List<Offerte>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@ID", id);

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int offerteID = (int)reader["ID"];
                        DateTime datum = (DateTime)reader["Datum"];
                        int klantnr = (int)reader["klantnr"];
                        bool afhaal = (bool)reader["Afhaal"];
                        bool aanleg = (bool)reader["Aanleg"];
                        int aantal = (int)reader["Aantal"];
                        double prijs = Convert.ToDouble(reader["Prijs"]);

                        offertes.Add(new Offerte(offerteID, datum, klantnr, afhaal, aanleg, aantal, prijs));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("LeesProducten", ex);
                }
            }
            return offertes;
        }
        public List<Offerte> GeefOffertesViaID(int id)
        {
            string SQL = "SELECT * FROM Offerte WHERE ID=@ID";
            List<Offerte> offertes = new List<Offerte>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@ID", id);

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int offerteID = (int)reader["ID"];
                        DateTime datum = (DateTime)reader["Datum"];
                        int klantnr = (int)reader["klantnr"];
                        bool afhaal = (bool)reader["Afhaal"];
                        bool aanleg = (bool)reader["Aanleg"];
                        int aantal = (int)reader["Aantal"];
                        double prijs = Convert.ToDouble(reader["Prijs"]);

                        offertes.Add(new Offerte(offerteID, datum, klantnr, afhaal, aanleg, aantal, prijs));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("LeesProducten", ex);
                }
            }
            return offertes;
        }
        public List<Offerte> GeefOffertesViaDatum(DateTime datumparam)
        {
            string SQL = "SELECT * FROM Offerte WHERE Datum=@Datum";
            List<Offerte> offertes = new List<Offerte>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@Datum", datumparam);

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int offerteID = (int)reader["ID"];
                        DateTime datum = (DateTime)reader["Datum"];
                        int klantnr = (int)reader["klantnr"];
                        bool afhaal = (bool)reader["Afhaal"];
                        bool aanleg = (bool)reader["Aanleg"];
                        int aantal = (int)reader["Aantal"];
                        double prijs = Convert.ToDouble(reader["Prijs"]);

                        offertes.Add(new Offerte(offerteID, datum, klantnr, afhaal, aanleg, aantal, prijs));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("LeesProducten", ex);
                }
            }
            return offertes;
        }
        public Dictionary<Product, int> GeefProductenViaID(int iD)
        {
            string SQL = "SELECT p.ID, p.NederlandseNaam, p.WetenschapelijkeNaam, p.Beschrijving, p.Prijs, op.Aantal\r\nFROM OfferteProducten op\r\nINNER JOIN Product p on p.ID = op.ProductID\r\nWHERE op.OfferteID = @ID";
            Dictionary<Product, int> winkelkar = new Dictionary<Product, int>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    Product product = new Product();
                    int aantal = 0;
                    conn.Open();
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@ID", iD);

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        product = new Product((int)reader["ID"], (string)reader["NederlandseNaam"], (string)reader["WetenschapelijkeNaam"], Convert.ToDouble(reader["Prijs"]), (string)reader["Beschrijving"]);
                        aantal = (int)reader["Aantal"];
                        winkelkar.Add(product, aantal);
                    }

                }
                catch (Exception ex)
                {

                    throw new Exception("LeesProducten", ex);
                }
            }
            return winkelkar;
        }
        public void UpdateOfferte(Offerte offerte, Dictionary<int, int> NieuweProducten, Dictionary<int, int> VerwijderdProducten)
        {
            string sql1 = "UPDATE Offerte SET Datum = @Datum, klantnr = @klantnr, Afhaal = @Afhaal, Aanleg = @Aanleg, Aantal = @Aantal, Prijs = @Prijs WHERE ID = @ID;";
            string sql2 = "INSERT INTO OfferteProducten(OfferteID, ProductID, Aantal) VALUES(@OfferteID, @ProductID, @Aantal)";
            string sql3 = "UPDATE OfferteProducten SET Aantal = @Aantal WHERE OfferteID = @OfferteID AND ProductID = @ProductID";
            string sql4 = "DELETE FROM OfferteProducten WHERE OfferteID = @OfferteID AND ProductID = @ProductID";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand command1 = new SqlCommand(sql1, conn, trans))
                            {
                                command1.Parameters.AddWithValue("@ID", offerte.ID);
                                command1.Parameters.AddWithValue("@Datum", offerte.Datum);
                                command1.Parameters.AddWithValue("@klantnr", offerte.klantnummer);
                                command1.Parameters.AddWithValue("@Afhaal", offerte.afhaal);
                                command1.Parameters.AddWithValue("@Aanleg", offerte.aanleg);
                                command1.Parameters.AddWithValue("@Aantal", offerte.Aantal);
                                command1.Parameters.AddWithValue("@Prijs", offerte.Prijs);

                                command1.ExecuteNonQuery();
                            }

                            using (SqlCommand command2 = new SqlCommand(sql2, conn, trans))
                            {
                                foreach (int product in NieuweProducten.Keys)
                                {
                                    command2.Parameters.Clear();
                                    command2.Parameters.AddWithValue("@OfferteID", offerte.ID);
                                    command2.Parameters.AddWithValue("@ProductID", product);
                                    command2.Parameters.AddWithValue("@Aantal", NieuweProducten[product]);

                                    command2.ExecuteNonQuery();
                                }
                            }

                            using (SqlCommand command3 = new SqlCommand(sql3, conn, trans))
                            {
                                foreach (int product in offerte.Producten.Keys)
                                {
                                    command3.Parameters.Clear();
                                    command3.Parameters.AddWithValue("@OfferteID", offerte.ID);
                                    command3.Parameters.AddWithValue("@ProductID", product);
                                    command3.Parameters.AddWithValue("@Aantal", offerte.Producten[product]);

                                    command3.ExecuteNonQuery();
                                }
                            }

                            using (SqlCommand command4 = new SqlCommand(sql4, conn, trans))
                            {
                                foreach (int product in VerwijderdProducten.Keys)
                                {
                                    command4.Parameters.Clear();
                                    command4.Parameters.AddWithValue("@OfferteID", offerte.ID);
                                    command4.Parameters.AddWithValue("@ProductID", product);

                                    command4.ExecuteNonQuery();
                                }
                            }

                            trans.Commit(); // Commit de transactie als alles goed gaat
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback(); // Rollback de transactie bij een fout
                            Console.WriteLine("Fout bij het uitvoeren van transactie: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fout bij het openen van de verbinding: " + ex.Message);
            }
        }
        public List<Klant> GeefKlanten()
        {
            List<Klant> klanten = new List<Klant>();
            string SQL = "SELECT * FROM Klant";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {

                try
                {
                    Klant klant = new Klant();
                    conn.Open();
                    cmd.CommandText = SQL;
                    int n = (int)cmd.ExecuteScalar();

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        klant = new Klant((int)reader["ID"], (string)reader["Naam"], (string)reader["Adres"]);
                        klanten.Add(klant);
                    }

                    return klanten;
                }
                catch (Exception ex)
                {

                    throw new Exception("LeesKlantViaNaam", ex);
                }
            }
        }
    }
}
