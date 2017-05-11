using System.Collections.Generic;
using System.Linq;
using BrainChallenge.Common.Client.ClientModel;
using BrainChallenge.Common.Client.ClientService.InterFace;
using BrainChallenge.Common.Data.DataService.Implement;
using BrainChallenge.Common.Data.Entity.General;
using BrainChallenge.Common.Data.Entity.Master;

namespace BrainChallenge.Common.Client.ClientService.Implement
{
    public class GameStartService : IGameStartService
    {
        public GameDetailModel GetGameDetail(int gameId)
        {
            var gameMasterService = new GameMasterService();
            var scoreService = new ScoreService();


            var gameInfo = gameMasterService
                .Select(new GameMasterEntity {GameId = gameId, GameTypeId = -1, ScoreType = -1, GameTime = -1})
                .First();

            var score = scoreService.Select(new ScoreEntity {GameId = gameId, Score = -1});

            List<int> setScore = null;

            if (score != null)
            {

                setScore = gameInfo.ScoreType == 0
                    ? score.OrderByDescending(target => target.Score).Select(targert => targert.Score).Take(5).ToList()
                    : score.OrderBy(target => target.Score).Select(targert => targert.Score).Take(5).ToList();
            }

            var gameDetailModel = new GameDetailModel
            {
                Class = gameInfo.Class,
                GameId = gameId,
                GameName = gameInfo.GameName,
                Icon = gameInfo.IconImage,
                Score = setScore,
                Title = gameInfo.TitleImage
            };

            return gameDetailModel;
        }
    }
}