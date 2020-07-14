using Avocado.Examples.ServiceLocator.Analytics;
using UnityEngine;

namespace Avocado.Examples.ServiceLocator {
    public class ServiceLocatorExample : MonoBehaviour {
        private void Start() {
            var firebaseAnalytics = new FirebaseAnalytics();
            var amplitudeAnalytics = new AmplitudeAnalytics();
            var nullAnalytics = new NullAnalytics();
            var combineAnalytics = new CombineAnalytics(firebaseAnalytics, amplitudeAnalytics);
            var loggedAnalytics = new LoggedAnalytics(combineAnalytics);
            
            InjectService(firebaseAnalytics);
            AnalyticsProvider.Current.LogEvent("test1");
            InjectService(amplitudeAnalytics);
            AnalyticsProvider.Current.LogEvent("test2");
            InjectService(nullAnalytics);
            AnalyticsProvider.Current.LogEvent("test3");
            InjectService(combineAnalytics);
            AnalyticsProvider.Current.LogEvent("test4");
            InjectService(loggedAnalytics);
            AnalyticsProvider.Current.LogEvent("test5");
        }

        private void InjectService(IAnalytics service) {
            AnalyticsProvider.Provide(service);
        }
    }
}
