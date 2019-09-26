using Pekka.ClashRoyaleApi.Client.Contracts.Models;

namespace Pekka.ClashRoyaleApi.Client.Models.CardModels
{
    public class Card : ICardLight
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public int MaxLevel { get; set; }

        public IIconUrl IconUrls { get; set; }
    }
}