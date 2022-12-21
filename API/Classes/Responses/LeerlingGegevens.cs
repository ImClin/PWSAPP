namespace WebApiClin.Classes.Responses
{
    public class LeerlingGegevens
    {
        public int LeerlingId { get; set; } = 0;
        public String Wachtwoord { get; set; } = "";
        public String LeerlingNaam { get; set; } = "";
        public String Klas { get; set; } = "";
        public string MentorId { get; set; } = "";
        public String MentorNaam { get; set; } = "";

    }
}
