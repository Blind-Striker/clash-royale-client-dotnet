using System.Collections.Generic;

namespace Pekka.RoyaleApi.Client.Models.PlayerModels
{
    public class PlayerChest
    {
        public List<string> Upcoming { get; set; }
        public int SuperMagical { get; set; }
        public int Magical { get; set; }
        public int Legendary { get; set; }
        public int Epic { get; set; }
        public int Giant { get; set; }
    }
}