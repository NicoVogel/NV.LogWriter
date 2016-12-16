using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogWriter.Intrfaces
{
    /// <summary>
    /// This create 
    /// </summary>
    public interface ILWLogFileLineCreator
    {

        /// <summary>
        /// Build a string out of the log file. This string get write into the log file.
        /// </summary>
        /// <param name="log">Create a string out of this object.</param>
        /// <returns>String for the next write in a file.</returns>
        string CreateLogFileLine(ILWLogData log);



        /// <summary>
        /// Build a string out of the log file. This string get write into the log file.
        /// </summary>
        /// <typeparam name="T">Object type of the log.</typeparam>
        /// <param name="log">Create a string out of this object.</param>
        /// <returns>String for the next write in a file.</returns>
        string CreateLogFileLine<T>(ILWLogData log) where T : ILWLogData;



        /// <summary>
        /// Check if it contain all information that are needed to create the log file line.
        /// </summary>
        /// <param name="log">This log gets checked.</param>
        /// <returns>true if this log can be used, false if not.</returns>
        bool LogIsReadyToUse(ILWLogData log);



        /// <summary>
        /// Check if it contain all information that are needed to create the log file line.
        /// </summary>
        /// <typeparam name="T">Object type of the log.</typeparam>
        /// <param name="log">This log gets checked.</param>
        /// <returns>>true if this log can be used, false if not.</returns>
        bool LogIsReadyToUse<T>(ILWLogData log) where T : ILWLogData;
    }
}
