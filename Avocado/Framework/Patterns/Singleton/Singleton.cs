namespace Avocado.Framework.Patterns.Singleton {
    public abstract class Singleton<T> where T : class, new() {

        public static T Instance {
            get {
                lock (_lock) {
                    if (_instance is null) {
                        _instance = new T();
                    }
                }

                return _instance;
            }
        }
        
        private static T _instance;
        private static readonly object _lock = new object();
    }
}