namespace WebApiClin.Classes.Responses
{
    public class BehaaldeCijfers
    {
        public int VakId { get; set; } = 0;
        public string LeerlingId { get; set; } ="";
        public List<int> Behaald { get; set; } = new List<int>();

    }
}
