namespace StudentAccountManagment.Infrastructure.Jwt
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audiance { get; set; }
        public string Key { get; set; }

    }
}
