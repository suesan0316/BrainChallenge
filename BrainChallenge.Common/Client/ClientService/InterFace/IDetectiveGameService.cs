using BrainChallenge.Common.Client.ClientModel;

namespace BrainChallenge.Common.Client.ClientService.InterFace
{
    interface IDetectiveGameService
    {
        DetectiveGameModel SetUp();
        DetectiveGameModel Process(DetectiveGameModel process);
        GameResultDetailModel Finished(); 
    }
}
