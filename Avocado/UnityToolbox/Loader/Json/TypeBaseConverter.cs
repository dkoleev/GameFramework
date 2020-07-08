using System;
using Avocado.Framework.Patterns.Factory.Simple.SimpleFactoryStatic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Avocado.UnityToolbox.Loader.Json {
    public class TypeBaseConverter<T> : JsonConverter<T> where T : class {
        public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer) {
            writer.WriteValue(value.ToString());
        }

        public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer) {
            var item = JObject.Load(reader);
            var type = item["Type"].ToObject<string>();

            var obj = Factory<T>.Create(type, item);
            
            return obj;
        }
    }
}