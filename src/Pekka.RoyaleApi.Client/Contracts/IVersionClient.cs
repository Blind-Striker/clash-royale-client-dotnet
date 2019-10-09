using Pekka.Core.Responses;
using Pekka.RoyaleApi.Client.Models.VersionModels;

using System.Threading.Tasks;

namespace Pekka.RoyaleApi.Client.Contracts
{
    public interface IVersionClient : IVersionClientWithResponse, IVersionClientWithModel
    {
    }

    public interface IVersionClientWithResponse
    {
        Task<IApiResponse<Ver>> GetVersionResponseAsync();
    }

    public interface IVersionClientWithModel
    {
        Task<string> GetVersionAsync();
    }
}