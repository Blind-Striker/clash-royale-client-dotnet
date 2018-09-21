namespace Pekka.ClashRoyaleApi.Client.Contracts
{
    public interface IClashRoyaleApiClientContext
    {
        IPlayerClient PlayerClient { get; }
        IClanClient ClanClient { get; }
        ILocationClient LocationClient { get; }
        ITournamentClient TournamentClient { get; }
        ICardClient CardClient { get; }
    }
}