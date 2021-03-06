﻿namespace Pekka.RoyaleApi.Client.Contracts.Models
{
    public interface ITeam
    {
        string Tag { get; set; }

        string Name { get; set; }

        int CrownsEarned { get; set; }

        int StartTrophies { get; set; }

        IClanLight Clan { get; set; }

        string DeckLink { get; set; }

        ICard[] Deck { get; set; }
    }
}