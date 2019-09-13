namespace Pekka.ClashRoyaleApi.Client.Models.LocationModels
{
    public class Location
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public bool? IsCountry { get; set; }

        public string CountryCode { get; set; }
    }
}