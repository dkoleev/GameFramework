using System;

namespace Avocado.Framework.Patterns.AbstractFactory {
    public class ObjectTypeAttribute : Attribute{
        public string Type { get; private set; }

        public ObjectTypeAttribute(string type) {
            Type = type;
        }
    }
}
