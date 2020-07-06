using System;
using System.Collections.Generic;
using UnityEngine;

namespace Avocado.UnityToolbox {
    public class Timer
    {
        private static List<Timer> _timerList;
        private static MonoBehaviourTimerHook _timerMonoBehaviourHook;
        
        private static void InitializeIfNeed() {
            if (_timerMonoBehaviourHook == null) {
                var go = new GameObject("[Timer]", typeof(MonoBehaviourTimerHook));
                _timerMonoBehaviourHook = go.GetComponent<MonoBehaviourTimerHook>();
                _timerList = new List<Timer>();
            }
        }
        
        private class MonoBehaviourTimerHook : MonoBehaviour {
            public Action OnUpdate;

            private void Update() {
                OnUpdate?.Invoke();
            }
        }

        public static Timer Call(float delay, Action action) {
            return Create(action, delay, false);
        }
        
        public static Timer Call(float delay, Action action, bool useUnscaledDeltaTime) {
            return Create(action, delay, useUnscaledDeltaTime);
        }
        
        private static Timer Create(Action action, float timer, bool useUnscaledDeltaTime) {
            InitializeIfNeed();
            
            var funcTimer = new Timer(action, timer, useUnscaledDeltaTime);
            _timerList.Add(funcTimer);

            return funcTimer;
        }

        private static void RemoveTimer(Timer timer) {
            _timerList.Remove(timer);
        }

        private readonly bool _useUnscaledDeltaTime;
        private readonly Action _action;
        private float _timer;
        private bool _active;

        private Timer(Action action, float timer, bool useUnscaledDeltaTime) {
            _action = action;
            _timer = timer;
            _useUnscaledDeltaTime = useUnscaledDeltaTime;
            _timerMonoBehaviourHook.OnUpdate += Update;
        }

        private void Update() {
            if (_useUnscaledDeltaTime) {
                _timer -= Time.unscaledDeltaTime;
            } else {
                _timer -= Time.deltaTime;
            }
            if (_timer <= 0) {
                _action();
                DestroySelf();
            }
        }
        private void DestroySelf() {
            _timerMonoBehaviourHook.OnUpdate -= Update;

            RemoveTimer(this);
        }
    }
}