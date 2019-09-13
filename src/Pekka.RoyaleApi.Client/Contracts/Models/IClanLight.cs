namespace Pekka.RoyaleApi.Client.Contracts.Models
{
    public interface IClanLight
    {
        string Tag { get; set; }

        string Name { get; set; }

        IBadge Badge { get; set; }
    }
}