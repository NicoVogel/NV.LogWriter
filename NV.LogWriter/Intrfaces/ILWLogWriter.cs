using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NV.LogWriter.Intrfaces
{
    /// <summary>
    /// This interface is used to create an log writer.
    /// </summary>
    public interface ILWLogWriter
    {

        #region Property



        /// <summary>
        /// Enable or Disable this <see cref="ILWLogWriter"/>.
        /// <para></para>
        /// Default is true
        /// </summary>
        bool Enabled { get; set; }



        #endregion



        /// <summary>
        /// Check if this <see cref="ILWLogWriter"/> is ready to wirte logs.
        /// </summary>
        /// <returns></returns>
        bool IsReadyToUse();



        /// <summary>
        /// Check if the <see cref="ILWLogData"/> has enough data to be used from this <see cref="ILWLogWriter"/>.
        /// </summary>
        /// <param name="log"></param>
        /// <returns>true if it is ready, false if not.</returns>
        bool LogIsReadyToUse(ILWLogData log);



        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="log"></param>
        /// <returns></returns>
        bool LogIsReadyToUse<T>(ILWLogData log);



        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        void WriteLog(ILWLogData log);



        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="t"></typeparam>
        /// <param name="log"></param>
        void WriteLog<t>(ILWLogData log);



    }
}
