using Newtonsoft.Json;

using Pekka.ClashRoyaleApi.Client.Contracts.Models;
using Pekka.Core.JsonConverters;

namespace Pekka.ClashRoyaleApi.Client.Models.PlayerModels
{
    public class PlayerCurrentFavoriteCard : ICardLight
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public int MaxLevel { get; set; }

        [JsonConverter(typeof(CustomConverter<PlayerIconUrl>))]
        public IIconUrl IconUrls { get; set; }
    }
}