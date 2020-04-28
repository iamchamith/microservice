using System;
using System.Collections.Generic;
using System.Text;

namespace App.SharedKernel.Exception
{
    public class UnAuthorizedException : System.Exception
    {
        public UnAuthorizedException(string message) : base(message)
        {
        }
    }
}
