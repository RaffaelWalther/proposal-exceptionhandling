using ExceptionhandlingDemo.Business.Contracts.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExceptionhandlingDemo.Business.Contracts.Models;
using ExceptionhandlingDemo.Business.Contracts.Repositories;
using ExceptionhandlingDemo.Business.Contracts.Exceptions;

namespace ExceptionhandlingDemo.Business.ApplicationServices
{
    public class CustomerApplicationService : ICustomerApplicationService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerApplicationService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            try
            {
                return _customerRepository.Get();
            }
            catch (Exception ex)
            {
                throw new BusinessException("Localized Error in loading all customers", ex);
            }
        }

        public Customer GetCustomer(Guid objectId)
        {
            try
            {
                return _customerRepository.Get(objectId);
            }
            catch (Exception ex)
            {
                throw new BusinessException("Localized Error in loading specific customer", ex);
            }
        }
    }
}
