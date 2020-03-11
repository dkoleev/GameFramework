namespace Avocado.Framework.Optimization.BatchUpdateSystem {
    public interface IBatchUpdated {
        void Register();
        void BatchUpdate();
    }
}