using Alg1_Practicum;
using Alg1_Practicum_Test.TestExtensions;
using Alg1_Practicum_Utils.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Test
{
    [TestClass]
    [MSTestExtensionsTest]
    public class QueueTest : ContextBoundObject
    {
        private NawQueueLinkedList queue { get; set; }

        private NAW naw = new NAW("Paul", "Dorpstraat", "Eindhoven");
        private NAW naw2 = new NAW("Koen", "Kerkstraat", "Veldhoven");
        
        #region Setup and Teardown
        [TestInitialize]
        public void Queue_Initialize()
        {
            queue = new NawQueueLinkedList();
        }
        #endregion

        #region Enqueue Dequeue
        
        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(7,0.5)]
        [PrintCode("NawQueueLinkedList", "Enqueue")]
        [TestCategory("WS7 - Queue - Linked List")]
        [TestSummary(@"We maken een lege Queue aan en roepen er Dequeue op aan. Dit zou null moeten teruggeven.")]
        public void Queue_Dequeue_Empty_ShouldReturnNull()
        {
            Assert.IsNull(queue.Dequeue(), "\n\nQueue.Dequeue(): Een lege queue moet null teruggeven.");
        }

        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(7,1.0)]
        [PrintCode("NawQueueLinkedList", "Enqueue")]
        [TestCategory("WS7 - Queue - Linked List")]
        [TestSummary(@"We maken een Queue aan, stoppen er twee NAW's in met Enqueue en halen deze er weer uit met Dequeue. Dit zou het element wat er in is gestopt moeten teruggeven.")]
        public void Queue_EnqueueDequeue_ShouldReturnQueued()
        {
            queue.Enqueue(naw);
            Assert.AreSame(naw, queue.Dequeue(), "\n\nQueue.Dequeue(): Er werdt niet het naw teruggegeven wat was geenqueued.");
        }

        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(7,1.0)]
        [PrintCode("NawQueueLinkedList", "Enqueue")]
        [TestCategory("WS7 - Queue - Linked List")]
        [TestSummary(@"We maken een Queue aan, stoppen er twee verschillende NAW's in en halen ze er allebei weer uit. Ze zouden in de volgorde dat ze er in zijn gestopt weer uit moeten komen (FIFO).")]
        public void Queue_EnqueueTwiceDequeueTwice_ShouldReturnQueued()
        {
            queue.Enqueue(naw);
            queue.Enqueue(naw2);
            Assert.AreSame(naw, queue.Dequeue(), "\n\nQueue.Dequeue(): De NAW die werd teruggegeven is niet de eerste NAW die er in is gestopt.");
            Assert.AreSame(naw2, queue.Dequeue(), "\n\nQueue.Dequeue(): De NAW die werd teruggegeven is niet de tweede NAW die er in is gestopt.");
        }

        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(7,1.0)]
        [PrintCode("NawQueueLinkedList", "Dequeue")]
        [TestCategory("WS7 - Queue - Linked List")]
        [TestSummary(@"We maken een Queue aan, stoppen er een NAW in en proberen er twee uit te halen. De tweede aanroep zou null moeten teruggeven.")]
        public void Queue_EnqueueOnceDequeueTwice_ShouldReturnNull()
        {
            queue.Enqueue(naw);
            queue.Dequeue();
            Assert.IsNull(queue.Dequeue(), "\n\nQueue.Dequeue(): Bij de tweede aanroep van Dequeue is de queue weer leeg en zou er null teruggegeven moeten worden.");
        }
        #endregion

        #region Count

        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(7,0.5)]
        [PrintCode("NawQueueLinkedList", "Count")]
        [TestCategory("WS7 - Queue - Linked List")]
        [TestSummary(@"We maken een lege Queue aan en roepen er Dequeue op aan. Count() zou nog steeds 0 moeten zijn")]
        public void Queue_DequeueCount_ShouldReturn0()
        {
            queue.Dequeue();
            Assert.AreEqual(0, queue.Count(), "\n\nQueue.Count(): Op een lege lijst zou de Count() 0 moeten zijn.");
        }

        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(7,1.0)]
        [PrintCode("NawQueueLinkedList", "Count")]
        [TestCategory("WS7 - Queue - Linked List")]
        [TestSummary(@"We maken een Queue aan en stoppen er twee NAW's in. Count() zou 2 moeten zijn")]
        public void Queue_EnqueueTwiceCount_ShouldReturn2()
        {
            queue.Enqueue(naw);
            queue.Enqueue(naw2);
            Assert.AreEqual(2, queue.Count(), "\n\nQueue.Count(): Een queue met twee elementen zou Count() 2 terug moeten geven.");
        }

        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(7,1.0)]
        [PrintCode("NawQueueLinkedList", "Count")]
        [TestCategory("WS7 - Queue - Linked List")]
        [TestSummary(@"We maken een Queue aan en stoppen er twee NAW's in en halen er een uit. Count() zou 1 moeten zijn")]
        public void Queue_EnqueueTwiceDequeueCount_ShouldReturn1()
        {
            queue.Enqueue(naw);
            queue.Enqueue(naw2);
            queue.Dequeue();
            Assert.AreEqual(1, queue.Count(), "\n\nQueue.Count(): Een queue met een element zou Count() 1 terug moeten geven.");
        }
        #endregion
    }
}
