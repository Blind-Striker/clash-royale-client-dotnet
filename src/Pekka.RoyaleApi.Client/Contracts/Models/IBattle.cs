using System;
using System.Collections.Generic;

namespace Pekka.RoyaleApi.Client.Contracts.Models
{
    public interface IBattle : IModel
    {
        string Type { get; set; }

        DateTime UtcTime { get; set; }

        string DeckType { get; set; }

        int WinCountBefore { get; set; }

        int TeamSize { get; set; }

        int Winner { get; set; }

        int TeamCrowns { get; set; }

        int OpponentCrowns { get; set; }

        IArena Arena { get; set; }

        IMode Mode { get; set; }

        ITeam[] Team { get; set; }

        ITeam[] Opponent { get; set; }
    }
}