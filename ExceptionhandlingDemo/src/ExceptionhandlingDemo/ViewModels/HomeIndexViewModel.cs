using ExceptionhandlingDemo.ViewModels.DataViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionhandlingDemo.ViewModels
{
    public class HomeIndexViewModel : BaseViewModel
    {
        public IEnumerable<CustomerDataViewModel> Customers { get; set; }

        public HomeIndexViewModel()
        {
            Customers = new List<CustomerDataViewModel>();
        }
    }
}
