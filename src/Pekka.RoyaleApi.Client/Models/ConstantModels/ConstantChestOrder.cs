using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ConstantChestOrder
    {
        public List<string> MainCycle { get; set; }

        public List<ConstantQuestChest> QuestEarlygame1 { get; set; }

        public List<ConstantQuestChest> QuestEarlygame2 { get; set; }

        public List<ConstantQuestChest> QuestLategame1 { get; set; }

        public List<ConstantQuestChest> QuestLategame2 { get; set; }

        public List<ConstantQuestChest> QuestLategame3 { get; set; }

        public List<ConstantQuestChest> QuestLategame4 { get; set; }

        public List<ConstantQuestChest> QuestLategame5 { get; set; }

        public List<ConstantQuestChest> QuestLategame6 { get; set; }

        public List<ConstantQuestChest> QuestLategame7 { get; set; }

        public List<ConstantQuestChest> QuestLategame8 { get; set; }

        public List<ConstantQuestChest> QuestLategame9 { get; set; }

        public List<ConstantQuestChest> QuestLategame10 { get; set; }

        public List<ConstantQuestChest> QuestArena3Super { get; set; }
    }
}