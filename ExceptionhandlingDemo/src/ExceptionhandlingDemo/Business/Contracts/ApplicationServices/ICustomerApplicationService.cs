using ExceptionhandlingDemo.Business.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionhandlingDemo.Business.Contracts.ApplicationServices
{
    public interface ICustomerApplicationService
    {
        IEnumerable<Customer> GetAllCustomers();

        Customer GetCustomer(Guid objectId);
    }
}
