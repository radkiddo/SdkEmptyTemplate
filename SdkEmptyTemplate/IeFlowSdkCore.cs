#region "about"

//
// eFLOW <Name> Management SDK
// 2014 (c) - Top Image Systems (a project initiated by the EMEA branch)
//
// The purpose of this SDK is to make eFLOW programming safe, a lot easier, faster and fun, basically removing complexity.
// Initiated by: Eduardo Freitas
//

#endregion "about"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eFlow.NamespaceNameManagement
{
    /// <summary>
    /// All SDK classes should inherit from this ineterface - for future plugin architecture
    /// </summary>
    interface IeFlowSdkCore
    {
        /// <summary>
        /// Implement a Description method for your class
        /// </summary>
        void Description();
    }
}
