
using ExceptionhandlingDemo.Business.Contracts.Exceptions;
using ExceptionhandlingDemo.ViewModels;
using Microsoft.AspNet.Mvc;
using System;
using System.Diagnostics;

namespace ExceptionhandlingDemo.Controllers
{
    public class BaseController : Controller
    {
        #region Option A: Treat handled Business- and unhandled Errors

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

        #region Option B: Simplified Action with Func-Delegates

        protected TResult GetViewModel<TResult>(Func<TResult> action) where TResult : BaseViewModel
        {
            try
            {
                return (TResult)action.Invoke();
            }
            catch (BusinessException bex)
            {
                var viewModel = new BaseViewModel();
                TreatHandledException(bex, viewModel);
                return (TResult)viewModel;
            }
            catch (Exception ex)
            {
                var viewModel = new BaseViewModel();
                TreatUnhandledException(ex, viewModel);
                return (TResult)viewModel;
            }
        }

        protected TResult GetViewModel<T, TResult>(Func<T, TResult> action, T arg) where TResult : BaseViewModel
        {
            try
            {
              return (TResult)action.Invoke(arg);
            }
            catch (BusinessException bex)
            {
                var viewModel = new BaseViewModel();
                TreatHandledException(bex, viewModel);
                return (TResult)viewModel;
            }
            catch (Exception ex)
            {
                var viewModel = new BaseViewModel();
                TreatUnhandledException(ex, viewModel);
                return (TResult)viewModel;
            }
        }


        private T CreateViewModel<T>()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }

        #endregion
    }
}
