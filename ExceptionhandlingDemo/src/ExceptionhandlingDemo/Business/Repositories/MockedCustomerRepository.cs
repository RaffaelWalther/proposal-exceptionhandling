
using ExceptionhandlingDemo.Business.Contracts.Models;
using ExceptionhandlingDemo.Business.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExceptionhandlingDemo.Business.Repositories
{
    public class MockedCustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _demoData;

        public MockedCustomerRepository()
        {
            _demoData = GetDemoData();
        }

        public IEnumerable<Customer> Get()
        {
            return _demoData;
        }

        public Customer Get(Guid objectId)
        {
            return _demoData.Where(d => d.ObjectId == objectId).FirstOrDefault();
        }

        #region Helper

        public List<Customer> GetDemoData()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, ObjectId= Guid.NewGuid(), TimestampUtc = DateTime.UtcNow, FirstName = "Darth", MiddleName = "i'm your father", LastName = "Vader" },
                new Customer { Id = 2, ObjectId = Guid.NewGuid(), TimestampUtc = DateTime.UtcNow.AddDays(-3), FirstName = "Luke", LastName = "Skywalker" },
                new Customer { Id = 3, ObjectId = Guid.NewGuid(), TimestampUtc = DateTime.UtcNow.AddDays(-1), FirstName = "Obi", MiddleName = "Wan", LastName = "Kenobi" },
                new Customer { Id = 4, ObjectId = Guid.NewGuid(), TimestampUtc = DateTime.UtcNow.AddDays(-10), FirstName = "Jabba", MiddleName = "Dsilijic ", LastName = "Tiure" }
            };
        }

        #endregion
    }
}
