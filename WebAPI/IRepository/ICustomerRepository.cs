﻿using BussinessObject.Models;

namespace WebAPI.IRepository
{
    public interface ICustomerRepository
    {
        ICollection<Customer> GetCustomers();
    }
}