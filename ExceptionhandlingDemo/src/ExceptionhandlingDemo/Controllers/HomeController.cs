
using ExceptionhandlingDemo.Business.Contracts.ApplicationServices;
using ExceptionhandlingDemo.Business.Contracts.Exceptions;
using ExceptionhandlingDemo.ViewModels;
using Microsoft.AspNet.Mvc;
using System;
using System.Linq;

namespace ExceptionhandlingDemo.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICustomerApplicationService _customerApplicationService;

        public HomeController(ICustomerApplicationService customerApplicationService)
        {
            _customerApplicationService = customerApplicationService;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeIndexViewModel();

            try
            {
                var customers = _customerApplicationService.GetAllCustomers();
                viewModel.Customers = customers.Select(DataViewModelMapper.Map).ToList();
            }
            catch (BusinessException bex)
            {
                TreatHandledException(bex);
            }
            catch (Exception ex)
            {
                TreatUnhandledException(ex);
            }

            return View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
