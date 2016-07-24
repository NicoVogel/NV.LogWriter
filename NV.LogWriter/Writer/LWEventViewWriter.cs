using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NV.LogWriter.Intrfaces;

namespace NV.LogWriter.Writer
{
    public class LWEventViewWriter : ILWLogWriter
    {

        private bool m_enabled = true;
        private string m_eventSource = "Application";
        private EventLog m_eventLog;
        


        #region Properties



        /// <summary>
        /// Enable the Logging in event view.
        /// <para></para>
        /// Default is true.
        /// </summary>
        public bool Enabled
        {
            get
            {
                return m_enabled;
            }

            set
            {
                m_enabled = value;
            }
        }



        /// <summary>
        /// Event source name.
        /// <para></para>
        /// Default is "Application".
        /// </summary>
        public string EventSource
        {
            get
            {
                if (String.IsNullOrEmpty(m_eventSource) && m_eventLog != null)
                    m_eventSource = m_eventLog.Source;
                return m_eventSource;
            }

            set
            {
                //TODO check if this name exist
                m_eventSource = value;
                if (m_eventLog != null)
                    m_eventLog.Source = value;
            }
        }



        #endregion




        public LWEventViewWriter()
        {

        }





        public bool IsReadyToUse()
        {
            return false;
        }

        public bool LogIsReadyToUse(ILWLogData log)
        {
            throw new NotImplementedException();
        }

        public bool LogIsReadyToUse<T>(ILWLogData log)
        {
            throw new NotImplementedException();
        }

        public void WriteLog(ILWLogData log)
        {
            throw new NotImplementedException();
        }

        public void WriteLog<t>(ILWLogData log)
        {
            throw new NotImplementedException();
        }
    }
}
