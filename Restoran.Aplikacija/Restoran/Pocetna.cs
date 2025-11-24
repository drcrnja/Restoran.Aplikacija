using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restoran
{
    public partial class Pocetna : Form
    {
        private readonly Rezervacija rezervacijaRepo = new Rezervacija();//dodaje nocu istancu
        public Pocetna()
        {
            InitializeComponent();

        }

        private void Pocetna_Load(object sender, EventArgs e){
            //POZIVA FUNKCIJU ZA REZERVACIJE
            PrikaziSveRezervacije();
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;//za proveru statusa stolova
            BrojStolaBox.DrawMode = DrawMode.OwnerDrawFixed;//omogucava crtanje stavku na comboboxu
            BrojStolaBox.DrawItem += BrojStolaBox_DrawItem;//povezuje crnjanje boxa
            //KOMANDA ZA OPADAJUCI MENI
            for (int i = 1; i <= 20; i++)
                BrojStolaBox.Items.Add(i);

           
            if (BrojStolaBox.Items.Count > 0)
                BrojStolaBox.SelectedIndex = 0;//postavlja indeks na nula

           
            if (this.Controls.Find("DataGridView", true).Length > 0)//proverava dali datagrid postoji i povezuje je
                DataGridView.SelectionChanged += new EventHandler(DataGridView_SelectionChanged);
        }
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            OsveziBojuStolova();//za boju stolova
        }

        private void OsveziBojuStolova()
        {
            DateTime izabraniDatum = dateTimePicker1.Value.Date;
            List<int> zauzeti = rezervacijaRepo.DobaviZauzeteStoloveZaDatum(izabraniDatum);

            BrojStolaBox.DrawMode = DrawMode.OwnerDrawFixed; // omogući custom boju
            BrojStolaBox.DrawItem -= BrojStolaBox_DrawItem; // ukloni ako već postoji
            BrojStolaBox.DrawItem += BrojStolaBox_DrawItem;  //doda ako nepostoji

            // Ponovo popuni stolove ako fale
            BrojStolaBox.Items.Clear();
            for (int i = 1; i <= 20; i++)
                BrojStolaBox.Items.Add(i);
        }
        private void BrojStolaBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            DateTime izabraniDatum = dateTimePicker1.Value.Date;
            List<int> zauzeti = rezervacijaRepo.DobaviZauzeteStoloveZaDatum(izabraniDatum);

            if (!int.TryParse(BrojStolaBox.Items[e.Index]?.ToString(), out int brojStola))
            {
                e.DrawBackground();
                return;
            }

            bool zauzet = zauzeti.Contains(brojStola);
            Color boja = zauzet ? Color.Red : Color.Green;

            e.Graphics.FillRectangle(new SolidBrush(boja), e.Bounds);
            e.Graphics.DrawString(brojStola.ToString(), e.Font, Brushes.White, e.Bounds.X + 2, e.Bounds.Y + 2);
            e.DrawFocusRectangle();
        }
        // ZA PRIKAZ REZERVACIJA
        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgv.SelectedRows[0];
                try
                {
                   //PARAMETRI
                    RezervacijaBOX.Text = row.Cells["IDRezervacije"].Value.ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(row.Cells["Datum"].Value);

                    
                    TimeSpan vremeSpan = (TimeSpan)row.Cells["Vreme"].Value;
                    VremeBOX.Text = vremeSpan.ToString(@"hh\:mm");

                    BrojOsobaBOX.Text = row.Cells["BrojOsoba"].Value.ToString();
                    ImeGostaBOX.Text = row.Cells["ImeGosta"].Value.ToString();
                    PrezimeGostaBOX.Text = row.Cells["PrezimeGosta"].Value.ToString();
                    BrojStolaBox.Text = row.Cells["BrojStola"].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška pri popunjavanju polja: " + ex.Message);
                }
            }
        }
        private void PrikaziSveRezervacije()//PRIKAZUJE SVE REZERVACIJE
        {
            try
            {
                DataTable Rezervacije = rezervacijaRepo.DohvatiSveRezervacije();
                DataGridView.DataSource = Rezervacije;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri dohvatanju rezervacija: " + ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        //Dugme potvrdi
        private void Potvrdi_Click(object sender, EventArgs e)
        {
            try
            {
                //pretrazuje po filteru ako je prazno
                string filterText = PretraziBox.Text.Trim();
                if (!string.IsNullOrEmpty(filterText))
                {
                    DataTable filteredrezervacija = rezervacijaRepo.PretraziPoImenu(filterText);
                    DataGridView.DataSource = filteredrezervacija;
                }
                else
                {
                    PrikaziSveRezervacije();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri pretrazi: " + ex.Message);
            }
        }


        private void Prikazi_Click(object sender, EventArgs e)
        {
            PrikaziSveRezervacije();
        }
        //DUGME ZA UNOS///////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
          private void Unesi_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime datum = dateTimePicker1.Value.Date;
                TimeSpan vreme = TimeSpan.Parse(VremeBOX.Text);
                int brojOsoba = int.Parse(BrojOsobaBOX.Text);

                string ime = ImeGostaBOX.Text.Trim();
                string prezime = PrezimeGostaBOX.Text.Trim();
                Rezervacija rez = new Rezervacija();

                int idGosta = rez.NadjiIliDodajGosta(ime, prezime);
                if (BrojStolaBox.SelectedItem == null)
                {
                    MessageBox.Show("Izaberite sto.");
                    return;
                }
                //AKO JE NEKOME DOSADNO I UKUCA SLOVO
                if (!int.TryParse(BrojStolaBox.SelectedItem.ToString(), out int brojStola))
                {
                    MessageBox.Show("Izabrana vrednost nije broj.");
                    return;
                }
                //sto je zauzet
                List<int> zauzeti = rez.DobaviZauzeteStoloveZaDatum(datum);
                if (zauzeti.Contains(brojStola))
                {
                    MessageBox.Show($"Sto {brojStola} je već rezervisan za {datum:dd.MM.yyyy}. Izaberite drugi.");
                    return;
                }

                int idStola = rez.NadjiIliDodajSto(brojStola.ToString());
                rez.Unesi(datum, vreme, brojOsoba, idGosta, idStola);

                MessageBox.Show("Rezervacija uspešno dodata!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Greška.IZVINI ALI VASILIJA JE OCIGLEDNO MRZELO DA NAPISE STA JE TACNO GRESKA PA SAMO PROVERI JER SVE U DOBROM FORMATU");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri unosu: " + ex.Message);
            }
        }
//BRISANJE REZERVACIJA//////////////////////////////////////////////////////////////////////////////////////////////////////
        private void ObrisiRezervaciju_Click(object sender, EventArgs e)
        {
            if (DataGridView.CurrentRow != null)
            {
                if (MessageBox.Show("Da li ste sigurni da želite da obrišete ovu rezervaciju?", "Potvrda brisanja", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        int id = Convert.ToInt32(DataGridView.CurrentRow.Cells["IDRezervacije"].Value);

                        Rezervacija rezervacijaRepo = new Rezervacija(); 
                        rezervacijaRepo.ObrisiRezervacijuIGostaAkoJePoslednji(id);

                        PrikaziSveRezervacije(); 
                        MessageBox.Show("Rezervacija uspešno obrisana!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Greška pri brisanju: " + ex.Message);
                    }
                }
            }
        }

        //IZMENA/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Izmeni_Click(object sender, EventArgs e)

        {
            if (DataGridView.CurrentRow != null)
            {
                try
                {
                    int idRezervacije = Convert.ToInt32(DataGridView.CurrentRow.Cells["IDRezervacije"].Value);

                    DateTime datum = dateTimePicker1.Value.Date;
                    TimeSpan vreme = TimeSpan.Parse(VremeBOX.Text);
                    int brojOsoba = int.Parse(BrojOsobaBOX.Text);
                    if (BrojStolaBox.SelectedItem == null)
                    {
                        MessageBox.Show("Izaberite sto.");
                        return;
                    }

                    if (!int.TryParse(BrojStolaBox.SelectedItem.ToString(), out int brojStola))
                    {
                        MessageBox.Show("Izabrana vrednost nije broj.");
                        return;
                    }

                    string ime = ImeGostaBOX.Text.Trim();
                    string prezime = PrezimeGostaBOX.Text.Trim();

                    
                    int idGosta = rezervacijaRepo.NadjiIliDodajGosta(ime, prezime);

               
                    int idStola = rezervacijaRepo.NadjiIliDodajSto(brojStola.ToString());

                    // Izmeni rezervaciju
                    rezervacijaRepo.Izmeni(idRezervacije, datum, vreme, brojOsoba, idGosta, idStola);

                    PrikaziSveRezervacije();
                    MessageBox.Show("✅ Rezervacija uspešno izmenjena!");
                }
                catch (FormatException)
                {
                    MessageBox.Show("⚠️ Greška: Proveri da li su svi brojevi i vreme u formatu (npr. 14:30).",
                                    "Greška u formatu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Greška pri izmeni: " + ex.Message,
                                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("⚠️ Selektuj red u tabeli koji želiš da izmeniš.",
                                "Nema selekcije", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView.CurrentRow != null)
            {
                DataGridViewRow row = DataGridView.CurrentRow;

             
                RezervacijaBOX.Text = row.Cells["IDRezervacije"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["Datum"].Value);
                BrojOsobaBOX.Text = row.Cells["BrojOsoba"].Value.ToString();

            }
        }

        private void BrojStolaBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
