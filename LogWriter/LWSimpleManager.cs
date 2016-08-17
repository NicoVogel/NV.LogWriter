using System;

using LogWriter.Enums;
using LogWriter.Writer;

namespace LogWriter
{
    /// <summary>
    /// This is used to write logs without the flexebility of <see cref="LWManager"/>.
    /// </summary>
    public class LWSimpleManager
    {

        private LWEventViewWriter m_eventView;
        private LWLogFileWriter m_logFile;



        #region Properties



        /// <summary>
        /// This object wirte the log in the event view.
        /// <para>Default is <see cref="EventViewWriterDefault"/>.</para>
        /// </summary>
        public LWEventViewWriter EventViewWriter
        {
            get
            {
                if (m_eventView == null)
                    m_eventView = new LWEventViewWriter();
                return m_eventView;
            }

            set
            {
                m_eventView = value;
            }
        }



        /// <summary>
        /// This object wirte the log file.
        /// <para>Default is <see cref="LogFileWriterDefault"/>.</para>
        /// </summary>
        public LWLogFileWriter LogFileWriter
        {
            get
            {
                if (m_logFile == null)
                    m_logFile = new LWLogFileWriter();
                return m_logFile;
            }

            set
            {
                m_logFile = value;
            }
        }



        #endregion

        #region Constructors



        /// <summary>
        /// Create a new instance of <see cref="LWManager"/>.
        /// </summary>
        public LWSimpleManager()
        {

        }



        #endregion

        #region Public Methods



        /// <summary>
        /// Write a log.
        /// </summary>
        /// <param name="logID">id of the log</param>
        /// <param name="message">message of the log</param>
        /// <param name="value">more information for the log</param>
        /// <param name="type">specifiy which type the log has.</param>
        /// <param name="mode">define where the log should be posted.</param>
        /// <returns></returns>
        public bool Trace(uint logID, string message, object value, LWLogLevel type, LWLogMode mode)
        {
            var log = new LWLog(message, LWCategory.DefaultSet[type.ToString()], logID, value);
            bool eventView = false;
            bool logFile = false;

            if ((mode & LWLogMode.EventView) == LWLogMode.EventView)
                eventView = LWHelper.TestILWLogWriter(EventViewWriter);
            if ((mode & LWLogMode.File) == LWLogMode.File)
                logFile = LWHelper.TestILWLogWriter(LogFileWriter);
            try
            {
                if (eventView && EventViewWriter.LogIsReadyToUse(log))
                    EventViewWriter.WriteLog(log);

                if (logFile && LogFileWriter.LogIsReadyToUse(log))
                    LogFileWriter.WriteLog(log);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }



        /// <summary>
        /// Write a log with the <see cref="LWLogLevel.None"/>.
        /// </summary>
        /// <param name="logID">id of the log</param>
        /// <param name="message">message of the log</param>
        /// <param name="value">more information for the log</param>
        /// <param name="mode">define where the log should be posted.</param>
        /// <returns></returns>
        public bool TraceNone(uint logID, string message, object value, LWLogMode mode = LWLogMode.File)
        {
            return Trace(logID, message, value, LWLogLevel.None, mode);
        }



        /// <summary>
        /// Write a log with the <see cref="LWLogLevel.Critical"/>.
        /// </summary>
        /// <param name="logID">id of the log</param>
        /// <param name="message">message of the log</param>
        /// <param name="value">more information for the log</param>
        /// <param name="mode">define where the log should be posted.</param>
        public bool TraceCritical(uint logID, string message, object value, LWLogMode mode = LWLogMode.File)
        {
            return Trace(logID, message, value, LWLogLevel.Critical, mode);
        }



        /// <summary>
        /// Write a log with the <see cref="LWLogLevel.Error"/>.
        /// </summary>
        /// <param name="logID">id of the log</param>
        /// <param name="message">message of the log</param>
        /// <param name="value">more information for the log</param>
        /// <param name="mode">define where the log should be posted.</param>
        public bool TraceError(uint logID, string message, object value, LWLogMode mode = LWLogMode.File)
        {
            return Trace(logID, message, value, LWLogLevel.Error, mode);
        }



        /// <summary>
        /// Write a log with the <see cref="LWLogLevel.Warning"/>.
        /// </summary>
        /// <param name="logID">id of the log</param>
        /// <param name="message">message of the log</param>
        /// <param name="value">more information for the log</param>
        /// <param name="mode">define where the log should be posted.</param>
        public bool TraceWarning(uint logID, string message, object value, LWLogMode mode = LWLogMode.File)
        {
            return Trace(logID, message, value, LWLogLevel.Warning, mode);
        }



        /// <summary>
        /// Write a log with the <see cref="LWLogLevel.Information"/>.
        /// </summary>
        /// <param name="logID">id of the log</param>
        /// <param name="message">message of the log</param>
        /// <param name="value">more information for the log</param>
        /// <param name="mode">define where the log should be posted.</param>
        public bool TraceInformation(uint logID, string message, object value, LWLogMode mode = LWLogMode.File)
        {
            return Trace(logID, message, value, LWLogLevel.Information, mode);
        }



        /// <summary>
        /// Write a log with the <see cref="LWLogLevel.Verbose"/>.
        /// </summary>
        /// <param name="logID">id of the log</param>
        /// <param name="message">message of the log</param>
        /// <param name="value">more information for the log</param>
        /// <param name="mode">define where the log should be posted.</param>
        public bool TraceVerbose(uint logID, string message, object value, LWLogMode mode = LWLogMode.File)
        {
            return Trace(logID, message, value, LWLogLevel.Verbose, mode);
        }




        #endregion




    }
}
