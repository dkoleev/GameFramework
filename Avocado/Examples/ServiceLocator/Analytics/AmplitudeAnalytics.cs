using UnityEngine;

namespace Avocado.Examples.ServiceLocator.Analytics {
    public class AmplitudeAnalytics : IAnalytics {
        public void LogEvent(string name) {
            Debug.Log("Log amplitude " + name);
        }
    }
}
