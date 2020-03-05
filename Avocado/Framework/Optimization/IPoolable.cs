namespace Avocado.Framework.Optimization {
    public interface IPoolable {
        void Spawn();
        void Release();
    }
}