using Avocado.Framework.Patterns.AbstractFactory;
using UnityEngine;
using Logger = Avocado.Framework.Utilities.Logger;

namespace Avocado.Framework.Examples.Factory
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