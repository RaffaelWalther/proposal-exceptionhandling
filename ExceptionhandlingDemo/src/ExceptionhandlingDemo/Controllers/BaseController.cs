using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ExceptionhandlingDemo.Business.Contracts.Exceptions;
using Microsoft.AspNet.Mvc;

namespace ExceptionhandlingDemo.Controllers
{
    public class BaseController : Controller
    {
        
        protected void TreatUnhandledException(Exception ex)
        {
            
        }

        protected void TreatHandledException(BusinessException ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
