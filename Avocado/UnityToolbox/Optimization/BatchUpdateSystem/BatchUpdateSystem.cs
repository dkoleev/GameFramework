using System.Collections.Generic;
using UnityEngine;

namespace Avocado.UnityToolbox.Optimization.BatchUpdateSystem {
    [DisallowMultipleComponent]
    public class BatchUpdateSystem : MonoBehaviour {
        public static BatchUpdateSystem Instance {
            get {
                if (_instance == null) {
                    var go = new GameObject("BatchUpdateSystem");
                    var updateComponent = go.AddComponent<BatchUpdateSystem>();
            
                    _instance = updateComponent;
                }

                return _instance;
            }
        }

        private static BatchUpdateSystem _instance;

        public enum UpdateMode { BucketA, BucketB, Always }
        private readonly HashSet<IBatchUpdated> _slicedUpdateBehavioursBucketA = new HashSet<IBatchUpdated>();
        private readonly HashSet<IBatchUpdated> _slicedUpdateBehavioursBucketB = new HashSet<IBatchUpdated>();
        private bool _isCurrentBucketA;
        
        public void Update()
        {
            var targetUpdateFunctions = _isCurrentBucketA ? _slicedUpdateBehavioursBucketA : _slicedUpdateBehavioursBucketB;
            foreach (var slicedUpdateBehaviour in targetUpdateFunctions)
            {
                slicedUpdateBehaviour.BatchUpdate();
            }
            _isCurrentBucketA = !_isCurrentBucketA;
        }
        public void RegisterSlicedUpdate(IBatchUpdated slicedUpdateBehaviour, UpdateMode updateMode)
        {
            if (updateMode == UpdateMode.Always)
            {
                _slicedUpdateBehavioursBucketA.Add(slicedUpdateBehaviour);
                _slicedUpdateBehavioursBucketB.Add(slicedUpdateBehaviour);
            }
            else
            {
                var targetUpdateFunctions = updateMode == UpdateMode.BucketA ? _slicedUpdateBehavioursBucketA : _slicedUpdateBehavioursBucketB;
                targetUpdateFunctions.Add(slicedUpdateBehaviour);
            }
        }
    
        public void DeregisterSlicedUpdate(IBatchUpdated slicedUpdateBehaviour)
        {
            _slicedUpdateBehavioursBucketA.Remove(slicedUpdateBehaviour);
            _slicedUpdateBehavioursBucketB.Remove(slicedUpdateBehaviour);
        }
    }
}