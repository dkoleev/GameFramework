using Avocado.Framework.Utilities;

namespace Avocado.Framework.Patterns.Factory.Simple.SimpleFactory {
    public class FactoryLogWrapper<T> : IFactory<T> where T : class {
        private IFactory<T> _baseFactory;
        
        public FactoryLogWrapper(IFactory<T> baseFactory) {
            _baseFactory = baseFactory;
        }

        public T Create(string type) {
            var obj= _baseFactory.Create(type);
            Logger.Log("Create object with type: " + type);

            return obj;
        }
    }
}