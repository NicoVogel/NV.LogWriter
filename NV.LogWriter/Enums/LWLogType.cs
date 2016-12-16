using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogWriter.Enums
{
    /// <summary>
    /// Define which log type to use
    /// </summary>
    public enum LWLogType
    {
        /// <summary>
        /// Log only important logs
        /// </summary>
        Release,
        /// <summary>
        /// Log debug logs
        /// </summary>
        Debug,
        /// <summary>
        /// Log everything
        /// </summary>
        All
    }
}
