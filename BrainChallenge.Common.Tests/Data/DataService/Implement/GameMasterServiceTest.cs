using NUnit.Framework;
using BrainChallenge.Common.Data.DataService.Implement;
using BrainChallenge.Common.Data.Entity.General;
using System.Linq;
using System.Runtime.CompilerServices;
using BrainChallenge.Common.Data.Entity.Master;

#if DEBUG
[assembly: InternalsVisibleTo("BrainChallenge.Common")]
#endif

namespace BrainChallenge.Common.Tests.Data.DataService.Implement
{
    [TestFixture]
    class GameMasterServiceTest
    {

        private GameMasterService _serv;

        [SetUp]
        public void Setup()
        {
            _serv = new GameMasterService();
        }


        [TearDown]
        public void Tear()
        {
        }

        [Test]
        public void SelectAllTest1()
        {
            Assert.True(_serv.Select().Count == TestData.GameMasterTestData.Count);
        }
        [Test]
        public void SelectAllTest2()
        {
            var result = _serv.Select();

            var selectString = "";
            var testDataString = "";

            result.ForEach(data => selectString += data.ToString());
            TestData.GameMasterTestData.ForEach(data => testDataString += data.ToString());

            Assert.True(selectString.Equals(testDataString));
        }

        [Test]
        public void SelectAndTest1()
        {
            var result = _serv.Select(TestData.GameMasterTestData[0]);

            Assert.True(result[0].ToString().Equals(TestData.GameMasterTestData[0].ToString()));

        }
        [Test]
        public void SelectAndTest2()
        {
            var result = _serv.Select(new GameMasterEntity { GameId = 2, GameName = "記憶力ゲーム3", GameTypeId = 0, ScoreType = 0, TitleImage = "memory3_game_title", IconImage = "memory3_game_icon", Class = "MemoryGame3Controller", GameTime = 3L });

            Assert.True(result[0].ToString().Equals(TestData.GameMasterTestData[2].ToString()));
        }
    }
}