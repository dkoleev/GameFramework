using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Avocado.Toolbox.Loader.Json
{
    public class JsonLoader : ILoader
    {
        public T LoadObject<T>(string path)
        {
            string filePath = path.Replace(".json", "");

            var targetFile = Resources.Load<TextAsset>(filePath);
            var deserializedData = JsonConvert.DeserializeObject<T>(targetFile.text);

            return deserializedData;
        }

        private async UniTask LoadJsonDataAsync<T>(string path)
        {
            AsyncOperationHandle<TextAsset> handle = default;
            try
            {
                handle = Addressables.LoadAssetAsync<TextAsset>(path);
                var jsonFile = await handle.ToUniTask();

                var result = JsonConvert.DeserializeObject<Dictionary<string, T>>(jsonFile.text);

                GameLogger.Info($"✅ Loaded {result.Count} {typeof(T)} entries", "⏳ Loading");
            }
            catch (System.Exception e)
            {
                GameLogger.Error($"❌ Failed to load fish_data.json: {e.Message}", "⏳ Loading");
            }
            finally
            {
                if (handle.IsValid())
                {
                    Addressables.Release(handle);
                }
            }
        }
    }
}
