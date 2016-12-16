using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogWriter.Writer
{
    /// <summary>
    /// Define in which interval a new log file is created
    /// </summary>
    public enum LWFileWriteMode
    {
        /// <summary>
        /// Write all logs in one file.
        /// </summary>
        OneFile,
        /// <summary>
        /// Create new file after a defined amount of logs.
        /// </summary>
        AfterAmountOfLogs
    }
}
