using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidLibrary.CustomExceptions
{
    public class SpotNotNullException : Exception
    {
        public SpotNotNullException(string message) : base(message)
        {

        }
    }
}
