using BrainChallenge.Common.Client.ClientService.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrainChallenge.Common.Client.ClientModel;
using BrainChallenge.Common.Data.DataService.Implement;

namespace BrainChallenge.Common.Client.ClientService.Implement
{
    class DetectiveGameService : IDetectiveGameService
    {

        /// <summary>
        /// 現在のレベル
        /// </summary>
       private  int LEVEL;

        /// <summary>
        /// 現在の失敗回数
        /// </summary>
        private int FailedCount;

        /// <summary>
        /// 現在のスコア
        /// </summary>
        private long Score;

        private readonly DetectiveGameMasterService _detectiveGameMasterService = new DetectiveGameMasterService();

        public GameResultDetailModel Finished()
        {
            throw new NotImplementedException();
        }

        public DetectiveGameModel Process(DetectiveGameModel process)
        {
            throw new NotImplementedException();
        }

        public DetectiveGameModel SetUp()
        {
            throw new NotImplementedException();
        }
    }
}
