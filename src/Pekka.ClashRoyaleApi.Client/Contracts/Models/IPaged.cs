using Pekka.ClashRoyaleApi.Client.Models;

namespace Pekka.ClashRoyaleApi.Client.Contracts.Models
{
    public interface IPaged<TModel>
    {
        TModel[] Items { get; set; }

        Paging Paging { get; set; }
    }
}