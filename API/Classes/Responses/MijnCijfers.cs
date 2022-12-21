namespace WebApiClin.Classes.Responses
{
    public class MijnCijfers
    {
        public int VakId { get; set; } = 0;
        public String Omschrijving { get; set; } = "";
        public String DocentId { get; set; } = "";
        public String Naam { get; set; } = "";
        public List<int> Behaald { get; set; } = new List<int>();
        public int Gemiddelde { get; set; } = 0;

    }
}
