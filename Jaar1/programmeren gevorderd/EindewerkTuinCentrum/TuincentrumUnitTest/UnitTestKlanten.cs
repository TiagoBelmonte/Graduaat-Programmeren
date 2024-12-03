using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TuincentrumUnitTest
{
    [TestClass]
    public class UnitTestKlanten
    {
        [Fact]
        public void TestKlantAanmakenValid()
        {
            Klant klant = new Klant(1, "Tiago Belmonte"  , "Tulpenlaan 15");
            Assert.Equal(1, klant.Id);
            Assert.Equal("Tiago Belmonte", klant.Naam);
            Assert.Equal("Tulpenlaan 15", klant.Adres);
        }

        [Fact]
        public void TestKlantAanmakenInValidId()
        {
            Assert.Throws<DomeinException>(() => new Klant(0, "Tiago Belmonte", "Tulpenlaan 15"));
            Assert.Throws<DomeinException>(() => new Klant(-5, "Tiago Belmonte", "Tulpenlaan 15"));
        }

        [Fact]
        public void TestKlantAanmakenInValidNaam()
        {
            Assert.Throws<DomeinException>(() => new Klant(1, "", "Stationsstraat 1"));
            Assert.Throws<DomeinException>(() => new Klant(1, null, "Stationsstraat 1"));
        }

        [Fact]
        public void TestKlantAanmakenInvalidAdres()
        {
            Assert.Throws<DomeinException>(() => new Klant(1, "Tiago Belmonte", ""));
            Assert.Throws<DomeinException>(() => new Klant(1, "Tiago Belmonte", null));
        }

        [Fact]
        public void TestSetNaamValid()
        {
            Klant klant = new Klant(1, "Tiago Belmonte", "Tulpenlaan 15");
            klant.Naam = "Tiago Belmonte";
            Assert.Equal("Tiago Belmonte", klant.Naam);
        }

        [Fact]
        public void TestSetNaamInvalid()
        {
            Klant klant = new Klant(1, "Tiago Belmonte", "Tulpenlaan 15");
            Assert.Throws<DomeinException>(() => klant.Naam = "");
            Assert.Throws<DomeinException>(() => klant.Naam = null);
        }

        [Fact]
        public void TestSetAdresValid()
        {
            Klant klant = new Klant(1, "Tiago Belmonte", "Tulpenlaan 15");
            klant.Adres = "Tulpenlaan 15";
            Assert.Equal("Tulpenlaan 15", klant.Adres);
        }

        [Fact]
        public void TestSetAdresInvalid()
        {
            Klant klant = new Klant(1, "Tiago Belmonte", "Tulpenlaan 15");
            Assert.Throws<DomeinException>(() => klant.Adres = "");
            Assert.Throws<DomeinException>(() => klant.Adres = null);
        }

        [Fact]
        public void TestToString()
        {
            Klant klant = new Klant(1, "Tiago Belmonte", "Tulpenlaan 15");
            Assert.Equal("Naam: Tiago Belmonte, Adres: Tulpenlaan 15", klant.ToString());
        }
    }
}
