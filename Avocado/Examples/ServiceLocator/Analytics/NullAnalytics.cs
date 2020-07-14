using UnityEngine;

namespace Avocado.Examples.ServiceLocator.Analytics {
    public class NullAnalytics : IAnalytics {
        public void LogEvent(string name) {
            Debug.Log("no analytics " + name);
        }
    }
}
