using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NUnit.Framework;
using BrainChallenge.Common.Data.DataService.Implement;
using BrainChallenge.Common.Data.Entity.General;
using System.Runtime.CompilerServices;
using BrainChallenge.Common.Data.Entity.Master;


#if DEBUG
[assembly: InternalsVisibleTo("BrainChallenge.Common")]
#endif

namespace BrainChallenge.Common.Tests.Data.DataService.Implement
{
    class GameTypeMasterServiceTest
    {
        private GameTypeMasterService _serv;

        [SetUp]
        public void Setup()
        {
            _serv = new GameTypeMasterService();
        }

        [TearDown]
        public void Tear() { }

        [Test]
        public void SelectAllTest1()
        {
            Assert.True(_serv.Select().Count == TestData.GameTypeMasterTestData.Count);
        }

        [Test]
        public void SelectAllTest2()
        {
            var result = _serv.Select();

            var selectString = "";
            var testDataString = "";

            result.ForEach(data => selectString += data.ToString());
            TestData.GameTypeMasterTestData.ForEach(data => testDataString += data.ToString());

            Assert.True(selectString.Equals(testDataString));
        }

        [Test]
        public void SelectAndTest1()
        {
            var result = _serv.Select(TestData.GameTypeMasterTestData[0]);

            Assert.True(result[0].ToString().Equals(TestData.GameTypeMasterTestData[0].ToString()));

        }

        [Test]
        public void SelectAndTest2()
        {
            var result = _serv.Select(new GameTypeMasterEntity { GameTypeId = -1, Name = "‹L‰¯—Í" });

            Assert.True(result[0].ToString().Equals(TestData.GameTypeMasterTestData[0].ToString()));
        }

       
    }
}