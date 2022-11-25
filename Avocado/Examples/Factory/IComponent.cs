using Avocado.Toolbox.Loader.Json;
using Newtonsoft.Json;

namespace Avocado.Examples.Factory
{
    [JsonConverter(typeof(TypeBaseConverter<IComponent>))]
    public interface IComponent
    {
        
    }
}