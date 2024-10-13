using ScheepsvaartBL.Enums;
using ScheepsvaartBL.Exceptions;
using ScheepsvaartBL.Model;
using ScheepvaartBL.Exceptions;
using ScheepvaartBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class UnitTestRederij
    {

        private Haven haven1, haven2, haven3, haven4, haven5;

        private Vloot vloot1, vloot2, vloot3, vloot4;

        private Containerschip containerschip1, containerschip2, containerschip3, containerschip4;
        private Cruiseschip cruiseschip1, cruiseschip2, cruiseschip3;
        private GasTanker gastanker1, gastanker2, gastanker3, gastanker4;
        private OlieTanker olietanker1, olietanker2, olietanker3;
        private RoRoschip roroschip1, roroschip2, roroschip3;
        private Sleepboot sleepboot1, sleepboot2, sleepboot3;
        private Veerboot veerboot1, veerboot2, veerboot3;

        private List<Haven> havenList1, havenList2, havenList3;

        private Dictionary<Haven, Haven> traject1, traject2, traject3;

        private SortedList<string, Haven> havenSortedList1;

        private Dictionary<string, Schip> boten1, boten2, boten3, boten4;

        private Dictionary<string, Vloot> vlotengroep;

        private Rederij rederij;


        public UnitTestRederij()
        {

            //Havens worden aangemaakt
            haven1 = new Haven("Gent");
            haven2 = new Haven("ruiselede");
            haven3 = new Haven("tielt");
            haven4 = new Haven("Rotterdam");
            haven5 = new Haven("Amsterdam");

            //Lijst met havens wordt aangemaakt, nodig bij cruiseschepen (traject)
            havenList1 = new List<Haven> { haven1, haven3, haven2 };
            havenList2 = new List<Haven> { haven1, haven2, haven4, haven3 };
            havenList3 = new List<Haven> { haven1, haven4 };

            havenSortedList1 = new SortedList<string, Haven>
            {
                { haven1.Naam, haven1 },
                { haven2.Naam, haven2 },
                { haven3.Naam, haven3 },
                { haven4.Naam, haven4 }            
            };

            //Dictionary met 2 havens, traject voor sleepboten
            traject1 = new Dictionary<Haven, Haven> { { haven1, haven2 } };
            traject2 = new Dictionary<Haven, Haven> { { haven3, haven4 } };
            traject3 = new Dictionary<Haven, Haven> { { haven1, haven3 } };

            //Verschillende schepen worden gedeclareerd
            containerschip1 = new Containerschip("ss containership1", 123, 123, 100, 10, 23);
            containerschip2 = new Containerschip("ss containership2", 200, 150, 100, 10, 30);
            containerschip3 = new Containerschip("ss containership3", 180, 160, 100, 10, 25);
            containerschip4 = new Containerschip("ss containership4", 123, 123, 100, 10, 23);


            roroschip1 = new RoRoschip("ss roroschip1", 10, 50, 200, 20, 50, 50);
            roroschip2 = new RoRoschip("ss roroschip2", 12, 60, 200, 20, 60, 55);
            roroschip3 = new RoRoschip("ss roroschip3", 8, 45, 200, 20, 40, 45);

            gastanker1 = new GasTanker("ss gastanker1", 10, 50, 300, 30, 1000, GasLading.LPG);
            gastanker2 = new GasTanker("ss gastanker2", 12, 300, 300, 30, 1200, GasLading.LNG);
            gastanker3 = new GasTanker("ss gastanker3", 8, 45, 300, 30, 800, GasLading.Amoniak);
            gastanker4 = new GasTanker("ss gastanker4", 8, 45, 300, 30, 800, GasLading.Amoniak);


            olietanker2 = new OlieTanker("ss olietanker2", 10, 50, 300, 40, 25, OlieLading.Olie);
            olietanker3 = new OlieTanker("ss olietanker3", 12, 300, 300, 40, 25, OlieLading.Benzeen);
            olietanker1 = new OlieTanker("ss olietanker1", 8, 45, 300, 40, 25, OlieLading.Diesel);

            cruiseschip1 = new Cruiseschip("ss cruiseschip1", 10, 53, 400, 300, havenList1);
            cruiseschip2 = new Cruiseschip("ss cruiseschip2", 12, 60, 400, 300, havenList2);
            cruiseschip3 = new Cruiseschip("ss cruiseschip3", 8, 45, 400, 300, havenList3);

            veerboot1 = new Veerboot("ss veerboot1", 50.5, 20.3, 600, 200, traject1);
            veerboot2 = new Veerboot("ss veerboot2", 45.8, 18.6, 600, 200, traject2);
            veerboot3 = new Veerboot("ss veerboot3", 48.2, 22.1, 600, 200, traject3);

            sleepboot1 = new Sleepboot("ss sleepboot1", 55, 66, 500);
            sleepboot2 = new Sleepboot("ss sleepboot2", 60, 70, 500);
            sleepboot3 = new Sleepboot("ss sleepboot3", 50, 60, 500);

            //Dictionary met boten wordt gemaakt bestaande uit key = naam, value = obj boot
            boten1 = new Dictionary<string, Schip>
            {
                { containerschip1.Naam, containerschip1 },
                { roroschip1.Naam, roroschip1 },
                { containerschip3.Naam, containerschip3 },
                { cruiseschip1.Naam, cruiseschip1 },
                { veerboot1.Naam, veerboot1 },
                { olietanker1.Naam, olietanker1 },
                { cruiseschip2.Naam, cruiseschip2 }
            };

            boten2 = new Dictionary<string, Schip>
            {
                { containerschip2.Naam, containerschip2 },
                { olietanker2.Naam, olietanker2 },
                { roroschip2.Naam, roroschip2 },
                { gastanker1.Naam, gastanker1 },
                { gastanker2.Naam, gastanker2 },
                { veerboot2.Naam, veerboot2 },
                { sleepboot1.Naam, sleepboot1 },
                { sleepboot3.Naam, sleepboot3 },
            };

            boten3 = new Dictionary<string, Schip>
            {
                { roroschip3.Naam, roroschip3 },
                { gastanker3.Naam, gastanker3 },
                { cruiseschip3.Naam, cruiseschip3 },
                { veerboot3.Naam, veerboot3 },
                { olietanker3.Naam, olietanker3 },
                { sleepboot2.Naam, sleepboot2 }
            };

            boten4 = new Dictionary<string, Schip>
            {
                { gastanker4.Naam, gastanker4 },
                { containerschip4.Naam, containerschip4 }
            };

            //Vloten worden aangemaakt met als key = naam, value = dictionary van boten
            vloot1 = new Vloot("ss boten1", boten1);
            vloot2 = new Vloot("ss boten2", boten2);
            vloot3 = new Vloot("ss boten3", boten3);

            vloot4 = new Vloot("ss boten4", boten4);

            vlotengroep = new Dictionary<string, Vloot>
            {
                { vloot1.Naam, vloot1},
                { vloot2.Naam, vloot2},
                { vloot3.Naam, vloot3},
            };

            rederij = new Rederij(vlotengroep, havenSortedList1);
        }

        [Fact]
        public void Test_BerekenTotaleCargowaarde_Valid()
        {
            Assert.Equal(300, rederij.BerekenTotaleCargowaarde());
        }

        [Fact]
        public void Test_BerekenAantalPassagiers_Valid()
        {
            Assert.Equal(1500, rederij.berekenTotaalAantalPassagiers());
        }

        [Fact]
        public void Test_BerekenTonnagePerVloot_Valid()
        {
            Dictionary<Vloot, double> tPV = rederij.berekenTonnagePerVloot();

            Assert.Equal(3, tPV.Count);
            Assert.Equal(2100, tPV[vloot1]);
            Assert.Equal(2800, tPV[vloot2]);
            Assert.Equal(2300, tPV[vloot3]);
        }

        [Fact]
        public void Test_BerekenTotaalVolumeTankers_Valid()
        {
            Assert.Equal(3075, rederij.BerekenTotaalVolumeTankers());
        }

        [Fact]
        public void Test_BerekenAantalSleepboten_Valid()
        {
            Assert.Equal(3, rederij.BerekenAantalSleepboten());
        }

        [Fact]
        public void Test_HavensSorteren()
        { 
            List<string> gesorteerd = rederij.geordendeHavensPrinten();
            Assert.Equal("Gent", havenSortedList1.Keys[0]);
            Assert.Equal("Rotterdam", havenSortedList1.Keys[1]);
            Assert.Equal("ruiselede", havenSortedList1.Keys[2]);
            Assert.Equal("tielt", havenSortedList1.Keys[3]);

        }

        [Fact]
        public void Test_VoegVlootToe_Valid()
        {
            rederij.VoegVlootToe(vloot4);
            Assert.Contains(vloot1, rederij.Vloten.Values);
            Assert.Contains(vloot2, rederij.Vloten.Values);
            Assert.Contains(vloot3, rederij.Vloten.Values);
            Assert.Contains(vloot4, rederij.Vloten.Values);
            Assert.Equal(4, rederij.Vloten.Count);
        }

        [Fact]
        public void Test_VoegVlootToe_InValid()
        {
            Assert.Throws<VlootException>(() => rederij.VoegVlootToe(null));
            Assert.Throws<VlootException>(() => rederij.VoegVlootToe(vloot1));
            Assert.Equal(3, rederij.Vloten.Count());
        }

        [Fact]
        public void Test_VerwijderVloot_Valid()
        {
            rederij.VerwijderVloot(vloot3);
            Assert.Contains(vloot1, rederij.Vloten.Values);
            Assert.Contains(vloot2, rederij.Vloten.Values);
            Assert.DoesNotContain(vloot3, rederij.Vloten.Values);
            Assert.Equal(2, rederij.Vloten.Count);
        }

        [Fact]
        public void Test_VerwijderVloot_InValid()
        {
            Assert.Throws<VlootException>(() => rederij.VerwijderVloot(null));
            Assert.Throws<VlootException>(() => rederij.VerwijderVloot(vloot4));

            Assert.Equal(4, rederij.Havens.Count());
        }

        [Fact]
        public void Test_VoegHavenToe_Valid()
        {
            rederij.VoegHavenToe(haven5);
            Assert.Equal(5, rederij.Havens.Count);
            Assert.Contains(haven1, rederij.Havens.Values);
            Assert.Contains(haven2, rederij.Havens.Values);
            Assert.Contains(haven3, rederij.Havens.Values);
            Assert.Contains(haven4, rederij.Havens.Values);
            Assert.Contains(haven5, rederij.Havens.Values);
        }

        [Fact]
        public void Test_VoegHavenToe_InValid()
        {
            Assert.Throws<HavenException>(() => rederij.VoegHavenToe(null));
            Assert.Throws<HavenException>(() => rederij.VoegHavenToe(haven2));

            Assert.Equal(4, rederij.Havens.Count());
        }

        [Fact]
        public void Test_VerwijderHaven_Valid()
        {
            rederij.VerwijderHaven(haven2);
            Assert.Contains(haven1, rederij.Havens.Values);
            Assert.Contains(haven3, rederij.Havens.Values);
            Assert.Contains(haven4, rederij.Havens.Values);
            Assert.DoesNotContain(haven2, rederij.Havens.Values);
            Assert.Equal(3, rederij.Havens.Count);
        }

        [Fact]
        public void Test_VerwijderHaven_Invalid()
        {
            Assert.Throws<HavenException>(() => rederij.VerwijderHaven(null));
            Assert.Throws<HavenException>(() => rederij.VerwijderHaven(haven5));

            Assert.Equal(4, rederij.Havens.Count());
        }

        [Fact]
        public void Test_VerplaatsSchip_Valid()
        {
            rederij.verplaatsSchip(containerschip1, vloot2);
            Assert.Equal(6, vloot1.Schepen.Count);
            Assert.Equal(9, vloot2.Schepen.Count);
            Assert.Contains(containerschip1, vloot2.Schepen.Values);
            Assert.DoesNotContain(containerschip1,vloot1.Schepen.Values);
        }

        [Fact]
        public void Test_VerplaatsSchip_InValid()
        {
            Assert.Throws<VlootException>(() => rederij.verplaatsSchip(containerschip1, vloot1));
            Assert.Throws<VlootException>(() => rederij.verplaatsSchip(containerschip1, null));
            Assert.Throws<VlootException>(() => rederij.verplaatsSchip(null, vloot2));
            Assert.Throws<VlootException>(() => rederij.verplaatsSchip(null, null));

            Assert.Equal(7, vloot1.Schepen.Count);
        }
    }
}
