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
        Task<IApiResponse<List<Card>>> GetCardsResponseAsync();
    }

    public interface ICardClientModel
    {
        Task<List<Card>> GetCardsAsync();
    }
}