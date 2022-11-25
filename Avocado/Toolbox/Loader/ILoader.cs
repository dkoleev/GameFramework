namespace Avocado.Toolbox.Loader {
    public interface ILoader {
        T LoadObject<T>(string path);
    }
}
