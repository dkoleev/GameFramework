using System;
using System.Collections.Generic;
using Avocado.Toolbox;
using Avocado.Toolbox.Loader.Json;
using Avocado.Toolbox.Patterns.Factory;
using UnityEngine;

namespace Avocado.Examples.Factory
{
    public class TestFactory : MonoBehaviour
    {
        public void Start() {
            TestWithRemoteConfig();
        }

        private void TestWithRemoteConfig() {
            LoadConfig();
            
            void LoadConfig() {
                var loader = new JsonLoader();
                var data = loader.LoadObject<ConfigData>("config");//objects creating by factory inside TypeBaseConverter
                foreach (var item in data.Components) {
                    GameLogger.Info(item.Value.GetType().ToString());
                }
            }
        }
        
        [Serializable]
        public readonly struct ConfigData {
            public readonly Dictionary<string, IComponent> Components;

            public ConfigData(Dictionary<string, IComponent> components) {
                Components = components;
            }
        }

        private void Test() {
            var factory = new Factory<IComponent>();
            var c1 = factory.Create("StructA");
            
            GameLogger.Info(c1.GetType().ToString());
        }
    }
}