using System.Threading.Tasks;

using Pekka.Core.Responses;
using Pekka.RoyaleApi.Client.Models.ConstantModels;

namespace Pekka.RoyaleApi.Client.Contracts
{
    public interface IConstantClient : IConstantClientWithApiResponse, IConstantClientWithModel
    {
    }

    public interface IConstantClientWithApiResponse
    {
        Task<IApiResponse<Constants>> GetConstantsResponseAsync();
    }

    public interface IConstantClientWithModel
    {
        Task<Constants> GetConstantsAsync();
    }
}