using System.Collections.Generic;
using System.Linq;

namespace Avocado.Examples.ServiceLocator.Analytics {
    public class CombineAnalytics : IAnalytics {
        private List<IAnalytics> _analytics = new List<IAnalytics>();
        
        public CombineAnalytics(params IAnalytics[] analytics) {
            _analytics = analytics.ToList();
        }

        public void LogEvent(string name) {
            foreach (var analytic in _analytics) {
                analytic.LogEvent(name);
            }
        }
    }
}
