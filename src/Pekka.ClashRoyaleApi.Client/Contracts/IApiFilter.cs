using Pekka.Core.Contracts;

namespace Pekka.ClashRoyaleApi.Client.Contracts
{
    public interface IApiFilter : IFilter
    {
        int? Limit { get; set; }

        int? After { get; set; }

        int? Before { get; set; }
    }
}