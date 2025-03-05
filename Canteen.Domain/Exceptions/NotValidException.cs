using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Domain.Exceptions
{
    public class NotValidException : Exception
    {
        public NotValidException()
        {
            validationErrors = new List<string>();
        }

        public NotValidException(string message) : base(message)
        {
            validationErrors = new List<string>();
        }

        public NotValidException(string message, Exception innerException) : base(message, innerException)
        {
            validationErrors = new List<string>();
        }

        public List<string> validationErrors { get; }

    }
}
