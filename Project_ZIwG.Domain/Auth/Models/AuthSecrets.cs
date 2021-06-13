namespace Project_ZIwG.Domain.Auth.Models
{
    public class AuthSecrets
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int ExpirationTime { get; set; }
    }
}
