
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
                TreatHandledException(bex, viewModel);
            }
            catch (Exception ex)
            {
                TreatUnhandledException(ex, viewModel);
            }

            return View(viewModel);
        }

        public IActionResult Details(Guid id)
        {
            var viewModel = new HomeDetailsViewModel();

            try
            {
                var customer = _customerApplicationService.GetCustomer(id);
                viewModel.Customer = DataViewModelMapper.Map(customer);
            }
            catch (BusinessException bex)
            {
                TreatHandledException(bex, viewModel);
            }
            catch (Exception ex)
            {
                TreatUnhandledException(ex, viewModel);
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
