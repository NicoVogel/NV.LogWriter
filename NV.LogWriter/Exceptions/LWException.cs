using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogWriter.Exceptions
{
    /// <summary>
    /// Top exception class for this dll.
    /// </summary>
    public abstract class LWException : Exception
    {
        private int m_eventID;

        /// <summary>
        /// The event id of the exception
        /// </summary>
        public int EventID
        {
            get { return m_eventID; }
            set { m_eventID = value; }
        }

        /// <summary>
        /// Create a new exception with a message
        /// </summary>
        /// <param name="message">This is the message for the exception</param>
        public LWException(string message) : base(message) { }

        /// <summary>
        /// Create a new exception with a message and an event id
        /// </summary>
        /// <param name="message">This is the message for the exception</param>
        /// <param name="eventID">This is the event id for the exception</param>
        public LWException(string message, int eventID) : base(message)
        {
            EventID = eventID;
        }

        /// <summary>
        /// Create a new exception with a message and an inner exception
        /// </summary>
        /// <param name="message">This is the message for the exception</param>
        /// <param name="innerException">This is the inner exception for the exception</param>
        public LWException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Create a new exception with a message, an inner exception and an event id
        /// </summary>
        /// <param name="message">This is the message for the exception</param>
        /// <param name="innerException">This is the inner exception for the exception</param>
        /// <param name="eventID">This is the event id for the exception</param>
        public LWException(string message, Exception innerException, int eventID) : base(message, innerException)
        {
            EventID = eventID;
        }
    }
}
