using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogWriter.Exceptions
{
    public class LWWriterNotReadyException : ArgumentException
    {
        
        public LWWriterNotReadyException(string paramName, string message) : base(message, paramName)
        {

        }
    }
}
