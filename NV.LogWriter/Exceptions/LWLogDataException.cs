using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogWriter.Exceptions
{
    public class LWLogDataException : LWException
    {
        /// <summary>
        /// Create a new exception that the log is not ready to get logged.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="eventID"></param>
        public LWLogDataException(string message, int eventID) : base(message, eventID)
        {

        }
    }
}
