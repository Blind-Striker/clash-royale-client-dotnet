using Pekka.ClashRoyaleApi.Client.Models;
using Pekka.Core.Responses;
using System.Threading.Tasks;

namespace Pekka.ClashRoyaleApi.Client.Contracts
{
    public interface ICardClient
    {
        Task<IApiResponse<CardList>> GetCardsResponseAsync();

        Task<CardList> GetCardsAsync();
    }
}