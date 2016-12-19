using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogWriter.Exceptions
{
    public static class DiagnosticEvents
    {
        public const int Base = 0;
        public const int LWManagerError = Base + 1;
        public const int LWManagerLogWriterIsNull = Base + 2;
        public const int LWManagerLogWriterIsNotReady = Base + 3;
        public const int LWManagerLogDataIsNull = Base + 4;


        public const int ErrorLogWriter = Base + 10;
        public const int ErrorLineCreatorSingleLogNotReady = Base + 11;
        public const int ErrorLineCreatorMultipleLogNotReady = Base + 12;


        public const int ErrorEventViewWriter = Base + 20;

        public const int ErrorHelpTestWriterNull = Base + 30;
        public const int ErrorHelpTestWriterNotReade = Base + 31;
    }
}
