using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NV.LogWriter.Exceptions
{
    public class LWLogDataNotReadyException : ArgumentException
    {
        public LWLogDataNotReadyException(string paramName, string message) : base(message, paramName)
        {

        }
    }
}
