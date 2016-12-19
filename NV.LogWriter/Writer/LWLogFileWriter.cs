using System;
using System.IO;
using System.Linq;

using FileParser.Parser;
using LogWriter.Intrfaces;
using LogWriter.Properties;
using FileParser.Parser;
using LogWriter.Intrfaces;
using LogWriter.Exceptions;
using LogWriter.Properties;
using System.Text.RegularExpressions;
using System.Reflection;

namespace LogWriter.Writer
{
    /// <summary>
    /// This class write logs in a file and manage this process.
    /// </summary>
    public class LWLogFileWriter : ILWLogWriter
    {

        private bool m_enabled = true;
        private string m_logPath;
        private string m_fileName;
        private string m_fileNamePrefix;
        private string m_fileExtetion;
        private uint m_numberLength = 5;
        private uint m_amountOfRowsPerFile = 1000;
        private uint m_currentNumber;
        private LWFileWriteMode m_writeMode = LWFileWriteMode.AfterAmountOfLogs;
        private ILWLogFileLineCreator m_lineCreator;



        #region Properties



        /// <summary>
        /// Where the log get created.
        /// <para>Default is the folder of the assembly + \Logs</para>
        /// </summary>
        public string LogPath
        {
            get
            {
                if (String.IsNullOrEmpty(m_logPath))
                {
                    var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\Logs";
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(m_logPath);
                    LogPath = path;
                }
                return m_logPath;
            }

            set
            {
                m_logPath = value;
                FileName = getNextNumber();
            }
        }



        /// <summary>
        /// Set a prefix for the log file.
        /// <para></para>
        /// Default is defined in the Resources.resx
        /// </summary>
        public string FileNamePrefix
        {
            get
            {
                if (String.IsNullOrEmpty(m_fileNamePrefix))
                    m_fileNamePrefix = Resources.logFileNamePrefix;
                return m_fileNamePrefix;
            }

            set
            {
                m_fileNamePrefix = value;
                FileName = getNextNumber();
            }
        }



        /// <summary>
        /// This is the full file name of the log. its build out of the prefix, file name, a increasing number and the extention.
        /// </summary>
        public string FullFileName
        {
            get
            {
                return m_fileNamePrefix + m_fileName + CurrentNumber + "." + m_fileExtetion;
            }
        }



        /// <summary>
        /// This is the full file name of the next log. its build out of the prefix, file name, a increasing number and the extention.
        /// </summary>
        public string NextFullFileName
        {
            get
            {
                return m_fileNamePrefix + m_fileName + getNextNumber() + "." + m_fileExtetion;
            }
        }



        /// <summary>
        /// This is the file name of the log.
        /// </summary>
        public string FileName
        {
            get
            {
                return m_fileName;
            }

            private set
            {
                m_fileName = value;
            }
        }



        /// <summary>
        /// Defines after what amount of logs a new file get created.
        /// <para>Default is 1000 (Range 100-1000000)</para>
        /// This is only in use if <see cref="WriteMode"/> is set to <see cref="LWFileWrite.LogFileWriteMode.AfterAmountOfLogs"/>.
        /// </summary>
        public uint AmountOfRowsPerFile
        {
            get
            {
                return m_amountOfRowsPerFile;
            }

            set
            {
                if (value == 0)
                    m_amountOfRowsPerFile = 100;
                else if (value > 1000000)
                    m_amountOfRowsPerFile = 1000000;
                else
                    m_amountOfRowsPerFile = value;
            }
        }



        /// <summary>
        /// This is the wirte mode for the <see cref="LWManager"/>.
        /// <para></para>
        /// Default id <see cref="LWFileWriteMode.AfterAmountOfLogs"/>
        /// </summary>
        public LWFileWriteMode WriteMode
        {
            get
            {
                return m_writeMode;
            }

            set
            {
                m_writeMode = value;
            }
        }



        /// <summary>
        /// Enable the Logging in a file
        /// <para></para>
        /// Default is true
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
        /// This object create a string that get write in the log file.
        /// If it is null than it return the default.
        /// </summary>
        public ILWLogFileLineCreator LineCreator
        {
            get
            {
                if (m_lineCreator == null)
                    m_lineCreator = DefaultLineCreator;
                return m_lineCreator;
            }

            set
            {
                m_lineCreator = value;
            }
        }



        /// <summary>
        /// Return the default <see cref="ILWLogFileLineCreator"/>.
        /// Default is <see cref="LWLogFileMultiLine"/>.
        /// </summary>
        public ILWLogFileLineCreator DefaultLineCreator
        {
            get
            {
                return new LWLogFileMultiLine();
            }
        }



        /// <summary>
        /// Is the minimum length of the <see cref="FileName"/> number.
        /// <para>The Default is 5.</para>
        /// The number cannot be bigger than 20. If its 0 than it become default.
        /// </summary>
        public uint NumberLength
        {
            get
            {
                if (m_numberLength == 0)
                    m_numberLength = 5;
                return m_numberLength;
            }

            set
            {
                if (m_numberLength == 0)
                    m_numberLength = 5;
                if (m_numberLength > 20)
                    m_numberLength = 20;
                m_numberLength = value;
            }
        }



        /// <summary>
        /// This is the extention of the file.
        /// <para>Default is "txt".</para>
        /// </summary>
        public string FileExtetion
        {
            get
            {
                if (String.IsNullOrEmpty(m_fileExtetion))
                    m_fileExtetion = "txt";
                return m_fileExtetion;
            }

            set
            {
                m_fileExtetion = value;
            }
        }



        /// <summary>
        /// Contain the current log file number
        /// </summary>
        public uint CurrentNumber
        {
            get
            {
                if (m_currentNumber == 0)
                    m_currentNumber = getHighestLogNumber();
                return m_currentNumber;
            }

            private set
            {
                m_currentNumber = value;
            }
        }



