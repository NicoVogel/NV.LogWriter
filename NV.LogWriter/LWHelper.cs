using System;
using System.Collections.Generic;

using LogWriter.Enums;
using LogWriter.Exceptions;
using LogWriter.Intrfaces;
using LogWriter.Properties;

namespace LogWriter
{
    /// <summary>
    /// Contain Methods that are needed in the log managers.
    /// </summary>
    internal static class LWHelper
    {

        /// <summary>
        /// This method check if the <see cref="ILWLogWriter"/> object can be used.
        /// </summary>
        /// <param name="writer">this parameter get checked.</param>
        /// <returns>return true if evrything is ok.</returns>
        public static bool TestILWLogWriter(ILWLogWriter writer)
        {
            if (writer == null)
                throw new LWLogWriterException(Resources.testWriterExceptionNull, DiagnosticEvents.ErrorHelpTestWriterNull);
            if (writer.Enabled && !writer.IsReadyToUse())
                throw new LWLogWriterException(Resources.testWriterExceptionNotReady, DiagnosticEvents.ErrorHelpTestWriterNotReade);

            return true;
        }



        /// <summary>
        /// This method read the log type by its level and the LogLevelModeSettings.
        /// </summary>
        /// <param name="log">This log get checked.</param>
        /// <param name="type">This is the current type.</param>
        /// <param name="logLevelModeSettings">This are the level mode settings.</param>
        /// <returns>If the log type is allowed, it return true, else false.</returns>
        public static bool CheckLogType(ILWLogData log, LWLogType type, Dictionary<LWLogLevel, LWLogType> logLevelModeSettings)
        {
            LWLogType logType = logLevelModeSettings[log.Category.LogLevel];

            switch (type)
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

            return false;
        }
    }
}
