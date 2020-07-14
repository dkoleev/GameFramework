using Avocado.Framework.Patterns.ServiceLocator;

namespace Avocado.Examples.ServiceLocator.Analytics {
    public interface IAnalytics : IService {
        void LogEvent(string name);
    }
}
