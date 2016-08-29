using ExceptionhandlingDemo.Business.Contracts.Models;
using ExceptionhandlingDemo.ViewModels.DataViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionhandlingDemo.ViewModels
{
    public static class DataViewModelMapper
    {
        public static CustomerDataViewModel Map(Customer c)
        {
            return new CustomerDataViewModel
            {
                ObjectId = c.ObjectId,
                TimestampUtc = c.TimestampUtc,
                FirstName = c.FirstName,
                MiddleName = c.MiddleName,
                LastName = c.LastName,
            };
        }

        public static Customer Map(CustomerDataViewModel c)
        {
            return new Customer
            {
                ObjectId = c.ObjectId,
                TimestampUtc = c.TimestampUtc,
                FirstName = c.FirstName,
                MiddleName = c.MiddleName,
                LastName = c.LastName,
            };
        }
    }
}
