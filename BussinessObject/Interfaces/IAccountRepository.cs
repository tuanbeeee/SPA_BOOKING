using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Domain.Interfaces
{
    public interface IAccountRepository: IGenericRepository<Account>
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
        public Account GetAccountsByID(string id);
    }
}
