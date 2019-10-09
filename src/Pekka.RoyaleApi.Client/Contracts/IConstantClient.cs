using Pekka.Core.Responses;
using Pekka.RoyaleApi.Client.Models.ConstantModels;

using System.Threading.Tasks;

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