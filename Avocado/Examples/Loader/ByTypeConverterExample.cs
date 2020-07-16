using System;
using System.Collections.Generic;
using System.Linq;
using Avocado.Framework.Patterns.Factory.Simple;
using Avocado.UnityToolbox.Loader.Json;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Logger = Avocado.UnityToolbox.Logger;

namespace Avocado.Examples.Loader {
    public class ByTypeConverterExample {
        public static void Example() {
            var loader = new JsonLoader();
            var data = loader.LoadObject<Data>("TestLoader/config");
            foreach (var actor in data.Actors) {
                Logger.Log(actor.Value.GetType().ToString());
            }

            var zombie = data.Actors.Values.First(actor => actor is Zombie) as Zombie;
            Logger.Log(zombie?.SomeZombieField);
        }
        
        [Serializable]
        public class Data {
            public Dictionary<string, Actor> Actors;
        }
        
        [JsonConverter(typeof(TypeBaseConverter<Actor>))]
        [Serializable]
        public abstract class Actor {
            public string Name;
            public int Age;

            public Actor(JObject data) {
                Name = data["Name"].Value<string>();
                Age = data["Age"].Value<int>();
            }
        }
        
        [ObjectType("Zombie")]
        [UsedImplicitly]
        [Serializable]
        public class Zombie : Actor {
            public string SomeZombieField;

            public Zombie(JObject data) : base(data) {
                SomeZombieField = data["SomeZombieField"].Value<string>();
            }
        }
        
        [ObjectType("Troll")]
        [UsedImplicitly]
        [Serializable]
        public class Troll : Actor {
            public int SomeTrollField;

            public Troll(JObject data) : base(data) {
                SomeTrollField = data["SomeTrollField"].Value<int>();
            }
        }
    }
}