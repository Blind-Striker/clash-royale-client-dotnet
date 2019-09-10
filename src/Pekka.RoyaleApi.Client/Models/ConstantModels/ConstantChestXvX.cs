using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ConstantChestXvX
    {
        public int[] Thresholds { get; set; }

        public int[] Gold { get; set; }

        public int[] Cards { get; set; }
    }
}