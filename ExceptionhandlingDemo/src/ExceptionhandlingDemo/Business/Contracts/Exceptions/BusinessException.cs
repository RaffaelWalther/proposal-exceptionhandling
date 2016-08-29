using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionhandlingDemo.Business.Contracts.Exceptions
{
    public class BusinessException : Exception
    {
        private Exception _innerException;

        public BusinessException(string message)
            : base(message)
        {
        }

        public BusinessException(string message, Exception innerException)
            : base(message, innerException)
        {
            _innerException = innerException;
        }

        public IEnumerable<string> FlattenInnerException()
        {
            var innerException = _innerException;

            if (innerException == null)
            {
                yield break;
            }

            do
            {
                yield return innerException.Message;
                innerException = (innerException != null)
                    ? innerException.InnerException
                    : null;
            }
            while (innerException != null);
        }
    }
}
