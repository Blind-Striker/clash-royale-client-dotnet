using System;
using System.Collections.Generic;
using System.Text;

namespace Pekka.RoyaleApi.Client.Models.PlayerModels
{
    public class PlayerClanLight
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public PlayerBadge Badge { get; set; }
    }
}