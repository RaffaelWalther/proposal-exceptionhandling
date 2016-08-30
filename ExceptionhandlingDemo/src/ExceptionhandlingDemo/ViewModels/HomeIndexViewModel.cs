using ExceptionhandlingDemo.ViewModels.DataViewModels;

using System.Collections.Generic;

namespace ExceptionhandlingDemo.ViewModels
{
    public class HomeIndexViewModel : BaseViewModel
    {
        public IEnumerable<CustomerDataViewModel> Customers { get; set; }

        public HomeIndexViewModel()
        {
            Customers = new List<CustomerDataViewModel>();
            PageTitle = "Customers";
            PageSubTitle = "All your Customers";
        }
    }
}
