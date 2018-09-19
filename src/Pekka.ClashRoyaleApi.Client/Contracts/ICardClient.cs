using System.Threading.Tasks;
using Pekka.ClashRoyaleApi.Client.Models;
using Pekka.Core.Responses;

namespace Pekka.ClashRoyaleApi.Client.Contracts
{
    public interface ICardClient
    {
        Task<ApiResponse<CardList>> GetCardsResponseAsync();
        Task<CardList> GetCardsAsync();
    }
}