﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogWriter.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LogWriter.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Log.
        /// </summary>
        internal static string logFileNamePrefix {
            get {
                return ResourceManager.GetString("logFileNamePrefix", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \n\n\n.
        /// </summary>
        internal static string MLWriterBreaks {
            get {
                return ResourceManager.GetString("MLWriterBreaks", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Category: \t{0}.
        /// </summary>
        internal static string MLWriterCategory {
            get {
                return ResourceManager.GetString("MLWriterCategory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Date/Time: \t{0}.
        /// </summary>
        internal static string MLWriterDateTime {
            get {
                return ResourceManager.GetString("MLWriterDateTime", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Log ID: \t{0}.
        /// </summary>
        internal static string MLWriterID {
            get {
                return ResourceManager.GetString("MLWriterID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Message: \t{0}.
        /// </summary>
        internal static string MLWriterMessage {
            get {
                return ResourceManager.GetString("MLWriterMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Add. Object: \t{0}.
        /// </summary>
        internal static string MLWriterObject {
            get {
                return ResourceManager.GetString("MLWriterObject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}\t{1}\t{2}\t{3}\t{4}.
        /// </summary>
        internal static string SLWriter {
            get {
                return ResourceManager.GetString("SLWriter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \t\t.
        /// </summary>
        internal static string SLWriterID {
            get {
                return ResourceManager.GetString("SLWriterID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ILWLogData is not ready to use!.
        /// </summary>
        internal static string testLogDataExceptionNotReady {
            get {
                return ResourceManager.GetString("testLogDataExceptionNotReady", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ILWLogWriter is not ready to use!.
        /// </summary>
        internal static string testWriterExceptionNotReady {
            get {
                return ResourceManager.GetString("testWriterExceptionNotReady", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ILWLogWriter object is not set to an instance!.
        /// </summary>
        internal static string testWriterExceptionNull {
            get {
                return ResourceManager.GetString("testWriterExceptionNull", resourceCulture);
            }
        }
    }
}