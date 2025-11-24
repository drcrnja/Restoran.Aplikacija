using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restoran;
using System;

namespace Restoran.Tests
{
    [TestClass]
    public class RezervacijaTests
    {
        private Rezervacija rezervacija;

        [TestInitialize]
        public void Setup()
        {
            rezervacija = new Rezervacija();
        }

        [TestMethod]
        public void Test_DohvatiSveRezervacije()
        {
           
            var dt = rezervacija.DohvatiSveRezervacije();

            
            Assert.IsNotNull(dt, "DataTable ne bi smeo biti null.");
        }

        [TestMethod]
        public void Test_NadjiIliDodajGosta()
        {
           
            string ime = "TestGost";
            string prezime = "Testic";

            
            int id = rezervacija.NadjiIliDodajGosta(ime, prezime);

           
            Assert.IsTrue(id > 0, "IDGosta bi trebalo da bude veći od 0.");
        }

        [TestMethod]
        public void Test_Unesi_ValidnePodatke()
        {
            
            DateTime datum = DateTime.Now.Date;
            TimeSpan vreme = new TimeSpan(12, 30, 0);
            int brojOsoba = 2;
            int idGosta = rezervacija.NadjiIliDodajGosta("TestGost", "Testic");
            int idStola = 1; 

            
            try
            {
                rezervacija.Unesi(datum, vreme, brojOsoba, idGosta, idStola);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unos nije uspeo: " + ex.Message);
            }
        }
    }
}
