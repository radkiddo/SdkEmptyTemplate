#region "about"

//
// eFLOW <Name> Management SDK
// 2014 (c) - Top Image Systems (a project initiated by the EMEA branch)
//
// The purpose of this SDK is to make eFLOW programming safe, a lot easier, faster and fun, basically removing complexity.
// Initiated by: Eduardo Freitas
//

#endregion "about"

#region "using"

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

#endregion "using"

#region "namespace eFlow.NamespaceNameManagement"

namespace eFlow.NamespaceNameManagement
{
    #region "class Constants"

    /// <summary>
    /// "Constants" Class --> Constants used by the Batch class. 
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class Constants
    {
        #region "constants"

        #region "sdk specific"
        /// <summary>
        /// SDK specific
        /// </summary>
        public const string cStrLiteSdk = "eFlow.SDK.CM.CollectionManagement";
        public const string cStrLiteSdkBatch = "eFlow.SDK.CM.CollectionManagement.Batch()";
        #endregion "sdk specific"

        #region "Message / exception specific"
        /// <summary>
        /// Message / exception specific
        /// </summary>
        public const string cStrCouldNotLogin = "Could not connect to CSM. Did you execute Batch->Login()?";
        public const string cStrFailedToConnectToCsm = "Could not connect to CSM.";
        public const string cStrStationNameIsEmpty = "[stationName] is empty.";
        public const string cStrFileNameNotFound = "filename is empty or path does not exist [filename='";
        public const string cStrFailedWithException = "failed with exception: ";
        public const string cStrCollectionNameCannotBeEmpty = "CollectionName[s] parameter cannot be empty or NULL";
        public const string cStrFailedToCreateCSMInstanceForApplicationName = "Failed to create oCSM instance for [ApplicationName]: ";
        public const string cStrAndStationName = " and [StationName]: ";
        public const string cStrWithException = " with exception: ";
        public const string cStrCollectionIsNull = "Collection[s] parameter is NULL";
        #endregion "Message / exception specific"

        #region "Methods specific"
        /// <summary>
        /// Methods specific
        /// </summary>
        public const string cStrLoginMethod = "MyClassInternals->Login()";

        #endregion "Methods specific"

        #endregion "constants"
    }

    #endregion "class Constants"
}

#endregion "namespace eFlow.NamespaceNameManagement"
