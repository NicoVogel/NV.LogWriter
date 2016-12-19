using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogWriter.Exceptions
{
    public class LWLogWriterException : LWException
    {
        /// <summary>
        /// Create a new exception that the log writer is not ready to write a log
        /// </summary>
        /// <param name="message">This is the message for the exception</param>
        /// <param name="eventID">This is the event id for the exception</param>
        public LWLogWriterException(string message, int eventID) : base(message, eventID) { }
        /// <summary>
        /// Create a new exception that the log writer is not ready to write a log
        /// </summary>
        /// <param name="message">This is the message for the exception</param>
        /// <param name="innerException">This is the inner exception for the exception</param>
        /// <param name="eventID">This is the event id for the exception</param>
        public LWLogWriterException(string message, Exception innerException, int eventID) : base(message, innerException, eventID) { }
    }
}
