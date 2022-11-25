using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Avocado.Toolbox.Patterns.Factory {
    public class Factory<T> where T : class {
        private readonly Dictionary<string, Type> _types;

        public Factory() {
            _types = new Dictionary<string, Type>();
            Initialize();
        }

        private void Initialize() {
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

        public T Create(string type, params Object[] data) {
            if (!_types.ContainsKey(type)) {
                throw new KeyNotFoundException("Not found key for type " + type + " in " + typeof(T));
            }

            var result = (T)Activator.CreateInstance(_types[type], data);

            return result;
        }
    }
}