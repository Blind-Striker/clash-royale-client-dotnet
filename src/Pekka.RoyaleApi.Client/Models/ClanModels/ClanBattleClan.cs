using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pekka.RoyaleApi.Client.Contracts.Models;

namespace Pekka.RoyaleApi.Client.Models.ClanModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ClanBattleClan : IModel
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public ClanBattleBadge Badge { get; set; }

        public override string ToString()
        {
            return $"{Tag} - {Name}";
        }
    }
}