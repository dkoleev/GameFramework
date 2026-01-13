using System;
using System.IO;
using UnityEngine;

namespace Avocado.Toolbox
{
    public static class GameLogger
    {
        public enum LogLevel
        {
            Info,
            Warning,
            Error,
            Debug
        }

        // Включает/отключает вывод логов в билде
        private static readonly bool EnableLogs =
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            true;
#else
            false;
#endif

        private static readonly string LogDirectory = Path.Combine(Application.persistentDataPath, "Logs");
        private static readonly string LogFilePath = Path.Combine(LogDirectory, $"{DateTime.Now:yyyy-MM-dd}.log");

        static GameLogger()
        {
            try
            {
                if (!Directory.Exists(LogDirectory))
                    Directory.CreateDirectory(LogDirectory);

                // Очистим старые логи старше 7 дней
                foreach (var file in Directory.GetFiles(LogDirectory))
                {
                    if (File.GetCreationTime(file) < DateTime.Now.AddDays(-7))
                        File.Delete(file);
                }

                File.AppendAllText(LogFilePath, $"\n---- Game Log Started: {DateTime.Now} ----\n");
            }
            catch (Exception e)
            {
                Debug.LogWarning($"[GameLogger] Failed to initialize: {e.Message}");
            }
        }


        // Основной метод логирования
        public static void Log(string message, LogLevel level = LogLevel.Info, string category = "General", UnityEngine.Object context = null)
        {
            if (!EnableLogs) return;

            string prefix = GetPrefix(level, category);
            string formatted = $"{prefix} {message}";

            switch (level)
            {
                case LogLevel.Info:
                    Debug.Log(formatted, context);
                    break;
                case LogLevel.Warning:
                    Debug.LogWarning(formatted, context);
                    break;
                case LogLevel.Error:
                    Debug.LogError(formatted, context);
                    break;
                case LogLevel.Debug:
#if UNITY_EDITOR
                    Debug.Log($"<color=#888888>{formatted}</color>", context);
#endif
                    break;
            }

            // В файл
            try
            {
                string plain = $"[{DateTime.Now:HH:mm:ss}] [{level}] [{category}] {message}\n";
                File.AppendAllText(LogFilePath, plain);
            }
            catch
            {
                /* Игнорируем ошибки записи, чтобы не крашить игру */
            }
        }

        public static void Info(string message, string category = "General", UnityEngine.Object context = null) =>
            Log(message, LogLevel.Info, category, context);

        public static void Warn(string message, string category = "General", UnityEngine.Object context = null) =>
            Log(message, LogLevel.Warning, category, context);

        public static void Error(string message, string category = "General", UnityEngine.Object context = null) =>
            Log(message, LogLevel.Error, category, context);

        public static void DebugLog(string message, string category = "General", UnityEngine.Object context = null) =>
            Log(message, LogLevel.Debug, category, context);

        private static string GetPrefix(LogLevel level, string category)
        {
            string color = level switch
            {
                LogLevel.Info => "#8BC34A",
                LogLevel.Warning => "#FFC107",
                LogLevel.Error => "#F44336",
                LogLevel.Debug => "#9E9E9E",
                _ => "#FFFFFF"
            };

            return $"<color={color}>[{DateTime.Now:HH:mm:ss}] [{level}] [{category}]</color>";
        }
    }
}
