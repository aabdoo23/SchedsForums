namespace SchedsForums.Infrastructure.ConfigurationOptions
{
    public static class JWTConstants
    {
        public static string JWT_KEY = "JWT_KEY";
        public static string JWT_Options = "JwtOptions";
        public static string JWT_ISSUER = JWT_Options+":Issuer";
        public static string JWT_AUDIENCE = JWT_Options + ":Audience";
    }
}
