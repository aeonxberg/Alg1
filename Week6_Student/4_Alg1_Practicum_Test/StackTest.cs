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
    public class StackTest : ContextBoundObject
    {
        private Stack stack { get; set; }
        
        #region Setup and Teardown
        [TestInitialize]
        public void Stack_Initialize()
        {
            stack = new Stack();
        }
        #endregion

        #region Push Pop
        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(6,1.0)]
        [PrintCode("Stack", "Pop")]
        [TestCategory("WS6 - Stack")]
        [TestSummary(@"We maken een lege Stack aan en roepen pop() aan. Dit zou null moeten teruggeven.")]
        public void Stack_Pop_Empty_ShouldReturnNull()
        {
            Assert.IsNull(stack.Pop(), "\n\nStack.pop(): Een lege stack moet null teruggeven.");
        }

        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(6,1.0)]
        [PrintCode("Stack", "Pop")]
        [TestCategory("WS6 - Stack")]
        [TestSummary(@"We maken een Stack aan en roepen deze aan met push(""test""). De aanroep van pop() moet deze waarde weer teruggeven.")]
        public void Stack_PushPop_ShouldReturnPushed()
        {
            stack.Push("test");

            Assert.AreEqual("test", stack.Pop(), "\n\nStack.pop(): Een stack pop() moet teruggeven wat met push() is gegeven.");
        }

        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(6,1.0)]
        [PrintCode("Stack", "Pop")]
        [TestCategory("WS6 - Stack")]
        [TestSummary(@"We maken een Stack aan en roepen deze aan met push(""test1"") en push(""test2""). De pop methode moet deze waardes in de volgorde ""test2"", ""test1"" weer teruggeven")]
        public void Stack_PushPushPopPop_ShouldReturnPushed()
        {
            stack.Push("test1");
            stack.Push("test2");

            Assert.AreEqual("test2", stack.Pop(), "\n\nStack.pop(): de string 'test2' was als laatste in de stack gepusht. Dit moet dan ook bij de eerste aanroep van pop() weer worden teruggegeven.");
            Assert.AreEqual("test1", stack.Pop(), "\n\nStack.pop(): de string 'test1' werd als een na laatste gepusht. Dit moet bij de tweede aanroep van pop() worden teruggegeven.");
            Assert.AreEqual(null, stack.Pop(), "\n\nStack.pop(): Er zijn twee elementen gepusht en twee elementen gepopt. Daarna zou de stack bij een volgende aanroep van pop() null moeten teruggeven.");
        }
        #endregion

        #region IsEmpty
        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(6,1.0)]
        [PrintCode("Stack", "IsEmpty")]
        [TestCategory("WS6 - Stack")]
        [TestSummary(@"We maken een lege stack aan en roepen er IsEmpty() op aan. Deze zou true moeten returnen.")]
        public void Stack_IsEmpty_EmptyStack_ShouldReturnTrue()
        {
            Assert.IsTrue(stack.IsEmpty(), "\n\nStack.IsEmpty(): Op de lege stack zou IsEmpty true moeten returnen.");
        }

        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(6,1.0)]
        [PrintCode("Stack", "IsEmpty")]
        [TestCategory("WS6 - Stack")]
        [TestSummary(@"We maken een lege stack aan, pushen en poppen een element en roepen er IsEmpty() op aan. Deze zou true moeten returnen.")]
        public void Stack_IsEmpty_PushPop_ShouldReturnTrue()
        {
            stack.Push("test");
            stack.Pop();

            Assert.IsTrue(stack.IsEmpty(), "\n\nStack.IsEmpty(): Na een push en een pop is de stack weer leeg en zou IsEmpty true moeten returnen.");
        }

        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(6,1.0)]
        [PrintCode("Stack", "IsEmpty")]
        [TestCategory("WS6 - Stack")]
        [TestSummary(@"We maken een stack aan en pushen er een element in. IsEmpty() zou dan false moeten returnen.")]
        public void Stack_IsEmpty_Push_ShouldReturnFalse()
        {
            stack.Push("test1");

            Assert.IsFalse(stack.IsEmpty(), "\n\nStack.IsEmpty(): Na een push zit er iets in de Stack, IsEmpty() is dan false.");
        }
        #endregion
    }
}
