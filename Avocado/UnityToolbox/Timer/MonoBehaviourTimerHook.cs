using System;
using UnityEngine;

namespace Avocado.UnityToolbox.Timer {
    public class MonoBehaviourTimerHook : MonoBehaviour {
        public Action OnUpdate;

        private void Update() {
            OnUpdate?.Invoke();
        }
    }
}