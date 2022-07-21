using UnityEditor;
using UnityEngine;

namespace Avocado.Editor.Utils {
    public static class ResourcesUtils {
        public static T[] GetAllInstances<T>() where T : ScriptableObject {
            string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);
            T[] a = new T[guids.Length];
            for (int i = 0; i < guids.Length; i++) {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
            }

            return a;
        }

        public static T GetInstance<T>() where T : ScriptableObject {
            string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);
            if (guids.Length == 0) {
                Debug.LogWarning("Not found asset with type " + typeof(T));
            } else if (guids.Length > 1) {
                Debug.LogWarning("Found several asset with type " + typeof(T) + ". Return first with guid " +
                                 guids[0]);
            }

            string path = AssetDatabase.GUIDToAssetPath(guids[0]);

            return AssetDatabase.LoadAssetAtPath<T>(path);
        }
    }
}
