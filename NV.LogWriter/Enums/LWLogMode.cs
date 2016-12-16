using System;

namespace LogWriter.Enums
{

    /// <summary>
    /// Define which log mode to use.
    /// </summary>
    [Flags]
    public enum LWLogMode
    {
        /// <summary>
        /// Only log in eventview
        /// </summary>
        EventView = 1,
        /// <summary>
        /// Only log in a file
        /// </summary>
        File = 2,
    }

}
