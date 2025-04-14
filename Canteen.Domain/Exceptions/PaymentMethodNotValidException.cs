using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Domain.Exceptions
{
    public class PaymentMethodNotValidException:NotValidException
    {
        public PaymentMethodNotValidException()
        {
            
        }

        public PaymentMethodNotValidException(string message):base(message) 
        {

        }

        public PaymentMethodNotValidException(string message, Exception innerException):base(message,innerException)
        {

        }

    }
}
