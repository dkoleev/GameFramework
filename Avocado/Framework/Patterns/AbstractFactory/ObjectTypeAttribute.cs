using System;

namespace Avocado.Framework.Game.Patterns.AbstractFactory {
    public class ObjectTypeAttribute : Attribute{
        public string Type { get; }

        public ObjectTypeAttribute(string type) {
            Type = type;
        }
    }
}
