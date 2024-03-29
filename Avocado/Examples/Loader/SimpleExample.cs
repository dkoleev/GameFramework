using System;
using System.Collections.Generic;
using Avocado.Toolbox.Loader.Json;
using Avocado.Toolbox.Logger;

namespace Avocado.Examples.Loader {
    public class SimpleExample {
        public static void Example() {
            var loader = new JsonLoader();
            var data = loader.LoadObject<Data>("TestLoader/config");
            foreach (var actor in data.Actors) {
                GameLogger.Log($"actor type: {actor.Key}, name: {actor.Value.Name}, age: {actor.Value.Age}");
            }
        }
        
        [Serializable]
        private class Data {
            public Dictionary<string, Actor> Actors;
        }

        [Serializable]
        private class Actor {
            public string Name;
            public int Age;
        }
    }
}
