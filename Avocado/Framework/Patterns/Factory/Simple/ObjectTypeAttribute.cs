using System;

namespace Avocado.Framework.Patterns.Factory.Simple {
    public class ObjectTypeAttribute : Attribute{
        public string Type { get; private set; }

        public ObjectTypeAttribute(string type) {
            Type = type;
        }
    }
}
