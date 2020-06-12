namespace Avocado.Framework.Patterns.StateMachine {
    public interface IState {
        void Tick();
        void Enter();
        void Exit();
    }
}
