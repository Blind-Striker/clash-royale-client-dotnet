namespace Pekka.ClashRoyaleApi.Client.Contracts.Models
{
    public interface IMode : IModel
    {
        int Id { get; set; }

        string Name { get; set; }
    }
}