        #endregion



        #region Constructors



        /// <summary>
        /// create a new instance of <see cref="LWLogFileWriter"/>.
        /// </summary>
        public LWLogFileWriter()
        {
        }



        #endregion



        #region Public Methods
        


        /// <summary>
        /// Check if the propertys are filled correctly.
        /// <para>LogPath: not null or empty, valid path name and must exist.</para>
        /// <para>FullFileName: valid file name.</para>
        /// </summary>
        /// <returns>True if the object is ready to write log files, false if not.</returns>
        public bool IsReadyToUse()
        {
            if (String.IsNullOrEmpty(LogPath) || !IsValidFilename(LogPath) || !Directory.Exists(LogPath))
                return false;

            if (!IsValidFilename(FullFileName))
                return false;
            
            return true;
        }



        /// <summary>
        /// Ckeck if the log can be written in the log file.
        /// </summary>
        /// <param name="log">This log get checked.</param>
        /// <returns>True if this log can be written in the log file, false if not.</returns>
        public bool LogIsReadyToUse(ILWLogData log)
        {
            return LineCreator.LogIsReadyToUse(log);
        }



        /// <summary>
        /// Is the same as <see cref="LogIsReadyToUse(ILWLogData)"/>
        /// Ckeck if the log can be written in the log file.
        /// </summary>
        /// <typeparam name="T">Object type of the log.</typeparam>
        /// <param name="log">This log get checked.</param>
        /// <returns>True if this log can be written in the log file, false if not.</returns>
        public bool LogIsReadyToUse<T>(ILWLogData log)
        {
            return LogIsReadyToUse(log);
        }

        

        /// <summary>
        /// This method write the next log in the log file.
        /// </summary>
        /// <param name="log">this log get written.</param>
        public void WriteLog(ILWLogData log)
        {
            try
            {
                var saver = new FPTextSaveLoad();
                if (IsReadyToUse())
                {
                    string nextLog = LineCreator.CreateLogFileLine(log);
                    string filePath = String.Format(LogPath + "/" + FullFileName);
                    string[] rows;
                    if (saver.LoadRows(filePath, out rows))
                    {
                        if (rows.Length > AmountOfRowsPerFile)
                            filePath = String.Format(LogPath + "/" + NextFullFileName);
                        else
                            nextLog = String.Join(Environment.NewLine, rows) + Environment.NewLine + nextLog;
                        saver.Save(nextLog, filePath);
                    }
                }
            }
            catch(LWException lwEx)
            {
                throw lwEx;
            }
            catch(Exception ex)
            {
                throw new LWLogWriterException(Resources.ErrorLogWriterWriteLog + ex.Message, ex, DiagnosticEvents.ErrorLogWriter);
            }
        }



        /// <summary>
        /// Is the same as <see cref="WriteLog(ILWLogData)"/>
        /// This method write the next log in the log file.
        /// </summary>
        /// <typeparam name="T">Object type of the log.</typeparam>
        /// <param name="log">this log get written.</param>
        public void WriteLog<T>(ILWLogData log)
        {
            WriteLog(log);
        }



        #endregion



        #region Private Methods



        /// <summary>
        /// This method look for the file with the biggest number in the logpath and return the next number in the row.
        /// <para>The files it search for must habe the same prefix, file name and extention as the properrties of this method</para>
        /// If the property <see cref="LogPath"/> is empty it return 1.
        /// </summary>
        /// <returns>returns the number for the next log file.</returns>
        private string getNextNumber()
        {
            return fillUpNumberLenght((getHighestLogNumber() + 1).ToString());
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private uint getHighestLogNumber()
        {
            uint biggestNumber = 1;
            if (!String.IsNullOrEmpty(LogPath))
            {
                foreach (string file in Directory.GetFiles(LogPath, FileNamePrefix + FileName + "*." + FileExtetion, SearchOption.TopDirectoryOnly))
                {
                    uint number = getNumberFromFileName(file);
                    if (number > biggestNumber)
                        biggestNumber = number;
                }
            }
            return biggestNumber;
        }



        /// <summary>
        /// This method search for a number at the end of a file name.
        /// </summary>
        /// <param name="fileName">Search in this string.</param>
        /// <returns>If it find a number, it will return this number, else it return 1</returns>
        private uint getNumberFromFileName(string fileName)
        {
            fileName = fileName.Split('.')[0];
            string number = String.Empty;
            for (int i = fileName.Length; i > 0; i--)
            {
                char character = fileName[i - 1];
                if (character > '0' && character < '9')
                    number = character + number;
                else
                    break;
            }
            if (String.IsNullOrEmpty(number))
                number = "1";

            return Convert.ToUInt32(number);
        }



        /// <summary>
        /// This method fill up the string length if it is shorter than <see cref="NumberLength"/>.
        /// </summary>
        /// <param name="number">This string get filled up.</param>
        /// <returns>return the filled up string</returns>
        private string fillUpNumberLenght(string number)
        {
            for (int i = number.Count(); i < NumberLength; i++)
            {
                number = "0" + number;
            }
            return number;
        }



        /// <summary>
        /// Look for invalid file name characters in the parameter string.
        /// </summary>
        /// <param name="testName">This string get tested.</param>
        /// <returns>true if everything is ok, false if not.</returns>
        private bool IsValidFilename(string testName)
        {
            string validCharacters = new String(System.IO.Path.GetInvalidFileNameChars());
            string pattern = "^[" + Regex.Escape(validCharacters) + "]+$";
            var containsABadCharacter = new Regex(pattern);
            return containsABadCharacter.IsMatch(testName);
        }



        #endregion


        
    }
}
