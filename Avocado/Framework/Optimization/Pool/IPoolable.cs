namespace Avocado.Framework.Optimization.Pool {
    public interface IPoolable {
        void Spawn();
        void Release();
    }
}