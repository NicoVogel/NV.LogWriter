using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogWriter.Enums;

namespace LogWriter
{
    /// <summary>
    /// This class is a log category. Its used to seperate different logs.
    /// </summary>
    public class LWCategory
    {

        private string m_name;
        private LWLogLevel m_logLevel;


        #region Properties



        /// <summary>
        /// The category name that also get displayed in the log.
        /// </summary>
        public string Name
        {
            get
            {
                return m_name;
            }

            set
            {
                m_name = value;
            }
        }



        /// <summary>
        /// The level of the category.
        /// </summary>
        public LWLogLevel LogLevel
        {
            get
            {
                return m_logLevel;
            }

            set
            {
                m_logLevel = value;
            }
        }
        
        

        /// <summary>
        /// Return a default category set. The keys are the <see cref="LWLogLevel"/> values as string. There is one category for each value.
        /// </summary>
        public static Dictionary<string, LWCategory> DefaultSet
        {
            get
            {
                Dictionary<string, LWCategory> defaultSet = new Dictionary<string, LWCategory>();
                foreach (LWLogLevel item in Enum.GetValues(typeof(LWLogLevel)))
                {
                    defaultSet.Add(item.ToString(), new LWCategory(item.ToString(), item));
                }
                return defaultSet;
            }
        }



        #endregion



        /// <summary>
        /// Create an instance of <see cref="LWCategory"/> with <see cref="LogLevel"/> = <see cref="LWLogLevel.None"/> as default.
        /// </summary>
        /// <param name="name">Name of the category</param>
        public LWCategory(string name)
        {
            Name = name;
            LogLevel = LWLogLevel.None;
        }



        /// <summary>
        /// Create an instance of <see cref="LWCategory"/> with <see cref="LogLevel"/> = <paramref name="level"/>.
        /// </summary>
        /// <param name="name">Name of the category</param>
        /// <param name="level">This is the level of the category</param>
        public LWCategory(string name, LWLogLevel level) : this(name)
        {
            LogLevel = level;
        }
    }
}
