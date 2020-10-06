using System;
using Avocado.Framework.Patterns.Factory;
using JetBrains.Annotations;

namespace Avocado.Examples.Factory
{
    [UsedImplicitly]
    [ObjectType("StructB")]
    [Serializable]
    public readonly struct StructB : IComponent
    {
        
    }
}