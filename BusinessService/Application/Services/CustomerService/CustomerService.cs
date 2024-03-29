﻿using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Exceptions;
using AutoMapper;
using Domain.Models;
using Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task Add(CustomerRequestDTO requestCustomer)
        {
            if (requestCustomer == null)
            {
                throw new BadRequestException("Customer Information is invalid!");
            }
            var customer = _mapper.Map<Customer>(requestCustomer);
            //customer.Account = _accountRepository.GetAccountsByID(requestCustomer.account_Id);
            await _customerRepository.AddAsync(customer);
            if (await _customerRepository.SaveChangeAsync() is false)
            {
                throw new BadRequestException("Error when adding Customer!");
            }
        }

        public async Task Delete(long Id)
        {
            var customer = await _customerRepository.GetAsync(Id);
            if (customer == null)
            {
                throw new NotFoundException("Customer not found!");
            }
            _customerRepository.Delete(customer);
            if (await _customerRepository.SaveChangeAsync() is false)
            {
                throw new NotFoundException("Error when deleting Customer!");
            }
        }

        public async Task<CustomerResponseDTO> GetCustomer(long Id)
        {
            var customer = await _customerRepository.GetAsync(Id);
            if (customer == null)
            {
                throw new NotFoundException("Customer not found!");
            }
            return _mapper.Map<CustomerResponseDTO>(customer);

        }

        public async Task<ICollection<CustomerResponseDTO>> GetCustomers()
        {
            var customers = await _customerRepository.GetAllAsync();
            return _mapper.Map<ICollection<CustomerResponseDTO>>(customers);
        }

        public async Task<ICollection<CustomerResponseDTO>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllCustomers();
            return _mapper.Map<ICollection<CustomerResponseDTO>>(customers);
        }

        public async Task Update(long id, CustomerRequestDTO customerRequest)
        {
            var customer= await _customerRepository.GetAsync(id);
            if (customer == null)
            {
                throw new NotFoundException("Customer not found!");
            }
                                 
                 _customerRepository.Update(_mapper.Map(customerRequest,customer));
                                   
            if (await _customerRepository.SaveChangeAsync() == false)
            {
                 throw new BadRequestException("Error when updating Customer!");
            }           
        }
    }
}
