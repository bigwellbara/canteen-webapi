using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Domain.Exceptions
{
    public class OrderNotValidException : NotValidException
    {
        internal OrderNotValidException() { }

        internal OrderNotValidException(string message): base(message) { }

        internal OrderNotValidException(string message, Exception innerException):base(message, innerException) { }
    }
}
