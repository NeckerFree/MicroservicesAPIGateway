namespace Identity.Api.Entities
{
    public class JWT
    {
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string? Key { get; set; }

    }
}
