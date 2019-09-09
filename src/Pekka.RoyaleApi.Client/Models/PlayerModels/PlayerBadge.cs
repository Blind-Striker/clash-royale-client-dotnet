namespace Pekka.RoyaleApi.Client.Models.PlayerModels
{
    public class PlayerBadge
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