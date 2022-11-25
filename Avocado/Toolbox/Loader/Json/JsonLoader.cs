using Newtonsoft.Json;
using UnityEngine;

namespace Avocado.Toolbox.Loader.Json {
    public class JsonLoader : ILoader{
        public T LoadObject<T>(string path) {
            string filePath = path.Replace(".json", "");

            var targetFile = Resources.Load<TextAsset>(filePath);
            var deserializedData = JsonConvert.DeserializeObject<T>(targetFile.text);

            return deserializedData;
        }
    }
}