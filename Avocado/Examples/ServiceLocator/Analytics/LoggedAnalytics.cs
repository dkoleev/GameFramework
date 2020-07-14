using UnityEngine;

namespace Avocado.Examples.ServiceLocator.Analytics {
    public class LoggedAnalytics : IAnalytics {
        private readonly IAnalytics _wrapped;

        public LoggedAnalytics(IAnalytics wrapped) {
            _wrapped = wrapped;
        }

        public void LogEvent(string name) {
            _wrapped.LogEvent(name);
            Debug.Log("analytics with log to console");
        }
    }
}
