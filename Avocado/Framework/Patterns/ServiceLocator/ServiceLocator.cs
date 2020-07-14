namespace Avocado.Framework.Patterns.ServiceLocator {
    public class ServiceLocator<TService> where TService : IService {
        public static TService Current => _service;
        
        private static TService _service;

        public static void Provide(TService service) {
            _service = service;
        }
    }
}