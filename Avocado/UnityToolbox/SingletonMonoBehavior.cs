using UnityEngine;

namespace Avocado.UnityToolbox {
    public class SingletonMonoBehavior<T> : MonoBehaviour where T : MonoBehaviour {
        public static T Instance {
            get {
                if (_destroyed) {
                    return null;
                }

                lock (_lock) {
                    if (_instance == null) {
                        _instance = FindObjectOfType<T>();
                        if (_instance == null) {
                            _instance = new GameObject($"[Singleton] {nameof(T)}").AddComponent<T>();
                            DontDestroyOnLoad(_instance.gameObject);
                        }
                    }
                }
                
                return _instance;
            }
        }

        private static T _instance;
        private static readonly object _lock = new object();
        private static bool _destroyed;
        
        protected virtual void OnDestroy() {
            _destroyed = true;
        }
    }
}
