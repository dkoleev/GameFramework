namespace Avocado.Framework.Examples.Events {
    public readonly struct ExampleEvent {
        public readonly float SomeValue;

        public ExampleEvent(float someValue) {
            SomeValue = someValue;
        }
    }
}