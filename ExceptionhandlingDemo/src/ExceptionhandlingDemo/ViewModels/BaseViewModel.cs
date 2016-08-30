using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionhandlingDemo.ViewModels
{
    public class BaseViewModel
    {
        public string PageTitle { get; set; }

        public string PageSubTitle { get; set; }

        public string Abstract { get; set; }

        public string ErrorMessage { get; set; }

        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

        public BaseViewModel()
        {
            PageTitle = "ExceptionhandlingDemo";
            PageSubTitle = "Proposal for Exceptionhandling in ASP.NET MVC";
        }
    }
}
