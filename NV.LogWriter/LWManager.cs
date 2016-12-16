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
    public class LWManager
    {

        private ILWLogWriter m_eventView;
        private ILWLogWriter m_logFile;

        private LWLogType m_type;
        private LWLogMode m_mode;
        private Guid m_processID;
        private Dictionary<LWLogLevel, LWLogType> m_logLevelModeSettings;



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
        /// Defines which level is for which log mode.
        /// </summary>
        public Dictionary<LWLogLevel, LWLogType> LogLevelModeSettings
        {
            get
            {
                if (m_logLevelModeSettings == null)
                    m_logLevelModeSettings = LogLevelModeSettingsDefault;
                return m_logLevelModeSettings;
            }

            set
            {
                m_logLevelModeSettings = value;
            }
        }



        /// <summary>
        /// The default settings for the <see cref="LogLevelModeSettings"/>.
        /// </summary>
        public Dictionary<LWLogLevel, LWLogType> LogLevelModeSettingsDefault
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
        /// ID of the process
        /// </summary>
        public Guid ProcessID
        {
            get
            {
                return m_processID;
            }

            set
            {
                m_processID = value;
            }
        }



        /// <summary>
        /// This object wirte the log in the event view.
        /// <para>Default is <see cref="EventViewWriterDefault"/>.</para>
        /// </summary>
        public ILWLogWriter EventViewWriter
        {
            get
            {
                if (m_eventView == null)
                    m_eventView = EventViewWriterDefault;
                return m_eventView;
            }

            set
            {
                m_eventView = value;
            }
        }



        /// <summary>
        /// The default Event View Writer
        /// </summary>
        public ILWLogWriter EventViewWriterDefault
        {
            get
            {
                return new LWEventViewWriter();
            }
        }



        /// <summary>
        /// This object wirte the log file.
        /// <para>Default is <see cref="LogFileWriterDefault"/>.</para>
        /// </summary>
        public ILWLogWriter LogFileWriter
        {
            get
            {
                if (m_logFile == null)
                    m_logFile = LogFileWriterDefault;
                return m_logFile;
            }

            set
            {
                m_logFile = value;
            }
        }



        /// <summary>
        /// The default Log File Writer
        /// </summary>
        public ILWLogWriter LogFileWriterDefault
        {
            get
            {
                return new LWLogFileWriter();
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



        #endregion
        
        #region Constructors



        /// <summary>
        /// Create a new instance of <see cref="LWManager"/>.
        /// <para><see cref="LogLevelModeSettings"/> are set to default.</para>
        /// <see cref="Type"/> is set to <see cref="LWLogType.Release"/>.
        /// </summary>
        public LWManager()
        {
            LogLevelModeSettings = LogLevelModeSettingsDefault;
            Type = LWLogType.Release;
            Mode = LWLogMode.EventView;
        }



        /// <summary>
        /// Create a new instance of <see cref="LWManager"/>.
        /// <para><see cref="LogLevelModeSettings"/> are set to default.</para>
        /// <see cref="Type"/> is set to <see cref="LWLogType.Release"/>.
        /// </summary>
        /// <param name="processID">Set the processID</param>
        public LWManager(Guid processID) : this()
        {
            ProcessID = processID;
        }



        /// <summary>
        /// Create a new instance of <see cref="LWManager"/>.
        /// <para><see cref="LogLevelModeSettings"/> are set to default.</para>
        /// <see cref="Type"/> is set to <paramref name="type"/>.
        /// </summary>
        /// <param name="processID">Set the processID</param>
        /// <param name="type">This is the type for the log manager.</param>
        public LWManager(Guid processID, LWLogType type) : this(processID)
        {
            Type = type;
        }



        /// <summary>
        /// Create a new instance of <see cref="LWManager"/>.
        /// <para><see cref="LogLevelModeSettings"/> are set to default.</para>
        /// <see cref="Type"/> is set to <paramref name="mode"/>.
        /// </summary>
        /// <param name="processID">Set the processID</param>
        /// <param name="mode">This is the mode for the log manager.</param>
        public LWManager(Guid processID, LWLogMode mode) : this(processID)
        {
            Mode = mode;
        }



        /// <summary>
        /// Create a new instance of <see cref="LWManager"/>.
        /// <para><see cref="LogLevelModeSettings"/> are set to default.</para>
        /// <see cref="Type"/> is set to <paramref name="mode"/>.
        /// </summary>
        /// <param name="processID">Set the processID</param>
        /// <param name="type">This is the type for the log manager.</param>
        /// <param name="mode">This is the mode for the log manager.</param>
        public LWManager(Guid processID, LWLogType type, LWLogMode mode) : this(processID)
        {
            Mode = mode;
            Type = type;
        }



        #endregion
        
        #region Public Methods



        /// <summary>
        /// Write a log in the Eventview and to a local File
        /// </summary>
        /// <param name="log">This log get write.</param>
        /// <returns>true if nothing went wrong, else false</returns>
        public bool WriteLog(ILWLogData log)
        {
            //one go further if the log type get logged.
            if (LWHelper.CheckLogType(log, Type, LogLevelModeSettings))
            {
                bool eventView = false;
                bool logFile = false;

                if ((Mode & LWLogMode.EventView) == LWLogMode.EventView)
                    eventView = LWHelper.TestILWLogWriter(EventViewWriter);
                if ((Mode & LWLogMode.File) == LWLogMode.File)


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
            }
            return true;
        }



        #endregion
        
    }
}
