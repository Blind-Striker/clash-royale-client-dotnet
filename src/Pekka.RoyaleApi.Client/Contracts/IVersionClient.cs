using System.Threading.Tasks;
using Pekka.Core.Responses;

namespace Pekka.RoyaleApi.Client.Contracts
{
    public interface IVersionClient : IVersionClientWithResponse, IVersionClientWithModel
    {
    }

    public interface IVersionClientWithResponse
    {
        //Task<IApiResponse> GetVersionResponse();
    }

    public interface IVersionClientWithModel
    {
        Task<string> GetVersion();
    }
}