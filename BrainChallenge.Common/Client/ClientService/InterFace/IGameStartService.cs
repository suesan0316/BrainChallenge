using BrainChallenge.Common.Client.ClientModel;

namespace BrainChallenge.Common.Client.ClientService.InterFace
{
    internal interface IGameStartService
    {
        GameDetailModel GetGameDetail(int gameId);
    }
}