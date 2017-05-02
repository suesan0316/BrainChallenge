using System.Collections.Generic;
using BrainChallenge.Common.Client.ClientModel;
using BrainChallenge.Common.Client.ClientService.InterFace;
using BrainChallenge.Common.Data.DataService.Implement;
using BrainChallenge.Common.Data.Entity.Master;
using BrainChallenge.Common.Util.Extentions;

namespace BrainChallenge.Common.Client.ClientService.Implement
{
    public class MenuService : IMenuService
    {
        public Dictionary<string, List<GameModel>> GetGameList()
        {
            var gameTypeMasterService = new GameTypeMasterService();
            var gameMasterService = new GameMasterService();

            var result = new Dictionary<string, List<GameModel>>();

            var gameTypeList = gameTypeMasterService.Select();

            foreach (var gameType in gameTypeList)
            {
                var gameMasterList = gameMasterService.Select(
                    new GameMasterEntity
                    {
                        GameId = -1,
                        GameTypeId = gameType.GameTypeId,
                        ScoreType = -1,
                        GameTime = -1
                    });

                var gameModelList = new List<GameModel>();

                gameMasterList.ForEach(data => gameModelList.Add(
                    new GameModel
                    {
                        GameId = data.GameId,
                        GameName = data.GameName,
                        Icon = data.IconImage,
                        Class = data.Class
                    }));

                result.Add(gameType.Name, gameModelList);
            }

            return result;
        }
    }
}