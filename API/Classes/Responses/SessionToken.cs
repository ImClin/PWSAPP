namespace WebApiClin.Classes.Responses
{
    public class SessionToken
    {
        public bool? ok { get; set; }
        public string? Token { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public string? Id { get; set; }
        public string? Naam { get; set; }
        public string? Klas { get; set; }
        public string? Mentor { get; set; }
        public int? IsMentor { get; set; }

        public string? Error { get; set; }
    }
}
