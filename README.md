# proposal-exceptionhandling
Proposals (2 of x) for Errorhandling in a simple Web-Application (ASP.NET Core 1)

## Option 1: 
Classic Handling, Action consumes Appl.Services and provides try/catch for BusinessExceptions and System Exceptions (treated in BaseController Methods).

## Option 2: 
Generic Handling, Action consumes generic Method in BaseController and provides a Func-Delegate for getting Data and ViewModel.

## Option 3:
Similar to Option 2 but instead of a Method in BaseController a Filter (ExceptionWithLoggingFilterAttribute) is used.
(Use http:localhost:5000/Home/Index2 to test)
