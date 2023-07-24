using Application.DTOs.Response;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class JwtToken : IJwtToken
    {
        private readonly IConfiguration _configuration;
        public JwtToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SignInResponseDTO GenerateJwtToken(string email, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(15),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
                );

            var refreshToken = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
                );
            return new SignInResponseDTO
            {
                AccessToken = tokenHandler.WriteToken(token),
                RefreshToken = tokenHandler.WriteToken(refreshToken)
            };
        }
        public SignInResponseDTO? VerifyToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var authenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(authenKey),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var id = jwtToken.Claims.FirstOrDefault(x => x.Type == "email");
                var role = jwtToken.Claims.FirstOrDefault(x => x.Type == "role");
                return new SignInResponseDTO
                {
                    AccessToken = token,
                };
            }
            catch (Exception ex) {
                return null;
            }
        }
    }
}
