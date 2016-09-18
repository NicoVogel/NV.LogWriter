using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogWriter.Intrfaces;

namespace Test
{
    class FackeWriter : ILWLogWriter
    {

        private bool m_enabled;
        public ILWLogData LastLog{ get; set; }



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

        public bool IsReadyToUse()
        {
            return true;
        }

        public bool LogIsReadyToUse(ILWLogData log)
        {
            return true;
        }

        public void WriteLog(ILWLogData log)
        {
            LastLog = log;
        }

        public bool LogIsReadyToUse<T>(ILWLogData log)
        {
            return LogIsReadyToUse(log);
        }

        public void WriteLog<t>(ILWLogData log)
        {
            LastLog = log;
        }

        public FackeWriter()
        {
            Enabled = true;
            LastLog = null;
        }
    }
}
