using Avocado.Framework.Patterns.EventSystem;

namespace Avocado.Examples.Events {
    public class Example {
        public void TestEvent() {
            EventSystem<ExampleEvent>.Fire();
            EventSystem<ExampleEvent>.Fire(new ExampleEvent(10));
            
            EventSystem<ExampleEvent>.Subscribe(EventSystemOnOnFire);
            EventSystem<ExampleEvent>.Unsubscribe(EventSystemOnOnFire);
        }

        private void EventSystemOnOnFire(ExampleEvent eventData) {
            var value = eventData.SomeValue;
        }
    }
}
