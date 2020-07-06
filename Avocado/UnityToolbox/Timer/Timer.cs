using System;
using UnityEngine;

namespace Avocado.UnityToolbox.Timer {
    public class Timer {
        public Action<Timer> OnFinish;

        private readonly bool _useUnscaledDeltaTime;
        private readonly Action _action;
        private float _time;
        private float _currentTime;
        private bool _active;
        private bool _pause;
        private bool _stop;
        private bool _repeat;
        private MonoBehaviourTimerHook _hook;
        private bool _destroyed;

        public Timer(Action action, float timer, bool useUnscaledDeltaTime, MonoBehaviourTimerHook hook, bool repeat) {
            _action = action;
            _time = timer;
            _currentTime = _time;
            _useUnscaledDeltaTime = useUnscaledDeltaTime;
            _hook = hook;
            _repeat = repeat;
            _hook.OnUpdate += Update;
            _pause = false;
            _stop = false;
        }

        public void Pause() {
            _pause = true;
        }

        public void Resume() {
            _pause = false;
        }

        public void Stop() {
            _stop = true;
        }

        private void Update() {
            if (_stop) {
                DestroySelf();
                return;
            }

            if (_pause) {
                return;
            }

            if (_useUnscaledDeltaTime) {
                _currentTime -= Time.unscaledDeltaTime;
            } else {
                _currentTime -= Time.deltaTime;
            }
            if (_currentTime <= 0) {
                _action();
                if (_repeat) {
                    _currentTime = _time;
                } else {
                    DestroySelf();
                }
            }
        }
        
        private void DestroySelf() {
            if (_destroyed) {
                return;
            }

            _hook.OnUpdate -= Update;

            OnFinish?.Invoke(this);
        }
    }
}