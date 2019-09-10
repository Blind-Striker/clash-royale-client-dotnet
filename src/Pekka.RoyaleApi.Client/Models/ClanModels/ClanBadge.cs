using Pekka.RoyaleApi.Client.Contracts.Models;

namespace Pekka.RoyaleApi.Client.Models.ClanModels
{
    public class ClanBadge : IBadge
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string Image { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}