using BrainChallenge.Common.Client.ClientModel;
using BrainChallenge.Common.Data.Connection;

namespace BrainChallenge.Common.Client.ClientService.Implement
{
    public class ServiceIinitializer
    {
        public static void initialize(ServiceInitializeModel init)
        {
            ConnectionProvider.dbPath = init.dbPath;
        }
    }
}
