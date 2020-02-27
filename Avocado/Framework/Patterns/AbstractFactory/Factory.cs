using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Avocado.Framework.Patterns.AbstractFactory {
    public class Factory<T> where T : class {
        private static readonly Dictionary<string, Type> _types = new Dictionary<string, Type>();

        static Factory() {
            var temp = Assembly.GetAssembly(typeof(T)).GetTypes().Where(mType =>
                mType.IsClass && !mType.IsAbstract && mType.IsSubclassOf(typeof(T))).ToList();

            foreach (var type in temp) {
                var attr = type.GetCustomAttribute<ObjectTypeAttribute>();
                if (attr != null) {
                    _types.Add(attr.Type, type);
                }
            }
        }

        public static T Create(string type) {
            if (!_types.ContainsKey(type)) {
                throw new KeyNotFoundException("Not found key for type " + type);
            }

            return Activator.CreateInstance(_types[type]) as T;
        }
    }
}
