using System;

namespace Avocado.Framework.Patterns.EventSystem {
    public static class EventSystem<TEvent> where TEvent : IEvent {
        public static event Action<TEvent> OnFire;

        public static void Fire(TEvent data) {
            OnFire?.Invoke(data);
        }
    }
}