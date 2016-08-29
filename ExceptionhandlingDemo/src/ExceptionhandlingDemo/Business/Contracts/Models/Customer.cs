using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionhandlingDemo.Business.Contracts.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public Guid ObjectId { get; set; }

        public DateTime TimestampUtc { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
    }
}
