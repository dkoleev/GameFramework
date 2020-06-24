namespace Avocado.Framework.Patterns.Command
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}