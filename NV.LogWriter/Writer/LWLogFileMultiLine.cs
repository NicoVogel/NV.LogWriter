﻿using System;
using System.Text;
using LogWriter.Exceptions;
using LogWriter.Intrfaces;
using LogWriter.Properties;

namespace LogWriter.Writer
{
    /// <summary>
    /// Create a multiple log line of a <see cref="ILWLogData"/>.
    /// </summary>
    public class LWLogFileMultiLine : ILWLogFileLineCreator
    {

        /// <summary>
        /// Create a string out of a log file with multiple lines.
        /// </summary>
        /// <param name="log">Create the log with this object.</param>
        /// <returns>Return a string with multiple lines.</returns>
        /// <exception cref="LWLogDataException"></exception>
        public string CreateLogFileLine(ILWLogData log)
        {
            if (!LogIsReadyToUse(log))
                throw new LWLogDataException(Resources.ErrorLogDataNotReady, DiagnosticEvents.ErrorLineCreatorMultipleLogNotReady);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format(Resources.MLWriterDateTime, log.LogTime));
            sb.AppendLine(String.Format(Resources.MLWriterID, log.LogID));
            sb.AppendLine(String.Format(Resources.MLWriterCategory, log.Category));
            sb.AppendLine(String.Format(Resources.MLWriterMessage, log.LogMessage));
            sb.AppendLine(String.Format(Resources.MLWriterObject, log.Value));
            sb.Append(Resources.MLWriterBreaks);
            return sb.ToString();
        }



        /// <summary>
        /// Is the same as <see cref="CreateLogFileLine(ILWLogData)"/>.
        /// Create a string out of a log file with multiple lines.
        /// </summary>
        /// <typeparam name="T">Object type of the log.</typeparam>
        /// <param name="log">Create the log with this object.</param>
        /// <returns>Return a string with multiple lines.</returns>
        /// <exception cref="LWLogDataException"></exception>
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
