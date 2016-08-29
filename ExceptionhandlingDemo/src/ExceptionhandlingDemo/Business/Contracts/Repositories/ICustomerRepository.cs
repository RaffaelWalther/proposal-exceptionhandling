

using ExceptionhandlingDemo.Business.Contracts.Models;
using System;
using System.Collections.Generic;

namespace ExceptionhandlingDemo.Business.Contracts.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Get();

        Customer Get(Guid objectId);
    }
}
