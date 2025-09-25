using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace StudentAccountManagment.Infrastructure.Jwt
{
    public static class JwtConfiguration
    {
        public static IServiceCollection AddJwt(this IServiceCollection services)
        {
            var jwtOptions = services.BuildServiceProvider().GetRequiredService<IOptions<JwtOptions>>();
          
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters{
                    ValidateIssuer = true,
                    ValidIssuer = jwtOptions.Value.Issuer,

                    ValidateAudience = true,
                    ValidAudience = jwtOptions.Value.Audiance,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.Key))
                }
            );
            return services;
        }
    }
}
