using System.Collections.Generic;
using System.Linq;
using Avocado.Toolbox.DataTypes;
using UnityEngine;

namespace Avocado.Toolbox.Extensions {
    public static class WeighedExtension {
        public static int GetRandomByWeight(this IEnumerable<int> itemsWithWeight) {
            var withWeight = itemsWithWeight as int[] ?? itemsWithWeight.ToArray();
            var weightTotal = withWeight.Sum();
            var weightRoll = Random.Range(0, weightTotal);
            var index = -1;
            while (weightRoll > -1) {
                index++;
                weightRoll -= withWeight[index];
            }

            return index;
        }
        
        public static T GetRandomWeight<T>(this IEnumerable<T> itemsWithWeight) where T : IWeighed {
            var withWeight = itemsWithWeight as T[] ?? itemsWithWeight.ToArray();
            var weightTotal = withWeight.Sum(i => i.Weight);
            var weightRoll = Random.Range(0, weightTotal);
            var index = -1;
            while (weightRoll > -1) {
                index++;
                weightRoll -= withWeight.ElementAt(index).Weight;
            }

            return withWeight.ElementAt(index);
        }

        public static T GetRandomWeight<T>(this T[] itemsWithWeight) where T : IWeighed {
            var weightTotal = itemsWithWeight.Sum(i => i.Weight);
            var weightRoll = Random.Range(0, weightTotal);
            var index = -1;
            while (weightRoll > -1) {
                index++;
                weightRoll -= itemsWithWeight[index].Weight;
            }

            return itemsWithWeight[index];
        }
    }
}
