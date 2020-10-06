using System;

namespace Avocado.Framework.Patterns.Factory {
    public class ObjectTypeAttribute : Attribute{
        public string Type { get; }

        public ObjectTypeAttribute(string type) {
            Type = type;
        }
    }
}