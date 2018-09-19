namespace Pekka.ClashRoyaleApi.Client.Contracts
{
    public interface IFilter
    {
        int? Limit { get; set; }

        int? After { get; set; }

        int? Before { get; set; }
    }
}