namespace Pekka.ClashRoyaleApi.Client.Contracts.Models
{
    public interface IClanLight : IModel
    {
        string Tag { get; set; }

        string Name { get; set; }

        int BadgeId { get; set; }
    }
}