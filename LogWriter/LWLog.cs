using System;
using System.Collections.Generic;
using LogWriter.Intrfaces;

namespace LogWriter
{
    /// <summary>
    /// Contain all information for the log
    /// </summary>
    public class LWLog : ILWLogData
    {

        private LWCategory m_category;
        private uint? m_logID;
        private string m_message;
        private DateTime m_logTime;
        private object m_value;



        #region Properties



        /// <summary>
        /// Category of the log
        /// </summary>
        public LWCategory Category
        {
            get
            {
                return m_category;
            }

            set
            {
                m_category = value;
            }
        }



        /// <summary>
        /// The ID of the log
        /// </summary>
        public uint? LogID
        {
            get
            {
                return m_logID;
            }

            set
            {
                m_logID = value;
            }
        }



        /// <summary>
        /// The main message for the log
        /// </summary>
        public string LogMessage
        {
            get
            {
                return m_message;
            }

            set
            {
                m_message = value;
            }
        }



        /// <summary>
        /// When the log got created
        /// </summary>
        public DateTime LogTime
        {
            get
            {
                return m_logTime;
            }
            private set
            {
                m_logTime = value;
            }
        }



        /// <summary>
        /// Additional log information
        /// </summary>
        public object Value
        {
            get
            {
                return m_value;
            }

            set
            {
                m_value = value;
            }
        }



        #endregion



        #region Constructors



        /// <summary>
        /// Create a log with the current date and time.
        /// </summary>
        public LWLog()
        {
            LogTime = DateTime.Now;
        }



        /// <summary>
        /// Create a log with the current date, time and a message
        /// </summary>
        /// <param name="message">Contain the log message.</param>
        public LWLog(string message) : this()
        {
            LogMessage = message;
        }



        /// <summary>
        /// Create a log with the current date, time, message and category.
        /// </summary>
        /// <param name="message">Contain the log message.</param>
        /// <param name="category">Contain the log category.</param>
        public LWLog(string message, LWCategory category) : this(message)
        {
            Category = category;
        }



        /// <summary>
        /// Create a log with the current date, time, message, category and log id.
        /// </summary>
        /// <param name="message">Contain the log message.</param>
        /// <param name="category">Contain the log category.</param>
        /// <param name="id">Contain the log id.</param>
        public LWLog(string message, LWCategory category, uint? id) : this(message, category)
        {
            LogID = id;
        }



        /// <summary>
        /// Create a log with the current date, time, message, category, log id and an additional object.
        /// </summary>
        /// <param name="message">Contain the log message.</param>
        /// <param name="category">Contain the log category.</param>
        /// <param name="id">Contain the log id.</param>
        /// <param name="value">Contain additional information that get added to the log.</param>
        public LWLog(string message, LWCategory category, uint? id, object value) : this(message, category, id)
        {
            Value = value;
        }



        #endregion



    }
}
