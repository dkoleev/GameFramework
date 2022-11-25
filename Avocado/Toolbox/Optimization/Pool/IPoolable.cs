namespace Avocado.Toolbox.Optimization.Pool {
    public interface IPoolable {
        void Spawn();
        void Release();
    }
}