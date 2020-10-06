using System;
using Avocado.Framework.Patterns.Factory;
using JetBrains.Annotations;

namespace Avocado.Examples.Factory
{
    [UsedImplicitly]
    [ObjectType("StructA")]
    [Serializable]
    public readonly struct StructA : IComponent
    {
        
    }
}