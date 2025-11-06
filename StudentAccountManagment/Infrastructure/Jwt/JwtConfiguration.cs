using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
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
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtOptions.Value.Issuer,

                    ValidateAudience = true,
                    ValidAudience = jwtOptions.Value.Audiance,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.Key))
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context=>
                    {
                        var access_token = context.Request.Query["access_token"];
                        if(context.HttpContext.Request.Path.StartsWithSegments("/TestObservation"))
                        {
                            var tokenHandeler = new JwtSecurityTokenHandler();
                            var jwtToken = tokenHandeler.ReadJwtToken(access_token);
                            var role = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;

                            context.Request.Headers.Add("x-Role", role);
                        }
                        return Task.CompletedTask;
                    }
                };

            }
            );
            return services;
        }
    }
}
