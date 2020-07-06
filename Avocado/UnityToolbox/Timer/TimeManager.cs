using System;
using System.Collections.Generic;
using UnityEngine;

namespace Avocado.UnityToolbox.Timer {
    public static class TimeManager {
        private static List<Timer> _timerList;
        private static MonoBehaviourTimerHook _timerMonoBehaviourHook;
        
        private static void InitializeIfNeed() {
            if (_timerMonoBehaviourHook == null) {
                var go = new GameObject("[Timer]", typeof(MonoBehaviourTimerHook));
                _timerMonoBehaviourHook = go.GetComponent<MonoBehaviourTimerHook>();
                _timerList = new List<Timer>();
            }
        }

        public static Timer Call(float delay, Action action) {
            return Create(action, delay, false, false);
        }
        
        public static Timer Call(float delay, Action action, bool useUnscaledDeltaTime) {
            return Create(action, delay, useUnscaledDeltaTime, false);
        }
        
        public static Timer RepeatCall(float delay, Action action) {
            return Create(action, delay, false, true);
        }
        
        public static Timer RepeatCall(float delay, Action action, bool useUnscaledDeltaTime) {
            return Create(action, delay, useUnscaledDeltaTime, true);
        }

        public static void PauseAll() {
            var buffer = _timerList.ToArray();
            foreach (var timer in buffer) {
                timer.Pause();
            }
        }
        
        public static void ResumeAll() {
            var buffer = _timerList.ToArray();
            foreach (var timer in buffer) {
                timer.Resume();
            }
        }

        private static Timer Create(Action action, float timer, bool useUnscaledDeltaTime, bool repeat) {
            InitializeIfNeed();
            
            var funcTimer = new Timer(action, timer, useUnscaledDeltaTime, _timerMonoBehaviourHook, repeat);
            _timerList.Add(funcTimer);
            funcTimer.OnFinish += RemoveTimer;

            return funcTimer;
        }

        private static void RemoveTimer(Timer timer) {
            _timerList.Remove(timer);
        }
    }
}