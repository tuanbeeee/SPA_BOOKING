﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        public Task<ICollection<Payment>> GetAllPayments();
    }
}
