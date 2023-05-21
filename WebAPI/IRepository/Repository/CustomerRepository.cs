﻿using BussinessObject.DBContext;
using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.IRepository.Repository
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly SpaBookingDBContext _context;
        public CustomerRepository(SpaBookingDBContext context)
        {
            _context = context;
        }

        public Customer CreateCustomer(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public Customer GetCustomer(long id)
        {
            Customer? customer = _context.Customer
                .Include(c => c.Account)
                .Include(r => r.Reviews)
                .SingleOrDefault(c=>c.customerId==id);
            return customer;
        }

        public ICollection<Customer> GetCustomers()
        {
            return _context.Customer
                .Include(c => c.Account)
                .Include(r => r.Reviews)
                .ToList();
        }

        public Customer UpdateCustomer(Customer customer)
        {
            _context.Update(customer);
            _context.SaveChanges();
            return customer;
        }
    }
}
