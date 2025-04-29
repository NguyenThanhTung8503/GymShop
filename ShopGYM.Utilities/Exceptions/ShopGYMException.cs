using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.Utilities.Exceptions
{
    public class ShopGYMException : Exception
    {
        public ShopGYMException() { }   
        public ShopGYMException(string message) : base(message)
        {
            
        }
        public ShopGYMException(string message, Exception inmer)
            : base(message, inmer) 
        {

        }
        
    }
}
