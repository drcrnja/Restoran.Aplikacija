using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Restoran
{
    public class Rezervacija
    {
        public string ConnectionString { get; } =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Restoran;Integrated Security=True;TrustServerCertificate=True";

        // DOHVATI SVE REZERVACIJE
        public DataTable DohvatiSveRezervacije()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string upit = @"
SELECT r.IDRezervacije, g.ImeGosta, g.PrezimeGosta, r.Datum, r.Vreme, r.BrojOsoba, s.BrojStola
FROM Rezervacija r
JOIN Gost g ON r.IDGosta = g.IDGosta
JOIN Sto s ON r.IDStola = s.IDStola";
                    SqlDataAdapter adapter = new SqlDataAdapter(upit, conn);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška pri dohvatanju rezervacija: " + ex.Message);
                }
            }
            return dt;
        }

        // PRETRAGA PO IMENU
        public DataTable PretraziPoImenu(string imeZaPretragu)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string upit = @"
SELECT r.IDRezervacije, g.ImeGosta, g.PrezimeGosta, r.Datum, r.Vreme, r.BrojOsoba, s.BrojStola
FROM Rezervacija r
JOIN Gost g ON r.IDGosta = g.IDGosta
JOIN Sto s ON r.IDStola = s.IDStola
WHERE g.ImeGosta LIKE @Ime OR g.PrezimeGosta LIKE @Ime";
                    SqlCommand cmd = new SqlCommand(upit, conn);
                    cmd.Parameters.AddWithValue("@Ime", "%" + imeZaPretragu + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška pri pretrazi: " + ex.Message);
                }
            }
            return dt;
        }

        // PRVI SLOBODAN ID REZERVACIJE
        public int NadjiSledeciIDRezervacije()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                // 1. Ako nema ništa – počni od 1
                string proveraPrazno = "SELECT COUNT(*) FROM Rezervacija";
                int broj = Convert.ToInt32(new SqlCommand(proveraPrazno, conn).ExecuteScalar());
                if (broj == 0)
                {
                    MessageBox.Show("Generisan ID rezervacije: 1");
                    return 1;
                }

                // 2. Ako postoji 1 – traži prvu rupu
                string upit = @"
SELECT MIN(r1.IDRezervacije + 1)
FROM Rezervacija r1
WHERE NOT EXISTS (SELECT 1 FROM Rezervacija r2 WHERE r2.IDRezervacije = r1.IDRezervacije + 1)";
                var rezultat = new SqlCommand(upit, conn).ExecuteScalar();

                int id = 1;
                if (rezultat != DBNull.Value)
                    id = Convert.ToInt32(rezultat);

                // 3. Ako je 1 slobodan – vrati 1
                string proveraJedan = "SELECT COUNT(*) FROM Rezervacija WHERE IDRezervacije = 1";
                int jedanPostoji = Convert.ToInt32(new SqlCommand(proveraJedan, conn).ExecuteScalar());
                if (jedanPostoji == 0)
                {
                    MessageBox.Show("Generisan ID rezervacije: 1");
                    return 1;
                }

                MessageBox.Show("Generisan ID rezervacije: " + id);
                return id;
            }
        }
        public List<int> DobaviZauzeteStoloveZaDatum(DateTime datum)
        {
            List<int> zauzeti = new List<int>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string upit = @"
SELECT DISTINCT s.BrojStola
FROM Rezervacija r
JOIN Sto s ON r.IDStola = s.IDStola
WHERE r.Datum = @Datum";
                SqlCommand cmd = new SqlCommand(upit, conn);
                cmd.Parameters.AddWithValue("@Datum", datum.Date);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        zauzeti.Add(Convert.ToInt32(reader["BrojStola"]));
                }
            }
            return zauzeti;
        }

       
        public int NadjiSledeciIDGosta()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string upit = @"
