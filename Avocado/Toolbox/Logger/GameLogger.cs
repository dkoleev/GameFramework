using UnityEngine;

namespace Avocado.Toolbox.Logger {
    public static class GameLogger {
        public static void Log(string message) {
#if UNITY_EDITOR || DEBUG
            Debug.Log(message);
#endif
        }

        public static void LogFormat(string format, params object[] args) {
#if UNITY_EDITOR || DEBUG
            Debug.LogFormat(format, args);
#endif
        }

        public static void LogWarning(string message) {
#if UNITY_EDITOR || DEBUG
            Debug.LogWarning(message);
#endif
        }

        public static void LogWarningFormat(string format, params object[] args) {
#if UNITY_EDITOR || DEBUG
            Debug.LogWarningFormat(format, args);
#endif
        }

        public static void LogError(string message) {
#if UNITY_EDITOR || DEBUG
            Debug.LogError(message);
#endif
        }

        public static void LogErrorFormat(string format, params object[] args) {
#if UNITY_EDITOR || DEBUG
            Debug.LogErrorFormat(format, args);
#endif
        }
    }
}