using S50cDL18;
using S50cSys18;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sage50c.ExtenderSample {
    public static class MyApp {
        #region Global multi Uses
        private static S50cSys18.GlobalSettings _50cSysGlobalSettings = null;
        private static S50cData18.GlobalSettings _50cDataGlobalSettings = null;
        private static S50cDL18.GlobalSettings _50cDLGlobalSettings = null;
        private static S50cBL18.GlobalSettings _50cBLGlobals = null;
        private static S50cCore18.GlobalSettings _50cCoreGlobals = null;

        private static S50cSys18.GlobalSettings s50cGlobalSettings {
            get {
                if( _50cSysGlobalSettings == null) {
                    _50cSysGlobalSettings = new S50cSys18.GlobalSettings();
                }
                return _50cSysGlobalSettings;
            }
        }

        private static S50cBL18.GlobalSettings s50cBLGlobals {
            get {
                if (_50cBLGlobals == null) {
                    _50cBLGlobals = new S50cBL18.GlobalSettings();
                }
                return _50cBLGlobals;
            }
        }

        public static SystemSettings SystemSettings {
            get {
                return s50cGlobalSettings.SystemSettings;
            }
        }
        public static S50cData18.DataManager DataManager {
            get {
                if (_50cDataGlobalSettings == null) {
                    _50cDataGlobalSettings = new S50cData18.GlobalSettings();
                }
                return _50cDataGlobalSettings.DataManager;
            }
        }
        public static DSOFactory DSOCache {
            get {
                if (_50cDLGlobalSettings == null) {
                    _50cDLGlobalSettings = new S50cDL18.GlobalSettings();
                }
                return _50cDLGlobalSettings.DSOCache;
            }
        }

        public static S50cCore18.GlobalSettings CoreGlobals {
            get {
                if (_50cCoreGlobals == null) {
                    _50cCoreGlobals = new S50cCore18.GlobalSettings();
                }
                return _50cCoreGlobals;
            }
        }


        /// <summary>
        /// Retail Federal Tax Id Validator
        /// </summary>
        public static S50cBL18.FederalTaxValidator FederalTaxValidator { get { return s50cBLGlobals.FederalTaxValidator; } }
        /// <summary>
        /// Tradutor
        /// </summary>
        public static S50cLocalize18._ILocalizer gLng { get { return s50cGlobalSettings.gLng; } }

        public static QuickSearch CreateQuickSearch(QuickSearchViews QuickSearchId, bool CacheIt) {
            return _50cSysGlobalSettings.CreateQuickSearch(QuickSearchId, CacheIt);
        }
        #endregion
    }
}
