namespace Avocado.UnityToolbox.Optimization.Pool {
    public interface IPoolable {
        void Spawn();
        void Release();
    }
}