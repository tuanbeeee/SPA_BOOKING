﻿using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        public Account? GetAccountsByID(string id);
    }
}
