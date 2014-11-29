#region "about"

//
// eFLOW <Name> Management SDK
// 2014 (c) - Top Image Systems (a project initiated by the EMEA branch)
//
// The purpose of this SDK is to make eFLOW programming safe, a lot easier, faster and fun, basically removing complexity.
// Initiated by: Eduardo Freitas
// Module developed by: <Your name>
//

#endregion "about"

#region "using"

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using TiS.Core.Application;
using TiS.Core.Common;
using TiS.Core.Domain;
using TiS.Core.TisCommon;
using TiS.Core.Application.DataModel.Dynamic;
using TiS.Core.Application.Interfaces;

using eFlow.NamespaceNameManagement;

#endregion "using"

#region "namespace eFlow.NamespaceNameManagement"

namespace eFlow.NamespaceManagement
{
    #region "class MyClass"

    /// <summary>
    /// "Class" Class --> Is a wrapper class that performs atomic operations around a ITisCollectionData object and the eFLOW CSM. 
    /// </summary>
    public class MyClass : MyClassInternals, IDisposable, IeFlowSdkCore
    {
        #region "Constructor-Finalizer-Dispose"

        #region "Constructor"
        /// <summary>
        /// [Constructor] MyClass() --> Initializes a MyClas object instance with the eFLOW application and station names.
        /// </summary>
        /// <param name="applicationName">Indicates the name of the eFLOW application to login to.</param>
        /// <param name="stationName">Indicates the name of the eFLOW station to login to.</param>
        /// <example><code>MyClass b = new MyCklass("SimpleDemo", "Completion");</code></example>
        public MyClass(string applicationName, string stationName)
            : base(applicationName, stationName)
        {
        }

        /// <summary>
        /// [Constructor] MyClass() --> Initializes a Batch object instance.
        /// </summary>
        /// <example><code>MyClass b = new MyClass();</code></example>
        public MyClass()
            : base()
        {
        }

        #endregion "Constructor"

        #region "Destructor"
        /// <summary>
        /// [Destructor] MyClass() --> Releases unmanaged resources and performs other cleanup operations before the is reclaimed by garbage collection.
        /// </summary>
        /// <remarks>We must implement a finalizer to guarantee that the native CSM object is cleaned up</remarks>
        ~MyClass()
        {
            // Our finalizer should call our Dispose(bool) method with false
            base.Dispose(false);
        }
        #endregion "Destructor"

        #endregion region "Constructor-Finalizer-Dispose"

        #region "Exposed/Public methods"        
           
        // Your intellisense exposed methods should go in here...

        public override void Description()
        {
            // Implementation of IeFlowSdk.Description();
        }

        #endregion "Exposed/Public methods"
    }

    #endregion "class MyClass"
}

#endregion "namespace NamespaceNameManagement"
