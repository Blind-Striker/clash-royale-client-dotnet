namespace Pekka.ClashRoyaleApi.Client.Models.PlayerModels
{
    public class PlayerBase
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public int? ExpLevel { get; set; }

        public int? Trophies { get; set; }

        public Arena Arena { get; set; }
    }
}
