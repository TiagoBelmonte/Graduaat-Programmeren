using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuinCentrumBL.Exceptions;
using TuinCentrumBL.Model;
using Xunit;

namespace TuinCentrumUnitTesten
{
    public class UnitTestProduct
    {
        [Fact]
        public void TestProductAanmakenValid()
        {
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");
            Xunit.Assert.Equal(1, product.ID);
            Xunit.Assert.Equal("Iris", product.NederlandseNaam);
            Xunit.Assert.Equal("Iris Germanica", product.WetenschappelijkeNaam);
            Xunit.Assert.Equal(10.99, product.Prijs);
            Xunit.Assert.Equal("Een mooie bloem", product.Beschrijving);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void TestProductAanmakenInvalidId(int id)
        {
            Xunit.Assert.Throws<DomeinException>(() => new Product(id, "Iris", "Iris Germanica", 10.99, "Een mooie bloem"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void TestProductAanmakenInvalidNaamNL(string naamNL)
        {
            Xunit.Assert.Throws<DomeinException>(() => new Product(1, naamNL, "Iris Germanica", 10.99, "Een mooie bloem"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void TestProductAanmakenInvalidNaamLatijn(string naamLatijn)
        {
            Xunit.Assert.Throws<DomeinException>(() => new Product(1, "Iris", naamLatijn, 10.99, "Een mooie bloem"));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void TestProductAanmakenInvalidPrijs(double prijs)
        {
            Xunit.Assert.Throws<DomeinException>(() => new Product(1, "Iris", "Iris Germanica", prijs, "Een mooie bloem"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void TestProductAanmakenInvalidBeschrijving(string beschrijving)
        {
            Xunit.Assert.Throws<DomeinException>(() => new Product(1, "Iris", "Iris Germanica", 10.99, beschrijving));
        }

        [Fact]
        public void TestSetIdValid()
        {
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");
            product.ID = 2;
            Xunit.Assert.Equal(2, product.ID);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void TestSetIdInvalid(int id)
        {
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");
            Xunit.Assert.Throws<DomeinException>(() => product.ID = id);
        }

        [Fact]
        public void TestSetNaamNLValid()
        {
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");
            product.NederlandseNaam = "Roos";
            Xunit.Assert.Equal("Roos", product.NederlandseNaam);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void TestSetNaamNLInvalid(string naamNL)
        {
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");
            Xunit.Assert.Throws<DomeinException>(() => product.NederlandseNaam = naamNL);
        }

        [Fact]
        public void TestSetNaamLatijnValid()
        {
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");
            product.WetenschappelijkeNaam = "Rosa";
            Xunit.Assert.Equal("Rosa", product.WetenschappelijkeNaam);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void TestSetNaamLatijnInvalid(string naamLatijn)
        {
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");
            Xunit.Assert.Throws<DomeinException>(() => product.WetenschappelijkeNaam = naamLatijn);
        }

        [Fact]
        public void TestSetPrijsValid()
        {
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");
            product.Prijs = 12.99;
            Xunit.Assert.Equal(12.99, product.Prijs);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void TestSetPrijsInvalid(double prijs)
        {
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");
            Xunit.Assert.Throws<DomeinException>(() => product.Prijs = prijs);
        }

        [Fact]
        public void TestSetBeschrijvingValid()
        {
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");
            product.Beschrijving = "Een prachtige bloem";
            Xunit.Assert.Equal("Een prachtige bloem", product.Beschrijving);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void TestSetBeschrijvingInvalid(string beschrijving)
        {
            Product product = new Product(1, "Iris", "Iris Germanica", 10.99, "Een mooie bloem");
            Xunit.Assert.Throws<DomeinException>(() => product.Beschrijving = beschrijving);
        }

    }
}