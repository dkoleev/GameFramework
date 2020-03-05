namespace Avocado.Framework.Utilities {
    public static class Logger {
        public static void Log(string message) {
#if AVOCADO_LOG
            Debug.Log(message);
#endif
        }

        public static void LogFormat(string format, params object[] args) {
#if AVOCADO_LOG
            Debug.LogFormat(format, args);
#endif
        }

        public static void LogWarning(string message) {
#if AVOCADO_LOG
            Debug.LogWarning(message);
#endif
        }

        public static void LogWarningFormat(string format, params object[] args) {
#if AVOCADO_LOG
            Debug.LogWarningFormat(format, args);
#endif
        }

        public static void LogError(string message) {
#if AVOCADO_LOG
            Debug.LogError(message);
#endif
        }

        public static void LogErrorFormat(string format, params object[] args) {
#if AVOCADO_LOG
            Debug.LogErrorFormat(format, args);
#endif
        }
    }
}