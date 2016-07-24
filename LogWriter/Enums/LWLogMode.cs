using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogWriter.Enums
{

    /// <summary>
    /// Define which log mode to use
    /// </summary>
    public enum LWLogMode
    {
        /// <summary>
        /// Only log in eventview
        /// </summary>
        EventView,
        /// <summary>
        /// Only log in a file
        /// </summary>
        File,
        /// <summary>
        /// Log in eventview and file
        /// </summary>
        EventViewAndFile
    }

}
