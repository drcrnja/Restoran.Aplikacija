using System;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Restoran
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //POSTAVLJA LOZINKU DA SE NEVIDI
            Sifra.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //POSTAVLJA KORISNICKO IME I LOZINKU
            const string ISPRANO_USERNAME = "admin";
            const string ISPRANA_SIFRA = "1234";

            
            string username = Korisnickoime.Text.Trim();
            string password = Sifra.Text.Trim();
            //PROVERAVA DAL SE IME I LOZINKA POKLAPAJU
            if (username == ISPRANO_USERNAME && password == ISPRANA_SIFRA)
            {
              
                Pocetna pocetnaForma = new Pocetna();//SLEDECA STRANA

               
                pocetnaForma.FormClosed += (s, args) => this.Close();

                this.Hide();

                pocetnaForma.Show();
            }
            else
            {
                //SLUCAJ UKOLIKO JE IME ILI LOZINKA POGRESNO NAPISANA
                MessageBox.Show("Neispravno korisničko ime ili lozinka.");

                Korisnickoime.Clear();
                Sifra.Clear();

                Korisnickoime.Focus();
            }
        }
        //DUGME ZA ODUSTATI
        private void Odustani_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NECES DA SE PRIJAVIS?OKE UZIVAJ U EMOJIJU MACE ONDA 🐈");
        }
    }
}
