namespace Avocado.Toolbox.Optimization.BatchUpdateSystem {
    public interface IBatchUpdated {
        void RegisterAsButchUpdated();
        void BatchUpdate();
    }
}