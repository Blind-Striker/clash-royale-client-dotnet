using System.Collections.Generic;

using Pekka.ClashRoyaleApi.Client.Models;
using Pekka.Core.Responses;

using System.Threading.Tasks;

using Pekka.ClashRoyaleApi.Client.Models.CardModels;

namespace Pekka.ClashRoyaleApi.Client.Contracts
{
    public interface ICardClient : ICardClientWithApiResponse, ICardClientModel
    {
    }

    public interface ICardClientWithApiResponse
    {
        Task<IApiResponse<List<Card>>> GetCardsResponseAsync();
    }

    public interface ICardClientModel
    {
        Task<List<Card>> GetCardsAsync();
    }
}