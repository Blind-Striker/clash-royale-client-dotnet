using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ConstantChestXvX
    {
        public List<int> Thresholds { get; set; }

        public List<int> Gold { get; set; }

        public List<int> Cards { get; set; }
    }
}