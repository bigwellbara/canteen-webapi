using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Domain.Exceptions
{
    public class MenuItemNotValidException : NotValidException
    {


        //refactorered this. moved to a separate base class where all not valid exceptions will inherit from so to avoid duplicating same code
        internal MenuItemNotValidException()
        {

        }

        internal MenuItemNotValidException(string message) : base(message)
        {

        }


        internal MenuItemNotValidException(string message, Exception innerException) : base(message, innerException)
        {

        }


    }
}
