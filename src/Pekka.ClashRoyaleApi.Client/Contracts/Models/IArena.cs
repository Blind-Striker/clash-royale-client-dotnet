namespace Pekka.ClashRoyaleApi.Client.Contracts.Models
{
    public interface IArena : IModel
    {
        int Id { get; set; }

        string Name { get; set; }
    }
}