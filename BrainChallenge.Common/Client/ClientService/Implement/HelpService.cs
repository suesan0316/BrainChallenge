using System.Collections.Generic;
using System.Linq;
using BrainChallenge.Common.Client.ClientModel;
using BrainChallenge.Common.Client.ClientService.InterFace;
using BrainChallenge.Common.Data.DataService.Implement;
using BrainChallenge.Common.Data.Entity.Master;
using BrainChallenge.Common.Util.Extentions;

namespace BrainChallenge.Common.Client.ClientService.Implement
{
    public class HelpService : IHelpService
    {
        public GameHelpModel GetHelpModel(int gameId)
        {
            var gameMasterService = new GameMasterService();
            var helpMasterService = new HelpMasterService();

            var gameInfo = gameMasterService.Select(
                    new GameMasterEntity {GameId = gameId, GameTypeId = -1, GameTime = -1, ScoreType = -1})
                .First();

            var helpInfo = helpMasterService.Select(new HelpMasterEntity {GameId = gameId, HelpIndex = -1})
                .OrderBy(data => data.HelpIndex);

            var helpModels = new List<HelpModel>();

            helpInfo.ForEach(help => helpModels.Add(new HelpModel {Explain = help.Explain, HelpImage = help.Image}));

            return new GameHelpModel {GameId = gameId, GameName = gameInfo.GameName, Help = helpModels};
        }
    }
}