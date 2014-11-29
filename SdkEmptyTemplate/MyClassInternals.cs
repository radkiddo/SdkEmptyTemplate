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
using System.ComponentModel;

#endregion "using"

#region "namespace eFlow.NamespaceNameManagement"

namespace eFlow.NamespaceNameManagement
{
    /// <summary>
    /// "MyClassInternals" Class --> Is an internal wrapper class that performs atomic operations around a ITisCollectionData object and the CSM. 
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class MyClassInternals : IDisposable, IeFlowSdkCore
    {
        #region "class Batch private declarations"
        /// <summary>
        /// When set to true indicates that the instance of the class has been disposed
        /// </summary>
        protected bool disposed;

        /// <summary>
        /// Name of the eFLOW application logged on to the CSM
        /// </summary>
        protected string applicationName = String.Empty;

        /// <summary>
        /// Name of the eFLOW station logged on to the CSM
        /// </summary>
        protected string stationName = String.Empty;

        /// <summary>
        /// CSM object instance
        /// </summary>
        protected ITisClientServicesModule oCSM = null;

        #endregion "class Batch private declarations"

        #region "Properties"

        /// <summary>
        /// Name of the eFLOW application logged on to the CSM
        /// </summary>
        /// <example><code>b.ApplicationName = "SimpleDemo";</code></example>
        public string ApplicationName
        {
            get
            {
                return this.applicationName;
            }
            set
            {
                this.applicationName = value;
            }
        }

        /// <summary>
        /// Name of the eFLOW station logged on to the CSM
        /// </summary>
        /// <example><code>b.StationName = "Completion";</code></example>
        public string StationName
        {
            get
            {
                return this.stationName;
            }
            set
            {
                this.stationName = value;
            }
        }

        #endregion "Properties"

        #region "Constructor-Finalizer-Dispose"

        #region "Constructor"
        /// <summary>
        /// [Constructor] MyClassInternals() --> Initializes a MyClassInternals object instance with the eFLOW application and station names.
        /// </summary>
        /// <param name="applicationName">Indicates the name of the eFLOW application to login to.</param>
        /// <param name="stationName">Indicates the name of the eFLOW station to login to.</param>
        /// <example><code>MyClassInternals b = new MyClassInternals("SimpleDemo", "Completion");</code></example>
        protected MyClassInternals(string applicationName, string stationName)
        {
            try
            {
                //oCSM = TisClientServicesModule.GetNewInstance(applicationName, stationName); 4.5

                // 5
                oCSM = SingletoneTisClientServicesModule.GetSingletoneInstance();

                oCSM.Initialize(null, null, null, 0, null, null, null, null, null, null, null);
                oCSM.LoginApplication(applicationName, stationName);
            }
            catch (Exception e)
            {
                throw new Exception(Constants.cStrLiteSdkBatch + " -> " + Constants.cStrFailedWithException, e);
            }
            finally
            {
                this.applicationName = applicationName;
                this.stationName = stationName;
            }
        }

        /// <summary>
        /// [Constructor] MyClassInternals() --> Initializes a MyClassInternals object instance.
        /// </summary>
        /// <example><code>MyClassInternals b = new MyClassInternals();</code></example>
        protected MyClassInternals()
        {
            this.applicationName = String.Empty;
            this.stationName = String.Empty;
        }

        #endregion "Constructor"

        #region "Destructor"
        /// <summary>
        /// [Destructor] MyClassInternals() --> Releases unmanaged resources and performs other cleanup operations before the is reclaimed by garbage collection.
        /// </summary>
        /// <remarks>We must implement a finalizer to guarantee that the native CSM object is cleaned up</remarks>
        ~MyClassInternals()
        {
            // Our finalizer should call our Dispose(bool) method with false
            this.Dispose(false);
        }
        #endregion "Destructor"

        #region "protected Dispose"
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        /// <remarks>
        /// If the main class was marked as sealed, we could just make this a private void Dispose(bool).  Alternatively, we could (in this case) put
        /// all of our logic directly in Dispose().
        /// </remarks>
        public virtual void Dispose(bool disposing)
        {
            // Use our disposed flag to allow us to call this method multiple times safely.
            // This is a requirement when implementing IDisposable
            if (!this.disposed)
            {
                if (disposing)
                {
                    // If we have any managed, IDisposable resources, Dispose of them here.
                    // In this case, we don't, so this was unneeded.
                    // Later, we will subclass this class, and use this section.

                    if (oCSM != null)
                        Logout();
                }

                // Always dispose of undisposed unmanaged resources in Dispose(bool)

            }
            // Mark us as disposed, to prevent multiple calls to dispose from having an effect, 
            // and to allow us to handle ObjectDisposedException
            this.disposed = true;
        }
        #endregion "protected Dispose"

        #region "Dispose"
        /// <summary>
        /// MyClassInternals.Dispose() --> Performs Batch defined tasks associated with freeing, releasing, or resetting managed and unmanaged resources.
        /// </summary>
        /// <example><code>b.Dispose();</code></example>
        public void Dispose()
        {
            // We start by calling Dispose(bool) with true
            this.Dispose(true);

            // Now suppress finalization for this object, since we've already handled our resource cleanup tasks
            GC.SuppressFinalize(this);
        }
        #endregion "Dispose"
        #endregion region "Constructor-Finalizer-Dispose"

        #region "Internal Private/Protected methods"

        // Define here your Private/Protected methods

        #region "MyClassInternals->Logout()"
        /// <summary>
        /// MyClassInternals->Logout() --> Logs out from the CSM.
        /// </summary>
        /// <returns>Returns true is successful, otherwise false.</returns>
        /// <example><code>bool result = b.Logout();</code></example>
        public virtual bool Logout()
        {
            bool result = false;

            if (oCSM != null)
            {
                try
                {
                    if (oCSM.SetupTransaction.InTransaction) oCSM.SetupTransaction.RollbackTransaction();

                    oCSM.Dispose();
                    oCSM = null;
                }
                catch (Exception e)
                {
                    oCSM = null;

                    throw new Exception(Constants.cStrLiteSdkBatch + Constants.cStrLoginMethod + Constants.cStrFailedWithException +
                        ((e.InnerException != null) ? e.InnerException.ToString() : e.ToString()));
                }
                finally
                {
                    result = true;
                }
            }

            return result;
        }
        #endregion "Batch->Logout()"

        #endregion Internal Private/Protected methods"
   
        #region "External methods"

        // Define here your External (public) methods
        
        public virtual void Description()
        {
            // Implementation of IeFlowSdk.Description();
        }

        #endregion "External methods"
    }
}

#endregion "namespace eFlow.NamespaceNameManagement"

