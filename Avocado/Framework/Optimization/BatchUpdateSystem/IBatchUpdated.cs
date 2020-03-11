namespace Avocado.Framework.Optimization.BatchUpdateSystem {
    public interface IBatchUpdated {
        void RegisterAsButchUpdated();
        void BatchUpdate();
    }
}