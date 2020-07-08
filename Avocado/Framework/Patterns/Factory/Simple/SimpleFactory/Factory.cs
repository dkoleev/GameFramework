using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Avocado.Framework.Patterns.Factory.Simple.SimpleFactory {
    public class Factory<T> : IFactory<T> where T : class {
        private readonly Dictionary<string, Type> _types = new Dictionary<string, Type>();

        public Factory() {
            var temp = Assembly.GetAssembly(typeof(T)).GetTypes().Where(mType =>
                !mType.IsAbstract &&
                (mType.IsSubclassOf(typeof(T)) || mType.GetInterfaces().Contains(typeof(T)))
            ).ToList();

            foreach (var type in temp) {
                var attr = type.GetCustomAttribute<ObjectTypeAttribute>();
                if (attr != null) {
                    _types.Add(attr.Type, type);
                }
            }
        }

        public T Create(string type) {
            if (!_types.ContainsKey(type)) {
                throw new KeyNotFoundException("Not found key for type " + type);
            }

            return Activator.CreateInstance(_types[type]) as T;
        }
    }
}
