using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Exceptions
{
    public class ClientsideException : Exception
    {
        public ClientsideException(string message) : base(message)
        {
            
        }
    }
}
