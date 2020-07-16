using System;

namespace Avocado.UnityToolbox.Timer {
    public class TimeManagerLogWrapper : ITimeManager {
        private readonly ITimeManager _baseTimeManager;
        
        public TimeManagerLogWrapper(ITimeManager baseTimeManager) {
            _baseTimeManager = baseTimeManager;
        }
        
        public Timer Call(float delay, Action action) {
            var timer = _baseTimeManager.Call(delay, action);
            Logger.Log($"start new timer with delay {delay}. No unscaled deltaTime");
            return timer;
        }

        public Timer Call(float delay, Action action, bool useUnscaledDeltaTime) {
            var timer = _baseTimeManager.Call(delay, action, useUnscaledDeltaTime);
            Logger.Log($"start new timer with delay {delay}. Use unscaled deltaTime: {useUnscaledDeltaTime}");
            return timer;
        }

        public Timer RepeatCall(float delay, Action action) {
            var timer = _baseTimeManager.RepeatCall(delay, action);
            Logger.Log($"start new repeat timer with delay {delay}. No unscaled deltaTime");
            return timer;
        }

        public Timer RepeatCall(float delay, Action action, bool useUnscaledDeltaTime) {
            var timer = _baseTimeManager.RepeatCall(delay, action, useUnscaledDeltaTime);
            Logger.Log($"start new repeat timer with delay {delay}. Use unscaled deltaTime: {useUnscaledDeltaTime}");
            return timer;
        }

        public void PauseAll() {
            _baseTimeManager.PauseAll();
            Logger.Log("Pause all timers");
        }

        public void ResumeAll() {
            _baseTimeManager.ResumeAll();
            Logger.Log("ResumeAllTimers");
        }
    }
}