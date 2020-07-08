using UnityEngine;

namespace Avocado.Examples.Loader {
    public class TestLoader : MonoBehaviour {
        void Start() {
            SimpleExample.Example();
            ByTypeConverterExample.Example();
        }
    }
}