namespace SchedsForums.Infrastructure.ConfigurationOptions
{
    public class JwtOptions
    {
        private static readonly int DefaultExpirationMinutes = 15;
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpirationMinutes { get; set; } = DefaultExpirationMinutes;
    }
}
