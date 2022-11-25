using System;
using Avocado.Toolbox.Patterns.Factory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Avocado.Toolbox.Loader.Json {
    public class TypeBaseConverter<T> : JsonConverter<T> where T : class {
        private Factory<T> _factory = new Factory<T>();
        public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer) {
            writer.WriteValue(value.ToString());
        }

        public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer) {
            var item = JObject.Load(reader);
            var type = item["Type"].ToObject<string>();

            var obj = _factory.Create(type, item);
            
            return obj;
        }
    }
}