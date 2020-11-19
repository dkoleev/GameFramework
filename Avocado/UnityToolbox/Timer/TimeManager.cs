using System;
using System.Collections.Generic;
using UnityEngine;

namespace Avocado.UnityToolbox.Timer {
    public class TimeManager : ITimeManager {
        private List<Timer> _timerList;
        private MonoBehaviourTimerHook _timerMonoBehaviourHook;

        public Timer Call(float delay, Action action) {
            return Create(action, delay, false, false);
        }
        
        public Timer Call(float delay, Action action, bool useUnscaledDeltaTime) {
            return Create(action, delay, useUnscaledDeltaTime, false);
        }
        
        public Timer RepeatCall(float delay, Action action) {
            return Create(action, delay, false, true);
        }
        
        public Timer RepeatCall(float delay, Action action, bool useUnscaledDeltaTime) {
            return Create(action, delay, useUnscaledDeltaTime, true);
        }

        public void PauseAll() {
            var buffer = _timerList.ToArray();
            foreach (var timer in buffer) {
                timer.Pause();
            }
        }
        
        public void ResumeAll() {
            var buffer = _timerList.ToArray();
            foreach (var timer in buffer) {
                timer.Resume();
            }
        }

        public void StopAll() {
            var buffer = _timerList.ToArray();
            foreach (var timer in buffer) {
                timer.Stop();
            }
        }

        public class MonoBehaviourTimerHook : MonoBehaviour {
            public Action OnUpdate;

            private void Update() {
                OnUpdate?.Invoke();
            }

            public void Destroy() {
                Destroy(gameObject);
            }
        }

        private void InitializeIfNeed() {
            if (_timerMonoBehaviourHook == null) {
                var go = new GameObject("[Timer]", typeof(MonoBehaviourTimerHook));
                _timerMonoBehaviourHook = go.GetComponent<MonoBehaviourTimerHook>();
                _timerList = new List<Timer>();
            }
        }

        private Timer Create(Action action, float timer, bool useUnscaledDeltaTime, bool repeat) {
            InitializeIfNeed();
            
            var funcTimer = new Timer(action, timer, useUnscaledDeltaTime, _timerMonoBehaviourHook, repeat);
            _timerList.Add(funcTimer);
            funcTimer.OnFinish += RemoveTimer;

            return funcTimer;
        }

        private void RemoveTimer(Timer timer) {
            _timerList.Remove(timer);
        }
    }
}