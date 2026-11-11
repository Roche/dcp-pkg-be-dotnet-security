using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDCP.Framework.Security.Constants
{
    public static class Permissions
    {
        public static class ModuleDependent
        {
            public static class MVDA
            {
                public const string USER = "MVDAUSER";
                public const string DEVELOPER = "MVDADEVELOPER";
            }
            public static class ChromTA
            {
                public const string MASTERDATA = "CHROMTAMASTERDATA";
                public const string MANUALINPUT = "CHROMTAMANUALINPUT";
                public const string USER = "CHROMTAUSER";
                public const string ADMIN = "CHROMTAADMIN";
            }
            public static class ComplianceCheck
            {
                public const string ADMIN = "COMPLIANCECHECKADMIN";
            }
            public static class PPM
            {
                public const string USER = "PPMUSER";
                public const string PAUSER = "PPMPAUSER";
                public const string MMUSER = "MMUSER";
                public const string STLMUSER = "STLMUSER";
            }
            /// <summary>
            /// Dynamic Reporting for Advanced Manufactoring - DReAM
            /// </summary>
            public static class DReAM
            {
                public const string TEMPLATECREATOR = "DREAMTEMPLATECREATOR";
                public const string CREATOR = "DREAMCREATOR";
                public const string VIEWER = "DREAMVIEWER";
            }
            /// <summary>
            /// Simplified Analytics Workbench - SAW
            /// </summary>
            public static class SAW
            {
                public const string ANALYSISCREATOR = "SAWANALYSISCREATOR";
                public const string APPCREATOR = "SAWAPPCREATOR";
                public const string VIEWER = "SAWVIEWER";
            }
            /// <summary>
            /// Technical Product Health - TPH
            /// </summary>
            public static class TPH
            {
                public const string VIEWER = "TPHVIEWER";
                public const string ASSESSOR = "TPHASSESSOR";
                public const string DEVELOPER = "TPHDEVELOPER";
            }
        }
        public static class ModuleIndependent
        {
            public const string ADMIN = "ADMIN";
            public const string VIEWER = "VIEWER";
        }

        public static class Global
        {
            public const string ADMIN = "PLATFORMADMIN";
            public const string APIUSER = "PLATFORMAPIUSER";
            public const string GUEST = "PLATFORMGUEST";
        }

        public static class Placeholder
        {
            public const string AGNOSTIC = "agnostic";
            public const string GLOBAL = "GLOBAL";
            public const string PLATFORM = "PLATFORM";
        }
    }
}
