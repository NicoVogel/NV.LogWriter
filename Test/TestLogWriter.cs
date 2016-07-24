using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NV.LogWriter;
using NV.LogWriter.Enums;
using NV.LogWriter.Writer;

namespace Test
{
    [TestClass]
    public class TestLogWriter
    {



        #region LWManager



        /// <summary>
        /// Test for <see cref="LWManager"/>.
        /// Check if the default values are as exacted.
        /// </summary>
        [TestMethod]
        public void LWManagerDefaultValueTest()
        {
            Guid processID = Guid.NewGuid();
            LWManager logManager = new LWManager(processID, LWLogType.All, LWLogMode.EventView);
            
            Assert.AreEqual(true, processID == logManager.ProcessID);
            Assert.AreEqual(true, logManager.LogLevelModeSettings.Count == logManager.LogLevelModeSettingsDefault.Count);
            Assert.AreEqual(true, logManager.Mode == LWLogMode.EventView);
            Assert.AreEqual(true, logManager.Type == LWLogType.All);
            Assert.AreEqual(false, logManager.EventViewWriter.IsReadyToUse());
            Assert.AreEqual(false, logManager.LogFileWriter.IsReadyToUse());
            
        }



        /// <summary>
        /// Test for <see cref="LWManager"/>.
        /// Check if the mode work.
        /// </summary>
        [TestMethod]
        public void LWManagerModeTest()
        {
            Guid processID = Guid.NewGuid();
            LWManager logManager = new LWManager(processID, LWLogType.All, LWLogMode.EventView);
            LWLog none = new LWLog("",LWCategory.DefaultSet[LWLogLevel.None.ToString()]);

            FackeWriter eventView = new FackeWriter();
            FackeWriter logFile = new FackeWriter();
            logManager.EventViewWriter = eventView;
            logManager.LogFileWriter = logFile;


            logManager.WriteLog(none);
            Assert.AreEqual(none, eventView.LastLog);
            Assert.IsNull(logFile.LastLog);


            eventView.LastLog = null;
            logManager.Mode = LWLogMode.File;
            logManager.WriteLog(none);
            Assert.AreEqual(none, logFile.LastLog);
            Assert.IsNull(eventView.LastLog);


            logFile.LastLog = null;
            logManager.Mode = LWLogMode.EventViewAndFile;
            logManager.WriteLog(none);
            Assert.AreEqual(none, eventView.LastLog);
            Assert.AreEqual(none, logFile.LastLog);

        }



        /// <summary>
        /// Test for <see cref="LWManager"/>.
        /// Check if the level mode settings work.
        /// </summary>
        [TestMethod]
        public void LWManagerLevelModeTest()
        {
            Guid processID = Guid.NewGuid();
            LWManager logManager = new LWManager(processID, LWLogType.All, LWLogMode.EventView);
            Dictionary<string, LWCategory> categories = LWCategory.DefaultSet;
            LWLog none = new LWLog("", categories[LWLogLevel.None.ToString()]);
            LWLog info = new LWLog("", categories[LWLogLevel.Information.ToString()]);
            LWLog verbose = new LWLog("", categories[LWLogLevel.Verbose.ToString()]);
            LWLog warning = new LWLog("", categories[LWLogLevel.Warning.ToString()]);
            LWLog criticl = new LWLog("", categories[LWLogLevel.Critical.ToString()]);
            LWLog error = new LWLog("", categories[LWLogLevel.Error.ToString()]);
            FackeWriter eventView = new FackeWriter();
            logManager.EventViewWriter = eventView;


            logManager.WriteLog(none);
            Assert.AreEqual(none, eventView.LastLog);
            logManager.WriteLog(info);
            Assert.AreEqual(info, eventView.LastLog);
            logManager.WriteLog(verbose);
            Assert.AreEqual(verbose, eventView.LastLog);
            logManager.WriteLog(warning);
            Assert.AreEqual(warning, eventView.LastLog);
            logManager.WriteLog(criticl);
            Assert.AreEqual(criticl, eventView.LastLog);
            logManager.WriteLog(error);
            Assert.AreEqual(error, eventView.LastLog);


            logManager.Type = LWLogType.Debug;
            eventView.LastLog = null;
            logManager.WriteLog(none);
            Assert.IsNull(eventView.LastLog);
            logManager.WriteLog(info);
            Assert.AreEqual(info, eventView.LastLog);
            logManager.WriteLog(verbose);
            Assert.AreEqual(verbose, eventView.LastLog);
            logManager.WriteLog(warning);
            Assert.AreEqual(warning, eventView.LastLog);
            logManager.WriteLog(criticl);
            Assert.AreEqual(criticl, eventView.LastLog);
            logManager.WriteLog(error);
            Assert.AreEqual(error, eventView.LastLog);


            logManager.Type = LWLogType.Release;
            eventView.LastLog = null;
            logManager.WriteLog(none);
            Assert.IsNull(eventView.LastLog);
            logManager.WriteLog(info);
            Assert.IsNull(eventView.LastLog);
            logManager.WriteLog(verbose);
            Assert.IsNull(eventView.LastLog);
            logManager.WriteLog(warning);
            Assert.AreEqual(warning, eventView.LastLog);
            logManager.WriteLog(criticl);
            Assert.AreEqual(criticl, eventView.LastLog);
            logManager.WriteLog(error);
            Assert.AreEqual(error, eventView.LastLog);

        }



        #endregion



        #region LWEventViewWriter



        /// <summary>
        /// Test for <see cref="LWEventViewWriter"/>.
        /// </summary>
        [TestMethod]
        public void LWEventViewWriterTest()
        {
            

        }



        #endregion



        #region LWLogFileWriter



        /// <summary>
        /// Test for <see cref="LWLogFileWriter"/>.
        /// </summary>
        [TestMethod]
        public void LWLogFileWriterTest()
        {
            var manager = new LWManager();
            manager.EventViewWriter.Enabled = false;




        }



        #endregion



    }
}
