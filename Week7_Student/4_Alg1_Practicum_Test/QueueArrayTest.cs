using Alg1_Practicum;
using Alg1_Practicum_Test.TestExtensions;
using Alg1_Practicum_Utils.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Alg1_Practicum_Utils.Exceptions;

namespace Alg1_Practicum_Test
{
    [TestClass]
    [MSTestExtensionsTest]
    public class NawQueueArrayTest : ContextBoundObject
    {
        private NawQueueArray queue { get; set; }

        private NAW naw0 = new NAW("Paul", "De Remise", "Eindhoven");
        private NAW naw1 = new NAW("Martijn", "Dorpstraat", "Oss");
        private NAW naw2 = new NAW("Koen", "Kerkstraat", "Veldhoven");

        #region Setup and Teardown
        [TestInitialize]
        public void QueueArray_Initialize()
        {
            queue = new NawQueueArray(5);
        }
        #endregion

        #region Enqueue Dequeue

        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(7,0.5)]
        [PrintCode("NawQueueArray", "Enqueue")]
        [TestCategory("WS7 - Queue - Array")]
        [TestSummary(@"We maken een lege NawQueueArray aan en roepen er Dequeue op aan. Dit zou null moeten teruggeven.")]
        public void QueueArray_Dequeue_Empty_ShouldReturnNull()
        {
            Assert.IsNull(queue.Dequeue(), "\n\nNawQueueArray.Dequeue(): Een lege queue moet null teruggeven.");
        }

        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(7,1.0)]
        [PrintCode("NawQueueArray", "Enqueue")]
        [TestCategory("WS7 - Queue - Array")]
        [TestSummary(@"We maken een NawQueueArray aan, stoppen er twee NAW's in met Enqueue en halen deze er weer uit met Dequeue. Dit zou het element wat er in is gestopt moeten teruggeven.")]
        public void QueueArray_EnqueueDequeue_ShouldReturnNawQueueArrayd()
        {
            queue.Enqueue(naw0);
            Assert.AreSame(naw0, queue.Dequeue(), "\n\nNawQueueArray.Dequeue(): Er werdt niet het naw teruggegeven wat was geenqueued.");
        }

        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(7,1.0)]
        [PrintCode("NawQueueArray", "Enqueue")]
        [TestCategory("WS7 - Queue - Array")]
        [TestSummary(@"We maken een NawQueueArray aan, stoppen er twee verschillende NAW's in en halen ze er allebei weer uit. Ze zouden in de volgorde dat ze er in zijn gestopt weer uit moeten komen (FIFO).")]
        public void QueueArray_EnqueueTwiceDequeueTwice_ShouldReturnNawQueueArrayd()
        {
            queue.Enqueue(naw0);
            queue.Enqueue(naw2);
            Assert.AreSame(naw0, queue.Dequeue(), "\n\nNawQueueArray.Dequeue(): De NAW die werd teruggegeven is niet de eerste NAW die er in is gestopt.");
            Assert.AreSame(naw2, queue.Dequeue(), "\n\nNawQueueArray.Dequeue(): De NAW die werd teruggegeven is niet de tweede NAW die er in is gestopt.");
        }

        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(7,1.0)]
        [PrintCode("NawQueueArray", "Dequeue")]
        [TestCategory("WS7 - Queue - Array")]
        [TestSummary(@"We maken een NawQueueArray aan, stoppen er een NAW in en proberen er twee uit te halen. De tweede aanroep zou null moeten teruggeven.")]
        public void QueueArray_EnqueueOnceDequeueTwice_ShouldReturnNull()
        {
            queue.Enqueue(naw0);
            queue.Dequeue();
            Assert.IsNull(queue.Dequeue(), "\n\nNawQueueArray.Dequeue(): Bij de tweede aanroep van Dequeue is de queue weer leeg en zou er null teruggegeven moeten worden.");
        }

        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(7,1.0)]
        [PrintCode("NawQueueArray", "Enqueue")]
        [TestCategory("WS7 - Queue - Array")]
        [TestSummary(@"We maken een NawQueueArray met omvang 5 aan en stoppen er 10 NAW's in en halen er in totaal 8 uit. Het resultaat is alleen juist wanneer de warp-arounds van Front en Rear goed gaan.")]
        public void QueueArray_EnqueueDequeueTenItems_ShouldWarpAround()
        {
            // first add 2 items
            queue.Enqueue(naw0);
            queue.Enqueue(naw1);

            // then add and remove 8 more

            queue.Enqueue(naw2);
            queue.Dequeue();

            queue.Enqueue(naw1);
            queue.Dequeue();

            queue.Enqueue(naw2);
            queue.Dequeue();

            queue.Enqueue(naw1);
            queue.Dequeue();

            queue.Enqueue(naw2);
            queue.Dequeue();

            queue.Enqueue(naw0);
            queue.Dequeue();

            queue.Enqueue(naw2);
            queue.Dequeue();

            queue.Enqueue(naw1);
            NAW result = queue.Dequeue();

            Assert.AreEqual(2, queue.Count(), "\n\nDe waarde van count klopt niet na het invoegen van 10 en verwijderen van 8 elementen staat hij op {0} i.p.v. 2.", queue.Count());
            Assert.AreEqual(3, queue.Front, "\n\nDe Front wijst uiteindelijk naar de verkeerde index ({0} i.p.v. 3). Heb je wel aan de wrap-around gedacht ?", queue.Front);
            Assert.AreEqual(4, queue.Rear, "\n\nDe Rear wijst uiteindelijk naar de verkeerde index ({0} i.p.v. 4). Heb je wel aan de wrap-around gedacht ?", queue.Rear);
            Assert.AreEqual(naw0, result, "\n\nHet verkeerde element is terugverkregen bij de laatste Dequeue.");
        }

        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(7,1.0)]
        [PrintCode("NawQueueArray", "Enqueue")]
        [TestCategory("WS7 - Queue - Array")]
        [TestSummary(@"We maken een NawQueueArray met omvang 5 aan en stoppen er 6 NAW's in. Dit past niet in de onderliggende array dus een NawQeueuArrayOutOfBoundsException moet gegooid worden.")]
        public void QueueArray_EnqueueSixItems_ShouldThrow()
        {
            // Arrange
            for (int i = 0; i < 4; i++)
            {
                queue.Enqueue(naw0);
            }

            // Act
            try
            {
                queue.Enqueue(naw1);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(NawQueueArrayOutOfBoundsException),
                    "\n\nNawQueueArray.Enqueue(): Toevoegen van 6e element in een queue met omvang van 5 geeft geen exceptie.");
            }
        }


        #endregion

        #region Count

        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(7,0.5)]
        [PrintCode("NawQueueArray", "Count")]
        [TestCategory("WS7 - Queue - Array")]
        [TestSummary(@"We maken een lege NawQueueArray aan en roepen er Dequeue op aan. Count() zou nog steeds 0 moeten zijn")]
        public void QueueArray_DequeueCount_ShouldReturn0()
        {
            queue.Dequeue();
            Assert.AreEqual(0, queue.Count(), "\n\nNawQueueArray.Count(): Op een lege lijst zou de Count() 0 moeten zijn.");
        }

        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(7,1.0)]
        [PrintCode("NawQueueArray", "Count")]
        [TestCategory("WS7 - Queue - Array")]
        [TestSummary(@"We maken een NawQueueArray aan en stoppen er twee NAW's in. Count() zou 2 moeten zijn")]
        public void QueueArray_EnqueueTwiceCount_ShouldReturn2()
        {
            queue.Enqueue(naw0);
            queue.Enqueue(naw2);
            Assert.AreEqual(2, queue.Count(), "\n\nNawQueueArray.Count(): Een queue met twee elementen zou Count() 2 terug moeten geven.");
        }

        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(7,1.0)]
        [PrintCode("NawQueueArray", "Count")]
        [TestCategory("WS7 - Queue - Array")]
        [TestSummary(@"We maken een NawQueueArray aan en stoppen er twee NAW's in en halen er een uit. Count() zou 1 moeten zijn")]
        public void QueueArray_EnqueueTwiceDequeueCount_ShouldReturn1()
        {
            queue.Enqueue(naw0);
            queue.Enqueue(naw2);
            queue.Dequeue();
            Assert.AreEqual(1, queue.Count(), "\n\nNawQueueArray.Count(): Een queue met een element zou Count() 1 terug moeten geven.");
        }

        #endregion
    }
}
