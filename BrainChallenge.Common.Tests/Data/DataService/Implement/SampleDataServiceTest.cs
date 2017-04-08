using NUnit.Framework;
using BrainChallenge.Common.Data.DataService.Implement;
using BrainChallenge.Common.Data.Entity.General;
using System.Linq;

namespace BrainChallenge.Common.Tests.Data.DataService.Implement
{
    [TestFixture]
    class SampleDataServiceTest
    {

        private SampleDataService serv;

        [SetUp]
        public void Setup() {
            serv = new SampleDataService();
        }


        [TearDown]
        public void Tear() { }

        [Test]
        public void selectAllTest1()
        {
            var result = serv.select();

            Assert.True(serv.select().Count == TestData.SampleTestData.Count);
        }

        [Test]
        public void selectAllTest2()
        {
            var result = serv.select();

            var selectString = "";
            var testDataString = "";

            result.ForEach(data => selectString += data.ToString());
            TestData.SampleTestData.ForEach(data => testDataString += data.ToString());

            Assert.True(selectString.Equals(testDataString));
        }

        [Test]
        public void selectAndTest1()
        {
            var result = serv.select(TestData.SampleTestData[0]);

            Assert.True(result[0].ToString().Equals(TestData.SampleTestData[0].ToString()));

        }
        [Test]
        public void selectAndTest2()
        {
            var result = serv.select(new SampleEntity { Id = -1, Name = "テスト1" });

            Assert.True(result[0].ToString().Equals(TestData.SampleTestData[1].ToString()));
        }

        [Test]
        public void insertTest1()
        {
            var newData = new SampleEntity { Id = 4, Name = "テスト4" };

            TestData.SampleTestData.Add(newData);

            var result = serv.insert(newData);

            var check = serv.select(newData).First().ToString();

            Assert.True(result && check.Equals(newData.ToString()));
        }
    }
}
