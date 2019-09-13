using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pekka.ClashRoyaleApi.Client.Contracts.Models;
using Pekka.Core.JsonConverters;

namespace Pekka.ClashRoyaleApi.Client.Models.PlayerModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PlayerBattleLogCard : ICard
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public int Level { get; set; }

        public int MaxLevel { get; set; }

        public int Count { get; set; }

        [JsonConverter(typeof(CustomConverter<PlayerBattleLogIconUrl>))]
        public IIconUrl IconUrls { get; set; }
    }
}