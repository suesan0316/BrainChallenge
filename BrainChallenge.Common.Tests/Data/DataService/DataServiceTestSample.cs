using System;
using NUnit.Framework;
using BrainChallenge.Common.Data.Service.Implement;

namespace BrainChallenge.Common.Tests.Data.DataService
{
    [TestFixture]
    public class DataServiceTestSample
    {

        [SetUp]
        public void Setup() { }


        [TearDown]
        public void Tear() { }

        [Test]
        public void Pass()
        {
            GameTypeMasterService serv = new GameTypeMasterService();

            Console.WriteLine("test1");
            Assert.True(serv.select().Count==4);
        }

       /* [Test]
        public void Fail()
        {
            //Assert.False(true);
        }

        [Test]
        [Ignore("another time")]
        public void Ignore()
        {
            //Assert.True(false);
        }

        [Test]
        public void Inconclusive()
        {
            //Assert.Inconclusive("Inconclusive");
        }
        */
    }
}