using System;
using NUnit.Framework;
using BrainChallenge.Common.Data.DataService.Implement;
using BrainChallenge.Common.Data.Entity.General;
using System.Linq;
using System.Runtime.CompilerServices;

#if DEBUG
[assembly: InternalsVisibleTo("BrainChallenge.Common")]
#endif

namespace BrainChallenge.Common.Tests.Data.DataService.Implement
{
    [TestFixture]
    class ScoreServiceTest
    {

        private ScoreService _serv;

        [SetUp]
        public void Setup() {
            _serv = new ScoreService();
        }


        [TearDown]
        public void Tear() { }

        [Test]
        public void SelectAllTest1()
        {
            Assert.True(_serv.Select().Count == TestData.ScoreTestData.Count);
        }

        [Test]
        public void SelectAllTest2()
        {
            var result = _serv.Select();

            var selectString = "";
            var testDataString = "";

            result.ForEach(data => selectString += data.ToString());
            TestData.ScoreTestData.ForEach(data => testDataString += data.ToString());

            Assert.True(selectString.Equals(testDataString));
        }

        [Test]
        public void SelectAndTest1()
        {
            var result = _serv.Select(TestData.ScoreTestData[0]);

            Assert.True(result[0].ToString().Equals(TestData.ScoreTestData[0].ToString()));

        }
        [Test]
        public void SelectAndTest2()
        {
            var result = _serv.Select(new ScoreEntity() { GameId = -1, Score = 600 });

            Assert.True(result[0].ToString().Equals(TestData.ScoreTestData[7].ToString()));
        }

        [Test]
        public void InsertTest1()
        {
            var newData = new ScoreEntity() { GameId = 4, Score = 2000, RegistDate = DateTime.Now.AddDays(3)};

            TestData.ScoreTestData.Add(newData);

            var result = _serv.Insert(newData);

            var check = _serv.Select(newData).First().ToString();

            Assert.True(result && check.Equals(newData.ToString()));
        }
    }
}
