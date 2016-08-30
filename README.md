# proposal-exceptionhandling
Proposals (2 of x) for Errorhandling in a simple Web-Application (ASP.NET Core 1)

## Option 1: 
Classic Handling, Action consumes Appl.Services and provides try/catch for BusinessExceptions and System Exceptions (treated in BaseController Methods).

## Option 2: 
Generic Handling, Action consumes generic Method in BaseController and provides a Func-Delegate for getting Data and ViewModel.

