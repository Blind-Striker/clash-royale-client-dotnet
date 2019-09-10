using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ConstantChestOrder
    {
        public List<string> MainCycle { get; set; }

        public ConstantQuestChest[] QuestEarlygame1 { get; set; }

        public ConstantQuestChest[] QuestEarlygame2 { get; set; }

        public ConstantQuestChest[] QuestLategame1 { get; set; }

        public ConstantQuestChest[] QuestLategame2 { get; set; }

        public ConstantQuestChest[] QuestLategame3 { get; set; }

        public ConstantQuestChest[] QuestLategame4 { get; set; }

        public ConstantQuestChest[] QuestLategame5 { get; set; }

        public ConstantQuestChest[] QuestLategame6 { get; set; }

        public ConstantQuestChest[] QuestLategame7 { get; set; }

        public ConstantQuestChest[] QuestLategame8 { get; set; }

        public ConstantQuestChest[] QuestLategame9 { get; set; }

        public ConstantQuestChest[] QuestLategame10 { get; set; }

        public ConstantQuestChest[] QuestArena3Super { get; set; }
    }
}