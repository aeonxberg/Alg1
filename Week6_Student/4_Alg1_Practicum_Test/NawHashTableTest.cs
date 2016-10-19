using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Alg1_Practicum;
using Alg1_Practicum_Test.Utils;
using Alg1_Practicum_Utils.Exceptions;
using Alg1_Practicum_Utils.Models;
using System.Linq;
using System.Diagnostics;
using Alg1_Practicum_Utils.Logging;
using Alg1_Practicum_Test.TestExtensions;
using Alg1_Practicum_Utils;


namespace Alg1_Practicum_Test
{
    [TestClass]
    [MSTestExtensionsTest]
    public class NawHashTableTest : ContextBoundObject
    {
        private NAW naw0 = new NAW("Koen", "Kerkstraat", "Veldhoven");
        private NAW naw1 = new NAW("Paul", "Remise", "Eindhoven");
        private NAW naw2 = new NAW("Martijn", "Eemhof", "Den Bosch");
        private NAW naw3 = new NAW("Jeroen", "Dorpsstraat", "Veghel");

        private NAW naw4 = new NAW("Koen", "Schans", "Rosmalen");
        private NAW naw5 = new NAW("Paul", "Weelde", "Oss");
        private NAW naw6 = new NAW("Martijn", "Duivenhof", "Breda");
        private NAW naw7 = new NAW("Jeroen", "Strijp-S", "Eindhoven");

        private NAW naw8 = new NAW("Stijn", "Plantsoen", "Vught");
        private NAW naw9 = new NAW("Lesley", "Pad", "Waalwijk");

        #region Setup and Teardown
        [TestInitialize]
        public void NawHashTable_TestInitialize()
        {
            Logger.Instance.ClearLog();
        }

        [TestCleanup]
        public void NawHashTable_TestCleanup()
        {
        }
        #endregion

