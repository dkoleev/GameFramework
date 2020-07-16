namespace Avocado.UnityToolbox.Optimization.BatchUpdateSystem {
    public interface IBatchUpdated {
        void RegisterAsButchUpdated();
        void BatchUpdate();
    }
}