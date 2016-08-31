

using ExceptionhandlingDemo.Business.Contracts.ApplicationServices;
using ExceptionhandlingDemo.Business.Contracts.Exceptions;
using ExceptionhandlingDemo.ViewModels;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace ExceptionhandlingDemo.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICustomerApplicationService _customerApplicationService;

        public HomeController(ICustomerApplicationService customerApplicationService, ILogger<HomeController> logger)
            :base(logger)
        {
            _customerApplicationService = customerApplicationService;
        }
        
        public IActionResult Index()
        {
            var viewModel = new HomeIndexViewModel();

            try
            {
                throw new Exception();

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

        [ExceptionWithLoggingFilter]
        public IActionResult Index2()
        {
            throw new Exception();
            return View(new HomeIndexViewModel());
        }

        public IActionResult Error()
        {
            return View();
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

        public IActionResult IndexFunc()
        {
            return View("Index", GetViewModel<HomeIndexViewModel>(GetIndexViewModel));
        }

        public IActionResult DetailsFunc(Guid id)
        {
            return View("Details", GetViewModel<Guid, HomeDetailsViewModel>(GetDetailsViewModel, id));
        }

        #region Helper

        private HomeIndexViewModel GetIndexViewModel()
        {
            // todo: uncomment to simulate unhandled-exception handling
            // throw new Exception();

            return new HomeIndexViewModel
            {
                Customers = _customerApplicationService.GetAllCustomers()
                    .Select(DataViewModelMapper.Map).ToList()
            };
        }

        private HomeDetailsViewModel GetDetailsViewModel(Guid objectId)
        {
            // todo: uncomment to simulate unhandled-exception handling
            // throw new Exception();

            return new HomeDetailsViewModel
            {
                Customer = DataViewModelMapper.Map(_customerApplicationService.GetCustomer(objectId))
            };
        }

        #endregion

    }
}
