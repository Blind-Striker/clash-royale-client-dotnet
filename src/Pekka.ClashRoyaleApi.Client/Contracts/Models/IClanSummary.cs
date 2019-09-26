namespace Pekka.ClashRoyaleApi.Client.Contracts.Models
{
    public interface IClanSummary : IClanLight
    {
        int ClanScore { get; set; }

        int Participants { get; set; }

        int BattlesPlayed { get; set; }

        int Wins { get; set; }

        int Crowns { get; set; }
    }
}