        #region Add
        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(6, 1.0)]
        [TestCategory("WS6 - HashTable")]
        [PrintCode("NawHashTable", "Add")]
        [TestSummary(@"We maken een NawHashTable met een capaciteit van 10 en voegen er een NAW aan toe. Deze moet worden toegevoegd in de array op plek abs(hashcode % 10).")]
        public void NawHashTable_Add_ShouldAddToArray()
        {
            // Arrange
            NawHashTable hashtable = new NawHashTable(10);
            int hash = (naw0.Naam.GetHashCode() % 10);

            bool result = hashtable.Add(naw0);
            hashtable.Show();

            Assert.IsTrue(result, "De returnwaarde geeft aan dat het element niet is toegevoegd ?");
            var setters = Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.SET).ToArray();
            Assert.AreEqual(1, hashtable.Count, "\n\nNawHashTable.Add(): Count geeft niet juiste aantal items terug.");
            Assert.AreEqual(1, setters.Count(), "\n\nNawHashTable.Add(): Bij in toevoegen van 1 item aan een lege hashtable zou maar 1 index moeten worden beschreven.");
            Assert.AreEqual(4, setters.First().Index1, "\n\nNawHashTable.Add(): De GetHashCode van de naam in de NAW is {0}. De absolute waarde hiervan modulo 10 is 4. Dit is de index waarop de waarde moet worden gezet i.p.v. op {1}.", hash, setters.First().Index1);
        }
        
                [TestMethod]
                [Timeout(3000)]
                [AantalPuntenAlsSlaagt(6,1.0)]
                [TestCategory("WS6 - HashTable")]
                [PrintCode("NawHashTable", "Add")]
                [TestSummary(@"We maken een NawHashTable met een capaciteit van 10 en voegen er twee NAW's aan toe met dezelfde hashcode. De tweede zou een plek verder moeten komen te staan")]
                public void NawHashTable_Add_Twice_ShouldDoLinearProbing()
                {
                    NawHashTable hashtable = new NawHashTable(10);

                    hashtable.Add(naw0);
                    hashtable.Add(naw0);
                    hashtable.Show();

                    var setters = Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.SET).ToArray();
                    Assert.AreEqual(2, setters.Count(), "\n\nNawHashTable.Add(): Er zouden twee elementen toegevoegd moeten zijn aan de array");
                    Assert.AreEqual(5, setters[1].Index1, "\n\nNawHashTable.Add(): De eerste NAW wordt op plek 4 gezet, de tweede zou op plek 5 moeten komen");
                }
        
                [TestMethod]
                [Timeout(3000)]
                [AantalPuntenAlsSlaagt(6,1.0)]
                [TestCategory("WS6 - HashTable")]
                [PrintCode("NawHashTable", "Add")]
                [TestSummary(@"We maken een NawHashTable met een capaciteit van 10 en voegen er drie NAW's aan toe met dezelfde hashcode. De derde zou via linear probing aan het begin van de array moeten komen te staan.")]
                public void NawHashTable_Add_Thrice_LinearProbingShouldWrap()
                {
                    NawHashTable hashtable = new NawHashTable(10);

                    hashtable.Add(naw2);
                    hashtable.Add(naw2);
                    hashtable.Add(naw2);

                    hashtable.Show();
                    var setters = Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.SET).ToArray();
                    Assert.AreEqual(3, setters.Count(), "\n\nNawHashTable.Add(): Er zouden twee elementen toegevoegd moeten zijn aan de array");
                    Assert.AreEqual(0, setters[2].Index1, "\n\nNawHashTable.Add(): De eerste NAW wordt op plek 8 gezet, de tweede op 9. De derde moet op plek 0 komen te staan.");
                }
        
                [TestMethod]
                [Timeout(3000)]
                [AantalPuntenAlsSlaagt(6,1.0)]
                [TestCategory("WS6 - HashTable")]
                [PrintCode("NawHashTable", "Add")]
                [TestSummary(@"We maken een NawHashTable met een capaciteit van 10 en voegen er tien NAW's aan toe. Deze zouden allemaal een plekje in de array moeten krijgen.")]
                public void NawHashTable_Add_TenTimes_ShouldFillArray()
                {
                    NawHashTable hashtable = new NawHashTable(10);
                    /*
                    for (int i = 0; i < 10; i++)
                    {
                        hashtable.Add(i % 2 == 0 ? naw0 : naw1);
                    }*/
                    hashtable.Add(naw0);
                    hashtable.Add(naw1);
                    hashtable.Add(naw2);
                    hashtable.Add(naw3);
                    hashtable.Add(naw4);
                    hashtable.Add(naw5);
                    hashtable.Add(naw6);
                    hashtable.Add(naw7);
                    hashtable.Add(naw8);
                    hashtable.Add(naw9);

                    var setters = Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.SET).ToArray();
                    Assert.AreEqual(10, setters.Count(), "\n\nNawHashTable.Add(): Er zouden precies 10 elementen gevuld moeten zijn");
                }
        
                [TestMethod]
                [Timeout(3000)]
                [AantalPuntenAlsSlaagt(6,1.0)]
                [TestCategory("WS6 - HashTable")]
                [PrintCode("NawHashTable", "Add")]
                [TestSummary(@"We maken een NawHashTable met een capaciteit van 10 en voegen er elf toe. De elfde zou genegeerd moeten worden.")]
                public void NawHashTable_Add_ElevenTimes_ShouldIgnoreLast()
                {
                    NawHashTable hashtable = new NawHashTable(10);

                    for (int i = 0; i < 10; i++)
                    {
                        hashtable.Add(i % 2 == 0 ? naw0 : naw1);
                    }
                    Logger.Instance.ClearLog();

                    // Elfde keer
                    bool result = hashtable.Add(naw2);

                    Assert.IsFalse(result, "De returnwaarde geeft niet aan dat het element niet kon worden toegevoegd");
                    var setters = Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.SET).ToArray();
                    Assert.AreEqual(0, setters.Count(), "\n\nNawHashTable.Add(): Er wordt een element in de array gezet terwijl deze al vol is.");
                }
                #endregion

        #region Find

                [TestMethod]
                [Timeout(3000)]
                [AantalPuntenAlsSlaagt(6, 1.0)]
                [TestCategory("WS6 - HashTable")]
                [PrintCode("NawHashTable", "Find")]
                [TestSummary(@"We maken een NawHashTable met een capaciteit van 10 en voegen er een NAW aan toe. Deze moet daarna weer kunnen worden teruggevonden door Find.")]
                public void NawHashTable_Find_ShouldFindNawAddedToArray()
                {
                    // Arrange
                    NawHashTable hashtable = new NawHashTable(10);
                    hashtable.Add(naw0);
                    Logger.Instance.ClearLog();

                    // Act
                    NAW nawFound = hashtable.Find(naw0.Naam);

                    // Assert
                    Assert.IsTrue(nawFound != null, "De returnwaarde is leeg. Het element is dus onterecht niet correct gevonden ?");
                    var getters = Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.GET).ToArray();
                    
                    Assert.AreEqual(1, getters.Count(), "\n\nNawHashTable.Find(): Bij in zoeken zijn meerdere indexen in de array van de hashtable gelezen terwijl er maar 1 element in zit.");
                    Assert.IsTrue(nawFound.CompareTo(naw0) == 0, "\n\nNawHashTable.Find(): Het NAW object dat wordt teruggeven is anders dan de NAW die aan de hashtable was toegevoegd.");
                }


                [TestMethod]
                [Timeout(3000)]
                [AantalPuntenAlsSlaagt(6, 1.0)]
                [TestCategory("WS6 - HashTable")]
                [PrintCode("NawHashTable", "Find")]
                [TestSummary(@"We maken een NawHashTable met een capaciteit van 10 en voegen er een aantal NAW's aan toe. Daarna wordt er gezocht op een naam die niet in de hashtable voorkomt.")]
                public void NawHashTable_Find_ShouldNotFindNawNotAddedToArray()
                {
                    // Arrange
                    NawHashTable hashtable = new NawHashTable(10);
                    hashtable.Add(naw0);
                    hashtable.Add(naw1);
                    hashtable.Add(naw2);
                    hashtable.Add(naw3);
                    Logger.Instance.ClearLog();

                    // Act
                    NAW nawFound = hashtable.Find(naw9.Naam);

                    // Assert
                    Assert.IsTrue(nawFound == null, "De returnwaarde is niet leeg ? Er is dus onterecht een element gevonden ?");
                    var getters = Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.GET).ToArray();

                    Assert.IsTrue(getters.Count() >= 1, "\n\nNawHashTable.Find(): Er worden helemaal geen indexen bekeken. Zoek je wel in je array ?");
                }

                [TestMethod]
                [Timeout(3000)]
                [AantalPuntenAlsSlaagt(6, 1.0)]
                [TestCategory("WS6 - HashTable")]
                [PrintCode("NawHashTable", "Find")]
                [TestSummary(@"We maken een NawHashTable met een capaciteit van 10 en voegen er een aantal NAW's aan toe. Enkele daarvan hebben dezelfde naam. Find zou altijd de eerste NAW die voldoet aan de key moeten teruggeven.")]
                public void NawHashTable_Find_ShouldFindFirstOccurences()
                {
                    // Arrange
                    NawHashTable hashtable = new NawHashTable(10);
                    hashtable.Add(naw0);
                    hashtable.Add(naw1);
                    hashtable.Add(naw2);
                    hashtable.Add(naw3);
                    hashtable.Add(naw4);
                    hashtable.Add(naw5);
                    hashtable.Add(naw6);
                    hashtable.Add(naw7);
                    hashtable.Add(naw8);
                    hashtable.Add(naw9);
                    Logger.Instance.ClearLog();

                    // Act
                    NAW nawFound4 = hashtable.Find(naw4.Naam);
                    NAW nawFound5 = hashtable.Find(naw5.Naam);
                    NAW nawFound6 = hashtable.Find(naw6.Naam);
                    NAW nawFound7 = hashtable.Find(naw7.Naam);

                    // Assert
                    Assert.IsTrue(nawFound4 != null && nawFound5 != null && nawFound6 !=null && nawFound7 != null, "Een of meerdere elementen zijn onterecht niet gevonden.");
                    Assert.IsTrue(nawFound4.CompareTo(naw0) == 0, "Voor {0} is niet de eerste gevonden.", naw0.Naam);
                    Assert.IsTrue(nawFound5.CompareTo(naw1) == 0, "Voor {0} is niet de eerste gevonden.", naw0.Naam);
                    Assert.IsTrue(nawFound6.CompareTo(naw2) == 0, "Voor {0} is niet de eerste gevonden.", naw0.Naam);
                    Assert.IsTrue(nawFound7.CompareTo(naw3) == 0, "Voor {0} is niet de eerste gevonden.", naw0.Naam);
                }
                
                #endregion

    }
}
