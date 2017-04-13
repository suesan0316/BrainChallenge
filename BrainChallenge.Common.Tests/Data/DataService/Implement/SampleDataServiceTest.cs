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
    class SampleDataServiceTest
    {

        private SampleDataService _serv;

        [SetUp]
        public void Setup() {
            _serv = new SampleDataService();
        }


        [TearDown]
        public void Tear() { }

        [Test]
        public void SelectAllTest1()
        {
            Assert.True(_serv.Select().Count == TestData.SampleTestData.Count);
        }

        [Test]
        public void SelectAllTest2()
        {
            var result = _serv.Select();

            var selectString = "";
            var testDataString = "";

            result.ForEach(data => selectString += data.ToString());
            TestData.SampleTestData.ForEach(data => testDataString += data.ToString());

            Assert.True(selectString.Equals(testDataString));
        }

        [Test]
        public void SelectAndTest1()
        {
            var result = _serv.Select(TestData.SampleTestData[0]);

            Assert.True(result[0].ToString().Equals(TestData.SampleTestData[0].ToString()));

        }
        [Test]
        public void SelectAndTest2()
        {
            var result = _serv.Select(new SampleEntity { Id = -1, Name = "テスト1" });

            Assert.True(result[0].ToString().Equals(TestData.SampleTestData[1].ToString()));
        }

        [Test]
        public void InsertTest1()
        {
            var newData = new SampleEntity { Id = 4, Name = "テスト4" };

            TestData.SampleTestData.Add(newData);

            var result = _serv.Insert(newData);

            var check = _serv.Select(newData).First().ToString();

            Assert.True(result && check.Equals(newData.ToString()));
        }
    }
}
