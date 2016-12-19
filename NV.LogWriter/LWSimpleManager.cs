using System;
using System.Collections.Generic;

using LogWriter.Enums;
using LogWriter.Exceptions;
using LogWriter.Intrfaces;
using LogWriter.Properties;
using LogWriter.Writer;

namespace LogWriter
{
    /// <summary>
    /// This class create logs.
    /// </summary>
    public class LWSimpleManager
    {

        private LWEventViewWriter m_eventView;
        private LWLogFileWriter m_logFile;

        private LWLogType m_type;
        private LWLogMode m_mode;
        private Guid m_processID;



        #region Properties



        /// <summary>
        /// Set the log type. 
        /// <para>Default is <see cref="LWLogType.Release"/>.</para>
        /// </summary>
        public LWLogType Type
        {
            get
            {
                return m_type;
            }

            set
            {
                m_type = value;
            }
        }



        /// <summary>
        /// The default settings for the <see cref="LogLevelModeSettings"/>.
        /// </summary>
        public Dictionary<LWLogLevel, LWLogType> LogLevelModeSettings
        {
            get
            {
                return new Dictionary<LWLogLevel, LWLogType>
                {
                    { LWLogLevel.None, LWLogType.All },
                    { LWLogLevel.Information, LWLogType.Debug },
                    { LWLogLevel.Verbose, LWLogType.Debug },
                    { LWLogLevel.Critical, LWLogType.Release },
                    { LWLogLevel.Error, LWLogType.Release },
                    { LWLogLevel.Warning, LWLogType.Release },
                };
            }
        }



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



        /// <summary>
        /// Define the logging mode.
        /// <para>Default is <see cref="LWLogMode.EventView"/>.</para>
        /// </summary>
        public LWLogMode Mode
        {
            get
            {
                return m_mode;
            }

            set
            {
                m_mode = value;
            }
        }



        public Dictionary<string, LWCategory> Categorys
        {
            get
            {
                var defaultSet = new Dictionary<string, LWCategory>();
                foreach (LWLogLevel item in Enum.GetValues(typeof(LWLogLevel)))
                {
                    defaultSet.Add(nameof(item), new LWCategory(nameof(item), item));
                }
                return defaultSet;
            }
        }


        #endregion



        #region Constructors



        /// <summary>
        /// Create a new instance of <see cref="LWManager"/>.
        /// <para><see cref="LogLevelModeSettings"/> are set to default.</para>
        /// <see cref="Type"/> is set to <see cref="LWLogType.Release"/>.
        /// </summary>
        public LWSimpleManager()
        {
            Type = LWLogType.Release;
            Mode = LWLogMode.EventView;
        }



        /// <summary>
        /// Create a new instance of <see cref="LWManager"/>.
        /// <para><see cref="LogLevelModeSettings"/> are set to default.</para>
        /// <see cref="Type"/> is set to <paramref name="type"/>.
        /// </summary>
        /// <param name="type">This is the type for the log manager.</param>
        public LWSimpleManager(LWLogType type) : this()
        {
            Type = type;
        }



        /// <summary>
        /// Create a new instance of <see cref="LWManager"/>.
        /// <para><see cref="LogLevelModeSettings"/> are set to default.</para>
        /// <see cref="Type"/> is set to <paramref name="mode"/>.
        /// </summary>
        /// <param name="mode">This is the mode for the log manager.</param>
        public LWSimpleManager(LWLogMode mode) : this()
        {
            Mode = mode;
        }



        /// <summary>
        /// Create a new instance of <see cref="LWManager"/>.
        /// <para><see cref="LogLevelModeSettings"/> are set to default.</para>
        /// <see cref="Type"/> is set to <paramref name="mode"/>.
        /// </summary>
        /// <param name="type">This is the type for the log manager.</param>
        /// <param name="mode">This is the mode for the log manager.</param>
        public LWSimpleManager(LWLogType type, LWLogMode mode) : this()
        {
            Mode = mode;
            Type = type;
        }



        #endregion



        #region Public Methods



        /// <summary>
        /// Write a log with the category None.
        /// </summary>
        /// <param name="message">this message get logged.</param>
        /// <param name="id">log id</param>
        /// <param name="value">additional value</param>
        /// <returns></returns>
        public void WriteLogNone(string message, uint id, object value = null)
        {
            try
            {
                log(new LWLog(message, Categorys[nameof(LWLogLevel.None)], id, value));
            }
            catch (LWException lwEx)
            {
                throw lwEx;
            }
            catch (Exception ex)
            {
                throw new LWLogManagerException(Resources.ErrorUnexpectedManagerException + ex.Message, DiagnosticEvents.LWManagerError);
            }
        }



        /// <summary>
        /// Write a log with the category Information.
        /// </summary>
        /// <param name="message">this message get logged.</param>
        /// <param name="id">log id</param>
        /// <param name="value">additional value</param>
        /// <returns></returns>
        public void WriteLogInformation(string message, uint id, object value = null)
        {
            try
            {
                log(new LWLog(message, Categorys[nameof(LWLogLevel.Information)], id, value));
            }
            catch (LWException lwEx)
            {
                throw lwEx;
            }
            catch (Exception ex)
            {
                throw new LWLogManagerException(Resources.ErrorUnexpectedManagerException + ex.Message, DiagnosticEvents.LWManagerError);
            }
        }



