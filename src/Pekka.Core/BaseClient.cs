using Pekka.Core.Contracts;

namespace Pekka.Core
{
    public abstract class BaseClient
    {
        protected readonly IRestApiClient RestApiClient;

        protected BaseClient(IRestApiClient restApiClient)
        {
            RestApiClient = restApiClient;
        }
    }
}
