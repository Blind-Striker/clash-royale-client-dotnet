using System.Threading.Tasks;
using RoyaleApi.Client.Responses;

namespace RoyaleApi.Client.Contracts
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