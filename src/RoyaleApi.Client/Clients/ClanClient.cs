using RoyaleApi.Client.Contracts;

namespace RoyaleApi.Client.Clients
{
    public class ClanClient : IClanClient
    {
        private readonly IRoyaleApiClient _royaleApiClient;

        public ClanClient(IRoyaleApiClient royaleApiClient)
        {
            _royaleApiClient = royaleApiClient;
        }
    }
}
