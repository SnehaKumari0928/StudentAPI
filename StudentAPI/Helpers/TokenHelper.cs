using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Utilities;
using StudentAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace StudentAPI.Helpers
{
    public class TokenHelper
    {

        public static string GenerateAccessToken(StudentModel user,IConfiguration config)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));

            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(

                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: creds

                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static string GenerateRefreshToken()
        {
            var random = new byte[32];
            var rng = RandomNumberGenerator.Create();

            rng.GetBytes(random);
            return Convert.ToBase64String(random);
        }
    }
}
