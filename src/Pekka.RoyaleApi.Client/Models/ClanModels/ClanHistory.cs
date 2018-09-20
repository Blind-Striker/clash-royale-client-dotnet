using System;
using System.Collections.Generic;
using System.Text;

namespace Pekka.RoyaleApi.Client.Models.ClanModels
{
    public class ClanHistory
    {
        public int Donations { get; set; }

        public int MemberCount { get; set; }

        public ClanHistoryPlayer[] Members { get; set; }
    }

    public class ClanHistoryPlayer
    {
        public int ClanRank { get; set; }

        public int Donations { get; set; }

        public string Name { get; set; }

        public string Tag { get; set; }

        public int Trophies { get; set; }
    }
}
