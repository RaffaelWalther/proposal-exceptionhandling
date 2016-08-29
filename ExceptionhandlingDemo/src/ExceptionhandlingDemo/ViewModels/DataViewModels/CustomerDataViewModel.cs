using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionhandlingDemo.ViewModels.DataViewModels
{
    public class CustomerDataViewModel : DataViewModelBase
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
    }
}
