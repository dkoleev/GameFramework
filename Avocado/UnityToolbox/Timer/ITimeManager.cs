using System;

namespace Avocado.UnityToolbox.Timer {
    public interface ITimeManager {
        Timer Call(float delay, Action action);
        Timer Call(float delay, Action action, bool useUnscaledDeltaTime);
        Timer RepeatCall(float delay, Action action);
        Timer RepeatCall(float delay, Action action, bool useUnscaledDeltaTime);
        void PauseAll();
        void ResumeAll();
        void StopAll();
    }
}
