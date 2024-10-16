using JwtConfiguration.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtConfiguration
{
    public class JwtTokenHandler
    {
        public const string JWT_SECRET = "saDSdsDSd2DSDSdsds2dDSdsasd23213jk2h31k23hk1j2h3k12asdsds123";
        private const int JWT_TOKEN_VALIDITY_MINS = 20;
        private readonly List<UserAccount> _users;

        public JwtTokenHandler()
        {
            _users = [
                new UserAccount { Username = "admin", Password = "admin", Role = "Admin" },
                new UserAccount { Username = "user", Password = "user", Role = "User" }
            ];
        }

        public AuthenticationResponse? GenerateJwtToken(AuthenticationRequest request)
        {
            if(string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return null;
            }

            var user = _users.Where(u => u.Username == request.Username && u.Password == request.Password).FirstOrDefault();
            if(user == null)
            {
                return null;
            }

            var tokenExpiryTimeStamp = DateTime.UtcNow.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECRET);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, request.Username),
                new Claim(ClaimTypes.Role, user.Role)
            });

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature
            );

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(jwtToken);

            return new AuthenticationResponse
            {
                Username = user.Username,
                JwtToken = token,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.UtcNow).TotalSeconds
            };
        }
    }
}
