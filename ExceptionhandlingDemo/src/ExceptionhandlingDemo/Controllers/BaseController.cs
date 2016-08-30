using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ExceptionhandlingDemo.Business.Contracts.Exceptions;
using ExceptionhandlingDemo.ViewModels;
using Microsoft.AspNet.Mvc;

namespace ExceptionhandlingDemo.Controllers
{
    public class BaseController : Controller
    {
        
        protected void TreatUnhandledException(Exception ex, BaseViewModel viewModel)
        {
            Debug.WriteLine(ex.Message);
            viewModel.ErrorMessage = "oops, an unhandled error has occured! This should nod happen ...";
        }

        protected void TreatHandledException(BusinessException bex, BaseViewModel viewModel)
        {
            Debug.WriteLine(bex.Message);
            viewModel.ErrorMessage = bex.Message;
        }
    }
}
