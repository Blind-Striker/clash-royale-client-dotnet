namespace Pekka.RoyaleApi.Client.Contracts.Models
{
    public interface IBadge : IModel
    {
        int Id { get; set; }

        string Name { get; set; }

        string Category { get; set; }

        string Image { get; set; }
    }
}