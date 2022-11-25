using System.Collections.Generic;
using UnityEngine;

namespace Avocado.Toolbox.Extensions {
    public static class IListExtensions {
        public static T GetRandomAndRemove<T>(this IList<T> source) {
            if (source.Count == 0) {
                Debug.LogWarning("Trying to get random from empty collection!");
                return default(T);
            }
            
            int index = UnityEngine.Random.Range(0, source.Count);
            var outer = source[index];
            
            source.RemoveAt(index);
            
            return outer;
        }
    }
}