SELECT MIN(g1.IDGosta + 1)
FROM Gost g1
WHERE NOT EXISTS (SELECT 1 FROM Gost g2 WHERE g2.IDGosta = g1.IDGosta + 1)";

                var rezultat = new SqlCommand(upit, conn).ExecuteScalar();
                int id = 1;

                if (rezultat != DBNull.Value)
                    id = Convert.ToInt32(rezultat);

                string maxUpit = "SELECT ISNULL(MAX(IDGosta), 0) + 1 FROM Gost";
                int maxId = Convert.ToInt32(new SqlCommand(maxUpit, conn).ExecuteScalar());

                return Math.Min(id, maxId);
            }
        }

        // PRVI SLOBODAN ID STOLA
        public int NadjiSledeciIDStola()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string upit = @"
SELECT MIN(s1.IDStola + 1)
FROM Sto s1
WHERE NOT EXISTS (SELECT 1 FROM Sto s2 WHERE s2.IDStola = s1.IDStola + 1)";

                var rezultat = new SqlCommand(upit, conn).ExecuteScalar();
                int id = 1;

                if (rezultat != DBNull.Value)
                    id = Convert.ToInt32(rezultat);

                string maxUpit = "SELECT ISNULL(MAX(IDStola), 0) + 1 FROM Sto";
                int maxId = Convert.ToInt32(new SqlCommand(maxUpit, conn).ExecuteScalar());

                return Math.Min(id, maxId);
            }
        }

        // DODAJ GOSTA
        public int NadjiIliDodajGosta(string ime, string prezime)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                int noviID = NadjiSledeciIDGosta();

                string insert = @"INSERT INTO Gost (IDGosta, ImeGosta, PrezimeGosta, Telefon, Email)
                                  VALUES (@ID, @Ime, @Prezime, NULL, NULL)";
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.Parameters.AddWithValue("@ID", noviID);
                cmd.Parameters.AddWithValue("@Ime", ime);
                cmd.Parameters.AddWithValue("@Prezime", prezime);
                cmd.ExecuteNonQuery();
                return noviID;
            }
        }

        // DODAJ STO
        public int NadjiIliDodajSto(string brojStolaInput)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string proveraRest = "SELECT COUNT(*) FROM Restoran WHERE IDRestorana = 1";
                int postojiRest = Convert.ToInt32(new SqlCommand(proveraRest, conn).ExecuteScalar());
                if (postojiRest == 0)
                {
                    string insertRest = @"INSERT INTO Restoran (IDRestorana, NazivRestorana, Adresa, Telefon)
                                          VALUES (1, 'Restoran Kod Maltera', 'Glavna 10', '0601234567')";
                    new SqlCommand(insertRest, conn).ExecuteNonQuery();
                }

                int brojStola = int.Parse(brojStolaInput);
                int idStola = brojStola;

                string provera = "SELECT COUNT(*) FROM Sto WHERE IDStola = @ID";
                SqlCommand cmd = new SqlCommand(provera, conn);
                cmd.Parameters.AddWithValue("@ID", idStola);
                int postoji = (int)cmd.ExecuteScalar();

                if (idStola <= 0 || postoji > 0)
                {
                    idStola = NadjiSledeciIDStola();
                }

                string insert = @"IF NOT EXISTS (SELECT 1 FROM Sto WHERE IDStola = @ID)
                                  INSERT INTO Sto (IDStola, IDRestorana, BrojStola, BrojMesta, Lokacija)
                                  VALUES (@ID, 1, @Broj, 4, 'Sala')";
                SqlCommand cmdInsert = new SqlCommand(insert, conn);
                cmdInsert.Parameters.AddWithValue("@ID", idStola);
                cmdInsert.Parameters.AddWithValue("@Broj", brojStola);
                cmdInsert.ExecuteNonQuery();

                return idStola;
            }
        }

        // UNESI REZERVACIJU
        public void Unesi(DateTime Datum, TimeSpan Vreme, int BrojOsoba, int IDGosta, int IDStola)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                int idRezervacije = NadjiSledeciIDRezervacije();

                string query = @"INSERT INTO Rezervacija (IDRezervacije, Datum, Vreme, BrojOsoba, IDGosta, IDStola)
                                 VALUES (@IDRez, @Datum, @Vreme, @BrojOsoba, @IDGosta, @IDStola)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDRez", idRezervacije);
                cmd.Parameters.AddWithValue("@Datum", Datum.Date);
                cmd.Parameters.AddWithValue("@Vreme", Vreme);
                cmd.Parameters.AddWithValue("@BrojOsoba", BrojOsoba);
                cmd.Parameters.AddWithValue("@IDGosta", IDGosta);
                cmd.Parameters.AddWithValue("@IDStola", IDStola);
                cmd.ExecuteNonQuery();
            }
        }

        // IZMENI REZERVACIJU
        public void Izmeni(int idRezervacije, DateTime datum, TimeSpan vreme, int brojOsoba, int idGosta, int idStola)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = @"UPDATE Rezervacija SET Datum=@Datum, Vreme=@Vreme, BrojOsoba=@BrojOsoba,
                                 IDGosta=@IDGosta, IDStola=@IDStola WHERE IDRezervacije=@IDRezervacije";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDRezervacije", idRezervacije);
                cmd.Parameters.AddWithValue("@Datum", datum.Date);
                cmd.Parameters.AddWithValue("@Vreme", vreme);
                cmd.Parameters.AddWithValue("@BrojOsoba", brojOsoba);
                cmd.Parameters.AddWithValue("@IDGosta", idGosta);
                cmd.Parameters.AddWithValue("@IDStola", idStola);
                cmd.ExecuteNonQuery();
            }
        }

        // IZMENI GOSTA
        public void IzmeniGosta(int idGosta, string novoIme, string novoPrezime)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string upit = @"UPDATE Gost SET ImeGosta = @Ime, PrezimeGosta = @Prezime WHERE IDGosta = @IDGosta";
                SqlCommand cmd = new SqlCommand(upit, conn);
                cmd.Parameters.AddWithValue("@Ime", novoIme);
                cmd.Parameters.AddWithValue("@Prezime", novoPrezime);
                cmd.Parameters.AddWithValue("@IDGosta", idGosta);
                int rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                    MessageBox.Show("Greška: Gost sa ID=" + idGosta + " nije pronađen u bazi!");
            }
        }

        // OBRIŠI REZERVACIJU I GOSTA AKO JE POSLEDNJA
        public void ObrisiRezervacijuIGostaAkoJePoslednji(int idRezervacije)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string upitGost = "SELECT IDGosta FROM Rezervacija WHERE IDRezervacije = @ID";
                SqlCommand cmdGost = new SqlCommand(upitGost, conn);
                cmdGost.Parameters.AddWithValue("@ID", idRezervacije);
                var rezultat = cmdGost.ExecuteScalar();
                if (rezultat == null)
                {
                    MessageBox.Show("Rezervacija nije pronađena.");
                    return;
                }

                int idGosta = Convert.ToInt32(rezultat);

                string obrisiRez = "DELETE FROM Rezervacija WHERE IDRezervacije = @ID";
                SqlCommand cmdObrisi = new SqlCommand(obrisiRez, conn);
                cmdObrisi.Parameters.AddWithValue("@ID", idRezervacije);
                cmdObrisi.ExecuteNonQuery();

                string provera = "SELECT COUNT(*) FROM Rezervacija WHERE IDGosta = @IDGosta";
                SqlCommand cmdProvera = new SqlCommand(provera, conn);
                cmdProvera.Parameters.AddWithValue("@IDGosta", idGosta);
                int brojRezervacija = Convert.ToInt32(cmdProvera.ExecuteScalar());

                if (brojRezervacija == 0)
                {
                    string obrisiGosta = "DELETE FROM Gost WHERE IDGosta = @IDGosta";
                    SqlCommand cmdObrisiGosta = new SqlCommand(obrisiGosta, conn);
                    cmdObrisiGosta.Parameters.AddWithValue("@IDGosta", idGosta);
                    cmdObrisiGosta.ExecuteNonQuery();
                }
            }
        }
    }
}