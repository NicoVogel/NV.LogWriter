using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NV.LogWriter.Intrfaces
{
    /// <summary>
    /// This interface is used to create a log dataset.
    /// </summary>
    public interface ILWLogData
    {


        #region Properties



        /// <summary>
        /// When the log got created
        /// </summary>
        DateTime LogTime { get; }



        /// <summary>
        /// Category of the log
        /// </summary>
        LWCategory Category { get; set; }



        /// <summary>
        /// The main message for the log
        /// </summary>
        string LogMessage { get; set; }

        

        /// <summary>
        /// The ID of the log
        /// </summary>
        uint? LogID { get; set; }



        /// <summary>
        /// object that get also logged
        /// </summary>
        object Value { get; set; }



        #endregion
        


    }
}
