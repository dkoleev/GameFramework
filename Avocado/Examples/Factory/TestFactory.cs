using Avocado.Framework.Patterns.Factory.Simple.SimpleFactory;
using UnityEngine;
using Logger = Avocado.Framework.Utilities.Logger;
using StaticFactory = Avocado.Framework.Patterns.Factory.Simple.SimpleFactoryStatic;

namespace Avocado.Examples.Factory
{
    public class TestFactory : MonoBehaviour
    {
        public void Start() {
            Test();
        }

        private void Test() {
            var factory = new Factory<IComponent>();
            var loggedFactory = new FactoryLogWrapper<IComponent>(factory);

            var c1 = factory.Create("StructA");
            var c2 = loggedFactory.Create("StructB");
            
            Logger.Log(c1.GetType() + "; " + c2.GetType());
        }

        private void TestStatic() {
            var testClass = StaticFactory.Factory<BaseClassA>.Create("ClassC");
            var testStruct = StaticFactory.Factory<IComponent>.Create("StructA");
            
            Logger.Log(testClass.GetType() + "; " + testStruct.GetType());
        }
    }
}