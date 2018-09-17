using System.Threading.Tasks;
using Pekka.RoyaleApi.Client.Responses;

namespace Pekka.RoyaleApi.Client.Contracts
{
    public interface IVersionClient : IVersionClientWithResponse, IVersionClientWithModel
    {
    }

    public interface IVersionClientWithResponse
    {
        Task<ApiResponse> GetVersionResponse();
    }

    public interface IVersionClientWithModel
    {
        Task<string> GetVersion();
    }
}