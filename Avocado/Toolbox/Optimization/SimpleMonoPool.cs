using System.Collections.Generic;
using UnityEngine;

namespace Avocado.Toolbox.Optimization {
    public class SimpleMonoPool : MonoBehaviour {
        [SerializeField] private GameObject targetObject;
        [Space] [SerializeField] private bool expand = true;
        [SerializeField] private int startSize;
        [SerializeField] private Transform defaultParent;

        private Stack<GameObject> _pooledObjects;

        private void Awake() {
            _pooledObjects = new Stack<GameObject>(startSize);
        }

        private void Start() {
            for (int i = 0; i < startSize; i++) {
                AddObjectToPool();
            }
        }

        public GameObject Spawn(Vector3 position, Transform parent = null) {
            if (_pooledObjects.Count == 0) {
                if (expand) {
                    AddObjectToPool();
                } else {
                    Debug.LogWarning("Pool is empty");
                    return null;
                }
            }

            var result = _pooledObjects.Pop();
            if (result == null) {
                // The inactive object we expected to find no longer exists.
                // The most likely causes are:
                //   - Someone calling Destroy() on our object
                //   - A scene change (which will destroy all our objects).
                // We'll just try the next one in our sequence.
                return Spawn(position, parent);
            }

            result.transform.position = position;
            result.transform.parent = parent ? parent : defaultParent ? defaultParent : transform;
            result.SetActive(true);

            return result;
        }

        public void Despawn(GameObject go) {
            go.SetActive(false);
            _pooledObjects.Push(go);
        }

        private void AddObjectToPool() {
            var go = Instantiate(targetObject, defaultParent ? defaultParent : transform);
            go.SetActive(false);
            _pooledObjects.Push(go);
        }
    }
}
