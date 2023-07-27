using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        public Account? GetAccountByEmail(string email);
        public Account? GetAccountByID(string id);
    }
}