        /// <summary>
        /// Write a log with the category Verbose.
        /// </summary>
        /// <param name="message">this message get logged.</param>
        /// <param name="id">log id</param>
        /// <param name="value">additional value</param>
        /// <returns></returns>
        public void WriteLogVerbose(string message, uint id, object value = null)
        {
            try
            {
                log(new LWLog(message, Categorys[nameof(LWLogLevel.Verbose)], id, value));
            }
            catch (LWException lwEx)
            {
                throw lwEx;
            }
            catch (Exception ex)
            {
                throw new LWLogManagerException(Resources.ErrorUnexpectedManagerException + ex.Message, DiagnosticEvents.LWManagerError);
            }
        }



        /// <summary>
        /// Write a log with the category Warning.
        /// </summary>
        /// <param name="message">this message get logged.</param>
        /// <param name="id">log id</param>
        /// <param name="value">additional value</param>
        /// <returns></returns>
        public void WriteLogWarning(string message, uint id, object value = null)
        {
            try
            {
                log(new LWLog(message, Categorys[nameof(LWLogLevel.Warning)], id, value));
            }
            catch (LWException lwEx)
            {
                throw lwEx;
            }
            catch (Exception ex)
            {
                throw new LWLogManagerException(Resources.ErrorUnexpectedManagerException + ex.Message, DiagnosticEvents.LWManagerError);
            }
        }



        /// <summary>
        /// Write a log with the category Error.
        /// </summary>
        /// <param name="message">this message get logged.</param>
        /// <param name="id">log id</param>
        /// <param name="value">additional value</param>
        /// <returns></returns>
        public void WriteLogError(string message, uint id, object value = null)
        {
            try
            {
                log(new LWLog(message, Categorys[nameof(LWLogLevel.Error)], id, value));
            }
            catch (LWException lwEx)
            {
                throw lwEx;
            }
            catch (Exception ex)
            {
                throw new LWLogManagerException(Resources.ErrorUnexpectedManagerException + ex.Message, DiagnosticEvents.LWManagerError);
            }
        }



        /// <summary>
        /// Write a log with the category Critical.
        /// </summary>
        /// <param name="message">this message get logged.</param>
        /// <param name="id">log id</param>
        /// <param name="value">additional value</param>
        /// <returns></returns>
        public void WriteLogCritical(string message, uint id, object value = null)
        {
            try
            {
                log(new LWLog(message, Categorys[nameof(LWLogLevel.Critical)], id, value));
            }
            catch (LWException lwEx)
            {
                throw lwEx;
            }
            catch (Exception ex)
            {
                throw new LWLogManagerException(Resources.ErrorUnexpectedManagerException + ex.Message, DiagnosticEvents.LWManagerError);
            }
        }



        #endregion



        #region Private Method


        private void log(LWLog log)
        {
            if (!String.IsNullOrEmpty(log.LogMessage))
            {
                bool eventView = false;
                bool logFile = false;

                if (Mode == LWLogMode.EventView || Mode == LWLogMode.EventViewAndFile)
                    eventView = testILWLogWriter(EventViewWriter);
                if (Mode == LWLogMode.File || Mode == LWLogMode.EventViewAndFile)
                    logFile = testILWLogWriter(LogFileWriter);



                if (eventView && EventViewWriter.LogIsReadyToUse(log))
                    EventViewWriter.WriteLog(log);

                if (logFile && LogFileWriter.LogIsReadyToUse(log))
                    LogFileWriter.WriteLog(log);
            }
            else
                throw new LWLogManagerException(Resources.ErrorMessageEmpty, DiagnosticEvents.LWManagerError);
        }



        /// <summary>
        /// This method check if the <see cref="ILWLogWriter"/> object can be used.
        /// </summary>
        /// <returns>return true if evrything is ok.</returns>
        private bool testILWLogWriter(ILWLogWriter writer)
        {
            if (writer == null)
                throw new LWLogWriterException(Resources.ErrorWriterIsNull, DiagnosticEvents.LWManagerLogWriterIsNull);
            if (writer.Enabled && !writer.IsReadyToUse())
                throw new LWLogWriterException(Resources.ErrorWriterNotReady, DiagnosticEvents.LWManagerLogWriterIsNotReady);

            return true;
        }



        /// <summary>
        /// This method read the log type by its level and the LogLevelModeSettings.
        /// </summary>
        /// <param name="log">This log get checked.</param>
        /// <returns>If the log type is allowed, it return true, else false.</returns>
        private bool checkLogType(ILWLogData log)
        {
            if (log != null)
            {
                LWLogType logType = LogLevelModeSettings[log.Category.LogLevel];

                switch (Type)
                {
                    case LWLogType.Release:
                        //If it is Release, it is allowed. The other two aren't allowed.
                        if (logType == LWLogType.Release)
                            return true;
                        break;
                    case LWLogType.Debug:
                        //If it is not All, it must be Debug or Release and both are allowed.
                        if (logType != LWLogType.All)
                            return true;
                        break;
                    case LWLogType.All:
                        //all types are allowed
                        return true;
                    default:
                        break;
                }
            }
            else
                throw new LWLogDataException(Resources.ErrorLogDataIsNull, DiagnosticEvents.LWManagerLogDataIsNull);
            return false;
        }



        #endregion



    }
}
