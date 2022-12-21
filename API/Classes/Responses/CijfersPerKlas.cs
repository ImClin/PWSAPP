namespace WebApiClin.Classes.Responses
{
    public class CijfersPerKlas
    {
        public int VakId { get; set; } = 0;
        public String Omschrijving { get; set; } = "";
        public String LeerlingId { get; set; } = "";
        public String Naam { get; set; } = "";
        public String Klas { get; set; } = "";
        public List<int> Behaald { get; set; } = new List<int>();
        public int Gemiddelde { get; set; } = 0;

    }
}
