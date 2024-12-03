using System;
using TuinCentrumBL.Exceptions;
using TuinCentrumBL.Model;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TuinCentrumUnitTesten
{
    [TestClass]
    public class UnitTestKlant
    {
        [Fact]
        public void TestKlantAanmakenValid()
        {
            Klant klant = new Klant(1, "Piet Pietersen", "Aalterstraat 17");
            Xunit.Assert.Equal(1, klant.ID);
            Xunit.Assert.Equal("Piet Pietersen", klant.Naam);
            Xunit.Assert.Equal("Aalterstraat 17", klant.Adres);
        }

        [Fact]
        public void TestKlantAanmakenInValidId()
        {
            Xunit.Assert.Throws<DomeinException>(() => new Klant(0, "Jan Janssen", "Aalterstraat 17"));
            Xunit.Assert.Throws<DomeinException>(() => new Klant(-5, "Jan Janssen", "Aalterstraat 17"));
        }

        [Fact]
        public void TestKlantAanmakenInValidNaam()
        {
            Xunit.Assert.Throws<DomeinException>(() => new Klant(1, "", "Stationsstraat 1"));
            Xunit.Assert.Throws<DomeinException>(() => new Klant(1, null, "Stationsstraat 1"));
        }

        [Fact]
        public void TestKlantAanmakenInvalidAdres()
        {
            Xunit.Assert.Throws<DomeinException>(() => new Klant(1, "Jan Janssen", ""));
            Xunit.Assert.Throws<DomeinException>(() => new Klant(1, "Jan Janssen", null));
        }

        [Fact]
        public void TestSetNaamValid()
        {
            Klant klant = new Klant(1, "Piet Pietersen", "Aalterstraat 17");
            klant.Naam = "Klaas Klaassen";
            Xunit.Assert.Equal("Klaas Klaassen", klant.Naam);
        }

        [Fact]
        public void TestSetNaamInvalid()
        {
            Klant klant = new Klant(1, "Piet Pietersen", "Aalterstraat 17");
            Xunit.Assert.Throws<DomeinException>(() => klant.Naam = "");
            Xunit.Assert.Throws<DomeinException>(() => klant.Naam = null);
        }

        [Fact]
        public void TestSetAdresValid()
        {
            Klant klant = new Klant(1, "Piet Pietersen", "Aalterstraat 17");
            klant.Adres = "Toekomstlaan 31";
            Xunit.Assert.Equal("Toekomstlaan 31", klant.Adres);
        }

        [Fact]
        public void TestSetAdresInvalid()
        {
            Klant klant = new Klant(1, "Piet Pietersen", "Aalterstraat 17");
            Xunit.Assert.Throws<DomeinException>(() => klant.Adres = "");
            Xunit.Assert.Throws<DomeinException>(() => klant.Adres = null);
        }

        [Fact]
        public void TestToString()
        {
            Klant klant = new Klant(1, "Piet Pietersen", "Aalterstraat 17");
            Xunit.Assert.Equal("Naam: Piet Pietersen, Adres: Aalterstraat 17", klant.ToString());
        }
    }
}