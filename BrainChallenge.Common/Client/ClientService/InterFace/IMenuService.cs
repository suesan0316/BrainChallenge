using System.Collections.Generic;
using BrainChallenge.Common.Client.ClientModel;

namespace BrainChallenge.Common.Client.ClientService.InterFace
{
    interface IMenuService
    {
        Dictionary<string, List<GameModel>> getGameList();
    }
}
