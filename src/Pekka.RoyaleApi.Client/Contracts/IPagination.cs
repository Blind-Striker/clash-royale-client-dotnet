namespace Pekka.RoyaleApi.Client.Contracts
{
    public interface IPagination
    {
        int? Max { get; set; }
        int? Page { get; set; }
    }
}