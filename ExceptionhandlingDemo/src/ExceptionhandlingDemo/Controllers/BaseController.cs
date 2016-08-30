﻿
using ExceptionhandlingDemo.Business.Contracts.Exceptions;
using ExceptionhandlingDemo.ViewModels;
using Microsoft.AspNet.Mvc;
using System;
using System.Diagnostics;

namespace ExceptionhandlingDemo.Controllers
{
    public class BaseController : Controller
    {
        #region Treat handled Business- and unhandled Errors

        protected void TreatUnhandledException(Exception ex, BaseViewModel viewModel)
        {
            Debug.WriteLine(ex.Message);
            viewModel.ErrorMessage = "oops, an unhandled error has occured! This should nod happen ...";
        }

        protected void TreatHandledException(BusinessException bex, BaseViewModel viewModel)
        {
            Debug.WriteLine(bex.Message);

#if DEBUG
            viewModel.ErrorMessage = string.Join(" > ", bex.FlattenInnerException());
#else
            viewModel.ErrorMessage = bex.Message;
#endif
        }

        #endregion
    }
}
