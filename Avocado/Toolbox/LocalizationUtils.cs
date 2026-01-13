using UnityEngine.Localization;

namespace Avocado.Toolbox
{
    public static class LocalizationUtils
    {
        public static LocalizedString GetLocalizedString(string tableName, string key)
        {
            return new LocalizedString(tableName, key);
        }

        public static LocalizedString GetCommonLocalizedString<T>(string tableName, string key, T arg)
        {
            var localizedString = new LocalizedString(tableName, key);
            localizedString.Arguments = new object[] { arg };
            return localizedString;
        }

        // Для двух параметров
        public static LocalizedString GetCommonLocalizedString<T1, T2>(string tableName, string key, T1 arg1, T2 arg2)
        {
            var localizedString = new LocalizedString(tableName, key);
            localizedString.Arguments = new object[] { arg1, arg2 };
            return localizedString;
        }

        // Для трёх и более параметров
        public static LocalizedString GetCommonLocalizedString(string tableName, string key, params object[] args)
        {
            var localizedString = new LocalizedString(tableName, key);
            localizedString.Arguments = args;
            return localizedString;
        }
    }
}
