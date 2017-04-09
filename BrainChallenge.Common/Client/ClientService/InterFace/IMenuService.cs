using BrainChallenge.Common.Client.ClientModel;
using System.Collections.Generic;

namespace BrainChallenge.Common.Client.ClientService.InterFace
{
    interface IMenuService
    {
        Dictionary<string, List<GameModel>> getGameList();
    }
}
