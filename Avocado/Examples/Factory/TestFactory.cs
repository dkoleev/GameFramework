using System;
using System.Collections.Generic;
using Avocado.Framework.Patterns.Factory;
using Avocado.UnityToolbox.Loader.Json;
using UnityEngine;
using Logger = Avocado.UnityToolbox.Logger;

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
                    Logger.Log(item.Value.GetType().ToString());
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
            
            Logger.Log(c1.GetType().ToString());
        }
    }
}