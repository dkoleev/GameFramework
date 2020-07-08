namespace Avocado.Framework.Patterns.Factory.Simple.SimpleFactory {
    public interface IFactory<out T> {
        T Create(string type);
    }
}