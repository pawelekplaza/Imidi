using System;

namespace Imidi.Helpers
{
    public class SettingsHelper
    {
        #region Singletone
        private static Lazy<SettingsHelper> _instance = new Lazy<SettingsHelper>(() => new SettingsHelper());
        public static SettingsHelper Instance => _instance.Value;
        protected SettingsHelper() { }
        #endregion

        public const int NumberOfColumns = 4;
    }
}
