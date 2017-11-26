using BrainChallenge.Common.Client.ClientModel;

namespace BrainChallenge.Common.Client.ClientService.InterFace
{
    interface IHelpService
    {
        GameHelpModel GetHelpModel(int gameId);
    }
}
