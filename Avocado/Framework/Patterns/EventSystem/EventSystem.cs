using System;

namespace Avocado.Framework.Patterns.EventSystem {
    public static class EventSystem<TEvent> where TEvent : struct {
        private static event Action<TEvent> OnFire;
        
        public static void Fire(in TEvent data) {
            OnFire?.Invoke(data);
        }
        
        public static void Fire() {
            var data = Activator.CreateInstance(typeof(TEvent));
            OnFire?.Invoke((TEvent)data);
        }

        public static void Subscribe(Action<TEvent> func) {
            OnFire += func;
        }
        
        public static void Unsubscribe(Action<TEvent> func) {
            OnFire -= func;
        }
    }
}