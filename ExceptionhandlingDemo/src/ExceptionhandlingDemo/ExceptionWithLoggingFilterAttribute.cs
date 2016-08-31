using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Filters;
using ExceptionhandlingDemo.Business.Contracts.Exceptions;
using ExceptionhandlingDemo.ViewModels;
using System.Diagnostics;
using ExceptionhandlingDemo.Controllers;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Razor.Directives;
using Microsoft.AspNet.Mvc.ViewFeatures;
using Microsoft.AspNet.Routing;
using Microsoft.Extensions.Logging;
using Serilog.Core;

namespace ExceptionhandlingDemo
{
    public class ExceptionWithLoggingFilterAttribute: ActionFilterAttribute, IExceptionFilter
    {
        private Controller _controller;
        private readonly ILogger<BaseController> _logger;

        public ExceptionWithLoggingFilterAttribute()
        {
            _logger = new Logger<BaseController>(new LoggerFactory());
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _controller = (Controller) context.Controller;
            base.OnActionExecuting(context);
        }


        public void OnException(ExceptionContext context)
        {

            if (context.Exception is BusinessException)
            {
                var viewModel = new BaseViewModel();
                TreatHandledException((BusinessException)context.Exception, viewModel);

                _controller.ViewData.Model = viewModel;

                context.Result = new ViewResult()
                {
                    ViewName = "Error",
                    ViewData = _controller.ViewData,
                    TempData = _controller.TempData
                };
            }
            else if (context.Exception != null)
            {
                var viewModel = new BaseViewModel();
                 TreatUnhandledException(context.Exception, viewModel);

                _controller.ViewData.Model = viewModel;
                
                context.Result = new ViewResult()
                {
                    ViewName = "Error",
                    ViewData = _controller.ViewData,
                    TempData = _controller.TempData
                };
            }
        }

        protected void TreatUnhandledException(Exception ex, BaseViewModel viewModel)
        {
            Debug.WriteLine(ex.Message);
            _logger.LogCritical($"Unhandled Error occured: {ex.Message}");
            viewModel.ErrorMessage = "oops, an unhandled error has occured! This should nod happen ...";
        }

        protected void TreatHandledException(BusinessException bex, BaseViewModel viewModel)
        {
            Debug.WriteLine(bex.Message);
            _logger.LogError(bex.Message);
            viewModel.ErrorMessage = string.Join(" > ", bex.FlattenInnerException());
        }
    }
}
