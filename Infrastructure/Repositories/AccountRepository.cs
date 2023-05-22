
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Infrastructure.DBContext;

namespace Infrastructure.Repositories
{
    public class AccountRepository : GenericRepository<Account>,IAccountRepository
    {
        private readonly UserManager<Account> userManager;
        private readonly SignInManager<Account> signInManager;
        private readonly IConfiguration configuration;
        private readonly SpaBookingDBContext _context;
        public AccountRepository(UserManager<Account> userManager,
            SignInManager<Account> signInManager, IConfiguration configuration, SpaBookingDBContext context) :base(context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this._context = context;
        }

        public Account GetAccountsByID(string id)
        {
            Account? account = _context.Account.SingleOrDefault(x => x.Id == id);
            return account;
        }
        public async Task<string> SignInAsync(SignInModel model)
        {
            var result = await signInManager.PasswordSignInAsync
                (model.Email, model.Password, false, false);
            if(!result.Succeeded)
            {
                return string.Empty;
            }
            var user = await userManager.FindByEmailAsync(model.Email);
            var role = user.Role;
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authenKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            var user = new Account
            {
                UserName = model.Email,
                Email = model.Email,
                Role = model.Role,
            };

            return await userManager.CreateAsync(user, model.Password);
        }
    }
}
