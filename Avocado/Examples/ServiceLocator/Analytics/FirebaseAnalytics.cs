using UnityEngine;

namespace Avocado.Examples.ServiceLocator.Analytics {
    public class FirebaseAnalytics : IAnalytics {
        public void LogEvent(string name) {
            Debug.Log("Firebase log " + name);
        }
    }
}
