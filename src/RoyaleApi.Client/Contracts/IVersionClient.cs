using System.Threading.Tasks;

namespace RoyaleApi.Client.Contracts
{
    public interface IVersionClient
    {
        Task<ApiResponse> GetVersionResponse();

        Task<string> GetVersion();
    }
}