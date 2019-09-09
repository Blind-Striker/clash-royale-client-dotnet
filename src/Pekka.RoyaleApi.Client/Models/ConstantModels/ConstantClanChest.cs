using Newtonsoft.Json;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    public class ConstantClanChest
    {
        [JsonProperty("1v1")] public ConstantChestXvX OneVOne { get; set; }

        [JsonProperty("2v2")] public ConstantChestXvX TwoVTwo { get; set; }
    }
}