using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Domain.Exceptions
{
    public class OrderItemNotValidException : NotValidException
    {

        public OrderItemNotValidException()
        {
            
        }

        public OrderItemNotValidException(string message) : base(message)
        {
            
        }

        public OrderItemNotValidException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}
