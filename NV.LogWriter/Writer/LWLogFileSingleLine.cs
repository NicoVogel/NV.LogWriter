using System;
using NV.LogWriter.Exceptions;
using NV.LogWriter.Intrfaces;
using NV.LogWriter.Properties;

namespace NV.LogWriter.Writer
{
    /// <summary>
    /// Create a single log line of a <see cref="ILWLogData"/>.
    /// </summary>
    public class LWLogFileSingleLine : ILWLogFileLineCreator
    {

        /// <summary>
        /// Create a string out of a log file with one line.
        /// </summary>
        /// <param name="log">Create the log with this object.</param>
        /// <returns>Return a string with one line.</returns>
        /// <exception cref="LWLogDataNotReadyException"></exception>
        public string CreateLogFileLine(ILWLogData log)
        {
            if (!LogIsReadyToUse(log))
                throw new LWLogDataNotReadyException(nameof(log), Resources.testLogDataExceptionNotReady);
            return String.Format(Resources.SLWriter,
                log.LogTime,
                log.LogID == null ? Resources.SLWriterID : log.LogID.ToString(),
                log.Category,
                log.LogMessage,
                log.Value);
        }



        /// <summary>
        /// Is the same as <see cref="CreateLogFileLine(ILWLogData)"/>.
        /// Create a string out of a log file with one line.
        /// </summary>
        /// <typeparam name="T">Object type of the log.</typeparam>
        /// <param name="log">Create the log with this object.</param>
        /// <returns>Return a string with one line.</returns>
        /// <exception cref="LWLogDataNotReadyException"></exception>
        public string CreateLogFileLine<T>(ILWLogData log) where T : ILWLogData
        {
            return CreateLogFileLine(log);
        }



        /// <summary>
        /// Check if log is ready to use.
        /// <para>LogTime must have a value</para>
        /// <para>Category must be an instance and the name could not be empty</para>
        /// <para>LogMessage must have a value</para>
        /// </summary>
        /// <param name="log">Check this log object.</param>
        /// <returns>True if the log is ready, false if not.</returns>
        public bool LogIsReadyToUse(ILWLogData log)
        {
            return
                (log.LogTime != null) &&
                (log.Category != null && !String.IsNullOrEmpty(log.Category.Name)) &&
                (!String.IsNullOrEmpty(log.LogMessage));
        }



        /// <summary>
        /// Is the same as <see cref="LogIsReadyToUse(ILWLogData)"/>.
        /// Check if log is ready to use.
        /// <para>LogTime must have a value</para>
        /// <para>Category must be an instance and the name could not be empty</para>
        /// <para>LogMessage must have a value</para>
        /// </summary>
        /// <typeparam name="T">Object type of the log.</typeparam>
        /// <param name="log">Check this log object.</param>
        /// <returns>True if the log is ready, false if not.</returns>
        public bool LogIsReadyToUse<T>(ILWLogData log) where T : ILWLogData
        {
            return LogIsReadyToUse(log);
        }
    }
}
