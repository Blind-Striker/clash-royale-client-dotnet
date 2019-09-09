using Pekka.ClashRoyaleApi.Client.Models.PlayerModels;

namespace Pekka.ClashRoyaleApi.Client.Models
{
    public class Card
    {
        public string Name { get; set; }

        public int? Id { get; set; }

        public int? MaxLevel { get; set; }

        public IconUrl IconUrls { get; set; }
    }
}