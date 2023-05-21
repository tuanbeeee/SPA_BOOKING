using BussinessObject.Models;
using Microsoft.AspNetCore.Identity;

namespace WebAPI.Repository
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
        public ICollection<Account> GetAccount();
        public Account GetAccountsByID(string id);
    }
}
