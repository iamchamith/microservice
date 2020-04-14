using System;
using System.Collections.Generic;
using System.Text;

namespace App.SharedKernel.Exception
{
    public class UnAuthonticatedException : System.Exception
    {
        public UnAuthonticatedException(string message) : base(message)
        {
        }
    }
}
