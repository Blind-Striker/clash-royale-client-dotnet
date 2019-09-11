namespace Pekka.RoyaleApi.Client.Contracts
{
    public interface IRoyaleApiClientContext
    {
        IVersionClient VersionClient { get; }

        IPlayerClient PlayerClient { get; }

        IClanClient ClanClient { get; }

        //ITournamentClient TournamentClient { get; }
    }
}