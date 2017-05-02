using System.Linq;
using System.Runtime.CompilerServices;
using BrainChallenge.Common.Client.ClientService.Implement;
using NUnit.Framework;

#if DEBUG
[assembly: InternalsVisibleTo("BrainChallenge.Common")]
#endif

namespace BrainChallenge.Common.Tests.Client.ClientService.Implement
{
    [TestFixture]
    class MenuServiceTest
    {

        private MenuService _serv;

        [SetUp]
        public void Setup()
        {
            _serv = new MenuService();
        }

        [TearDown]
        public void Tear()
        {
        }

        [Test]
        public void SelectAllTest1()
        {
            var result = _serv.GetGameList();

            Assert.True(result.Count == 4);
        }

        [Test]
        public void SelectAllTest2()
        {
            var gameModelList = _serv.GetGameList();

            var result = true;

            foreach (var gameMaster in TestData.GameMasterTestData)
            {
                var type = TestData.GameTypeMasterTestData.First(data => data.GameTypeId == gameMaster.GameTypeId).Name;

                var targetList = gameModelList[type];

                var target = from record in targetList
                             where 
                             record.GameId == gameMaster.GameId
                             && record.Class.Equals(gameMaster.Class)
                             && record.GameName.Equals(gameMaster.GameName)
                             && record.Icon.Equals(gameMaster.IconImage)
                             select record;

                if (!target.Any()) result = false;
            }

            Assert.True(result);
        }

    }
}