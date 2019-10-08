using Pekka.ClashRoyaleApi.Client.Models.CardModels;
using Pekka.Core.Responses;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pekka.ClashRoyaleApi.Client.Contracts
{
    public interface ICardClient : ICardClientWithApiResponse, ICardClientModel
    {
    }

    public interface ICardClientWithApiResponse
    {
        Task<IApiResponse<PagedCards>> GetCardsResponseAsync();
    }

    public interface ICardClientModel
    {
        Task<PagedCards> GetCardsAsync();
    }
}