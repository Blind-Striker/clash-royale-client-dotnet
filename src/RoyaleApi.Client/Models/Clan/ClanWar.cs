﻿using System.Collections.Generic;

namespace RoyaleApi.Client.Models.Clan
{
    public class ClanWar
    {
        public string State { get; set; }
        public ClanWarInfoClan Clan { get; set; }
        public List<ClanWarParticipant> Participants { get; set; }
        public int SeasonNumber { get; set; }
        public int? WarEndTime { get; set; }
        public int? CollectionEndTime { get; set; }

        public int? StageEndTime => WarEndTime ?? CollectionEndTime.GetValueOrDefault();
    }
}