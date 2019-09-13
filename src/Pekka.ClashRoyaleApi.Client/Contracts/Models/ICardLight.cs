using Pekka.ClashRoyaleApi.Client.Models.PlayerModels;

namespace Pekka.ClashRoyaleApi.Client.Contracts.Models
{
    public interface ICardLight : IModel
    {
        string Name { get; set; }

        int Id { get; set; }

        int MaxLevel { get; set; }

        IIconUrl IconUrls { get; set; }
    }
}