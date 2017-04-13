using BrainChallenge.Common.Client.ClientModel;
using BrainChallenge.Common.Data.Connection;

namespace BrainChallenge.Common.Client.ClientService.Implement
{
    public class ServiceIinitializer
    {
        public static void Initialize(ServiceInitializeModel init)
        {
            ConnectionProvider.DbPath = init.DbPath;
        }
    }
}
