using Avocado.Framework.Patterns.Factory.Simple.SimpleFactoryStatic;
using UnityEngine;
using Logger = Avocado.Framework.Utilities.Logger;

namespace Avocado.Examples.Factory
{
    public class TestFactory : MonoBehaviour
    {
        public void Start()
        {
            var testClass = Factory<BaseClassA>.Create("ClassC");
            var testStruct = Factory<IComponent>.Create("StructA");
            
            Logger.Log(testClass.GetType() + "; " + testStruct.GetType());
        }
    }
}