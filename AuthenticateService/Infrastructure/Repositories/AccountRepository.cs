
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Infrastructure.DBContext;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly SpaBookingDBContext _context;
        public AccountRepository(SpaBookingDBContext context) : base(context)
        {
            this._context = context;
        }

        public Account? GetAccountsByEmail(string email)
        {
            var account = _context.Account.SingleOrDefault(x => x.Email == email);
            return account;
        }

        public Account? GetAccountsByID(string id)
        {
            var account = _context.Account.SingleOrDefault(x => x.Id == id);
            return account;
        }
    }
}
