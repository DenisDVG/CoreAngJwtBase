using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using CoreAngJwtBase.Common;
using CoreAngJwtBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CoreAngJwtBase.Сontrollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IOptions<AuthOptions> authOptions;

        public AuthController(IOptions<AuthOptions> authOptions)
        {
            this.authOptions = authOptions;
        }
        private List<Account> Accounts => new List<Account>
        {
            new Account()
            {
                Id = Guid.Parse("dbe1680f-ac76-48ad-9be3-b800c86f3fa6"),
                Email = "user@email.com",
                Password = "user",
                Roles = new Role[] { Role.User }
            },
            new Account()
            {
                Id = Guid.Parse("3d2890c7-5da0-41ad-8c25-406b11945eec"),
                Email = "user2@email.com",
                Password = "user2",
                Roles = new Role[] { Role.User }
            },
            new Account()
            {
                Id = Guid.Parse("65cd157b-3e78-4a97-9298-2f89d86181c4"),
                Email = "admin@email.com",
                Password = "admin",
                Roles = new Role[] { Role.Admin }
            },
            new Account()
            {
                Id = Guid.Parse("1911401d-96a8-403a-8aa8-29f2bff1960f"),
                Email = "admin2@email.com",
                Password = "admin2",
                Roles = new Role[] { Role.Admin }
            }
        };

        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] Login request)
        {
            var user = AuthenticateUser(request.Email, request.Password);
            if (user != null)
            {
                // Generate JWT
                var token = GenerateJWT(user);

                return Ok(
                    new { access_token = token }
                );
            }

            return Unauthorized();
        }

        private Account AuthenticateUser(string email, string password)
        {
            return Accounts.SingleOrDefault(x => x.Email == email
                && x.Password == password);
        }

        private string GenerateJWT(Account user)
        {
            var authParams = authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };
            foreach (var role in user.Roles)
            {
                claims.Add(new Claim("role", role.ToString()));
            };

            var token = new JwtSecurityToken(authParams.Issure,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
