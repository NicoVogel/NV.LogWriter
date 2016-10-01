using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogWriter.Exceptions
{
    public class LWLogManagerException : LWException
    {
        public LWLogManagerException(string message, int eventID) : base(message, eventID) { }
    }
}
