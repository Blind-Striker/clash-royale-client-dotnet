namespace Pekka.RoyaleApi.Client.Models.Clan
{
    public class ClanRegion
    {
        public string Name { get; set; }
        public bool IsCountry { get; set; }
        public string Code { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}