using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogWriter.Enums
{
    /// <summary>
    /// The levels a Log can have
    /// </summary>
    public enum LWLogLevel
    {
        /// <summary>
        /// No specific log level
        /// </summary>
        None,
        /// <summary>
        /// Critical log
        /// </summary>
        Critical,
        /// <summary>
        /// Error log
        /// </summary>
        Error,
        /// <summary>
        /// Warning log
        /// </summary>
        Warning,
        /// <summary>
        /// Information log
        /// </summary>
        Information,
        /// <summary>
        /// Verbose log
        /// </summary>
        Verbose
    }
}
