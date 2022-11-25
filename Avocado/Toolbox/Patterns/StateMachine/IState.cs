namespace Avocado.Toolbox.Patterns.StateMachine {
    public interface IState {
        void Tick();
        void Enter();
        void Exit();
    }
}
