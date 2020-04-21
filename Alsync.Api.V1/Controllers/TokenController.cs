using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Alsync.Api.V1.Controllers
{
    public class TokenController : HttpController
    {
        public IConfiguration Configuration { get; }

        public TokenController(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// JWT授权验证。
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public dynamic Authentication()
        {
            //return Unauthorized();
            var payloadConfig = this.Configuration.GetSection("Jwt").GetSection("Payload");
            var key = Encoding.UTF8.GetBytes(payloadConfig["secret"]);
            var authTime = DateTime.UtcNow;
            var expiresAt = authTime.AddDays(7);
            var claims = new Claim[]
            {
                    //new Claim(JwtRegisteredClaimNames.Sub, "一个主题"),  //sub has changed to nameidentifier.
                    //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Name, "user"),
                    //new Claim(ClaimTypes.Gender ,"male"),
                    //new Claim(ClaimTypes.GivenName ,"张三")
            };
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Issuer = payloadConfig["iss"],
            //    Audience = payloadConfig["aud"],
            //    Subject = new ClaimsIdentity(claims),
            //    IssuedAt = authTime,
            //    Expires = expiresAt,
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};
            var tokenHandler = new JwtSecurityTokenHandler();
            //var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            //var access_token = tokenHandler.WriteToken(securityToken);

            var jwtToken = new JwtSecurityToken(
                issuer: payloadConfig["iss"],
                audience: payloadConfig["aud"],
                claims: claims,
                notBefore: authTime,
                expires: expiresAt,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature));
            var access_token = tokenHandler.WriteToken(jwtToken);
            return new
            {
                Result = true,
                Data = new
                {
                    access_token,
                    token_type = JwtBearerDefaults.AuthenticationScheme,
                    profile = new
                    {
                        auth_time = new DateTimeOffset(authTime).ToUnixTimeSeconds(),
                        expires_at = new DateTimeOffset(expiresAt).ToUnixTimeSeconds()
                    }
                }
            };
        }
    }
}