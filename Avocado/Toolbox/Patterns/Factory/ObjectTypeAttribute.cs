using System;

namespace Avocado.Toolbox.Patterns.Factory {
    public class ObjectTypeAttribute : Attribute{
        public string Type { get; }

        public ObjectTypeAttribute(string type) {
            Type = type;
        }
    }
}