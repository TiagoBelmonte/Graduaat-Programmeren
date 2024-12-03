using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TuinCentrumBL.Exceptions;
using TuinCentrumBL.Model;
using Xunit;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TuinCentrumUnitTesten
{
    public class UnitTestOfferte
    {

        [Fact]
        public void TestOfferteAanmakenConstr1Valid()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Aalterstraat 17");
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");

            Offerte offerte = new Offerte(1, DateTime.Now, klant.ID, true, false, 1,0);
            offerte.voegProductToe(1, 1);

            Xunit.Assert.Equal(1, offerte.ID);
            Xunit.Assert.Equal(DateTime.Now.Date, offerte.Datum.Date);
            Xunit.Assert.Equal(klant.ID, offerte.klantnummer);
            Xunit.Assert.True(offerte.afhaal);
            Xunit.Assert.False(offerte.aanleg);
        }

        [Fact]
        public void TestOfferteAanmakenConstr2Valid()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Aalterstraat 17");
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");

            Offerte offerte = new Offerte(1, DateTime.Now, klant.ID, true, false, 1, product.Prijs);
            offerte.voegProductToe(product.ID, 1);

            Xunit.Assert.Equal(1, offerte.ID);
            Xunit.Assert.Equal(DateTime.Now.Date, offerte.Datum.Date);
            Xunit.Assert.Equal(klant.ID, offerte.klantnummer);
            Xunit.Assert.True(offerte.afhaal);
            Xunit.Assert.False(offerte.aanleg);
        }

        [Fact]
        public void TestOfferteAanmakenConstr3Valid()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Aalterstraat 17");
            Offerte offerte = new Offerte(1, DateTime.Now, klant.ID, true, false, 1,0);

            Xunit.Assert.Equal(1, offerte.ID);
            Xunit.Assert.Equal(DateTime.Now.Date, offerte.Datum.Date);
            Xunit.Assert.Equal(klant.ID, offerte.klantnummer);
            Xunit.Assert.True(offerte.afhaal);
            Xunit.Assert.False(offerte.aanleg);
            Xunit.Assert.Equal(0, offerte.Prijs);
        }

        [Fact]
        public void TestOfferteAanmakenInvalidId()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Aalterstraat 17");
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");

            Xunit.Assert.Throws<DomeinException>(() => new Offerte(0, DateTime.Now, klant.ID, true, false, 1,0));
            Xunit.Assert.Throws<DomeinException>(() => new Offerte(-1, DateTime.Now, klant.ID, true, false, 1,0));
        }

        [Fact]
        public void TestOfferteAanmakenConstr2InvalidId()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Aalterstraat 17");
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");

            Xunit.Assert.Throws<DomeinException>(() => new Offerte(0, DateTime.Now, klant.ID, true, false, 1, product.Prijs));
            Xunit.Assert.Throws<DomeinException>(() => new Offerte(-1, DateTime.Now, klant.ID, true, false, 1, product.Prijs));
        }

        [Fact]
        public void TestOfferteAanmakenConstr3InvalidId()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Aalterstraat 17");
            Xunit.Assert.Throws<DomeinException>(() => new Offerte(0, DateTime.Now, klant.ID, true, false, 1,0));
            Xunit.Assert.Throws<DomeinException>(() => new Offerte(-1, DateTime.Now, klant.ID, true, false, 1,0));
        }

        [Fact]
        public void TestOfferteAanmakenInvalidDatum()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Aalterstraat 17");
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");

            Xunit.Assert.Throws<DomeinException>(() => new Offerte(1, DateTime.Now.AddDays(1), klant.ID, true, false, 1,0));
        }

        [Fact]
        public void TestOfferteAanmakenInvalidKlant()
        {
            Xunit.Assert.Throws<DomeinException>(() => new Offerte(1, DateTime.Now, -1, true, false, 1,0));
        }

        [Fact]
        public void TestOfferteAanmakenInvalidAantalProducten()
        {
            var klant = new Klant(1, "Jan Janssen", "Aalterstraat 17");

            Xunit.Assert.Throws<DomeinException>(() => new Offerte(1, DateTime.Now, klant.ID, true, false, -1,0));
        }

        [Fact]
        public void TestSetDatumValid()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Offerte offerte = new Offerte(1, DateTime.Now, klant.ID, true, false, 1,0);
            DateTime nieuweDatum = DateTime.Parse("2023-12-12");
            offerte.Datum = nieuweDatum;
            Xunit.Assert.Equal(nieuweDatum.Date, offerte.Datum.Date);
        }

        [Fact]
        public void TestSetDatumInValid()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Offerte offerte = new Offerte(1, DateTime.Now, klant.ID, true, false, 1,0);
            DateTime nieuweDatum = DateTime.Now.AddDays(1);
            Xunit.Assert.Throws<DomeinException>(() => offerte.Datum = nieuweDatum);
        }

        [Fact]
        public void TestSetKlantValid()
        {
            Klant klant1 = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Klant klant2 = new Klant(1, "Piet Pietersen", "Kerkstraat 2");
            Offerte offerte = new Offerte(1, DateTime.Now, klant1.ID, true, false, 1,0);
            offerte.klantnummer = klant2.ID;
            Xunit.Assert.Equal(klant2.ID, offerte.klantnummer);
        }

        [Fact]
        public void TestSetKlantInValid()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Offerte offerte = new Offerte(1, DateTime.Now, klant.ID, true, false, 1,0);
            Klant klant2 = null;
            Xunit.Assert.Throws<DomeinException>(() => offerte.klantnummer = klant2.ID);
        }

        [Fact]
        public void TestSetAfhaalValid()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Offerte offerte = new Offerte(1, DateTime.Now, klant.ID, true, false, 1,0);
            offerte.afhaal = false;
            Xunit.Assert.False(offerte.afhaal);
        }

        [Fact]
        public void TestSetAanlegValid()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Offerte offerte = new Offerte(1, DateTime.Now, klant.ID, true, false, 1, 0);
            offerte.aanleg = true;
            Xunit.Assert.True(offerte.aanleg);
        }

        [Fact]
        public void TestSetAantalProductenValid()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");
            Product product2 = new Product(2, "Roos", "Rosa", 55, "Een mindere bloem");

            Offerte offerte = new Offerte(1, DateTime.Now, klant.ID, true, false, 1, 0);
            offerte.voegProductToe(1, product.ID);
            offerte.voegProductToe(2, product2.ID);
        }

        [Fact]
        public void TestVoegProductToeValid()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");
            Product product2 = new Product(2, "Roos", "Rosa", 55, "Een mindere bloem");

            Offerte offerte = new Offerte(1, DateTime.Now, klant.ID, true, false, 1, 0);
            offerte.voegProductToe(1, product.ID);
            offerte.voegProductToe(2, product.ID);

        }

        [Fact]
        public void TestVoegProductToeInValid()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");
            Offerte offerte = new Offerte(1, DateTime.Now, klant.ID, true, false, 1, 0);
            Xunit.Assert.Throws<DomeinException>(() => offerte.voegProductToe(0, product.ID));
            Xunit.Assert.Throws<DomeinException>(() => offerte.voegProductToe(5, -5));
            Xunit.Assert.Throws<DomeinException>(() => offerte.voegProductToe(0, 0));
        }

        [Fact]
        public void TestVerwijderProduct()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");
            Offerte offerte = new Offerte(1, DateTime.Now, klant.ID, true, false, 1, 0);
            offerte.voegProductToe(1, product.ID);
            offerte.verwijderProduct(1, product.ID);
            Xunit.Assert.Equal(0, offerte.Producten.Count);
        }

        [Fact]
        public void TestVerwijderProductInValid()
        {
            Klant klant = new Klant(1, "Jan Janssen", "Stationsstraat 1");
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");
            Product product2 = new Product(2, "Roos", "Rosa", 55, "Een mindere bloem");

            Offerte offerte = new Offerte(1, DateTime.Now, klant.ID, true, false, 1, 0);
            Xunit.Assert.Throws<DomeinException>(() => offerte.verwijderProduct(0, product.ID));
            Xunit.Assert.Throws<DomeinException>(() => offerte.verwijderProduct(5, product.ID));
            Xunit.Assert.Throws<DomeinException>(() => offerte.verwijderProduct(5, 0));
            Xunit.Assert.Throws<DomeinException>(() => offerte.verwijderProduct(1, product2.ID));
            Xunit.Assert.Throws<DomeinException>(() => offerte.verwijderProduct(0, 0));
        }
    }
}
