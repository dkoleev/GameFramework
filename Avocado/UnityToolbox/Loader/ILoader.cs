namespace Avocado.UnityToolbox.Loader {
    public interface ILoader {
        T LoadObject<T>(string path);
    }
}
