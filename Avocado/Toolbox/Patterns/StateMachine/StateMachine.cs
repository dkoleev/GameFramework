using System;
using System.Collections.Generic;

namespace Avocado.Toolbox.Patterns.StateMachine {
    public class StateMachine {
        public Action<IState, IState> OnStateChanged;
        
        private IState _currentState;
        private Dictionary<Type, List<Transition>> _transitions = new Dictionary<Type,List<Transition>>();
        private List<Transition> _currentTransitions = new List<Transition>();
        private readonly List<Transition> _anyTransitions = new List<Transition>();
        
        private static List<Transition> _emptyTransitions = new List<Transition>(0);
        
        public void Tick()
        {
            var transition = GetTransition();
            if (transition != null)
                SetState(transition.To);
      
            _currentState?.Tick();
        }

        public void SetState(IState state)
        {
            if (state == _currentState)
                return;
      
            var prevState = _currentState;
            prevState?.Exit();
            _currentState = state;
      
            _transitions.TryGetValue(_currentState.GetType(), out _currentTransitions);
            if (_currentTransitions == null) {
                _currentTransitions = _emptyTransitions;
            }
            
            _currentState.Enter();
            
            OnStateChanged?.Invoke(prevState, _currentState);
        }

        public void AddTransition(IState from, IState to, Func<bool> predicate)
        {
            if (_transitions.TryGetValue(from.GetType(), out var transitions) == false)
            {
                transitions = new List<Transition>();
                _transitions[from.GetType()] = transitions;
            }
      
            transitions.Add(new Transition(to, predicate));
        }

        public void AddAnyTransition(IState to, Func<bool> predicate)
        {
            _anyTransitions.Add(new Transition(to, predicate));
        }
        
        private class Transition
        {
            public Func<bool> Condition {get; }
            public IState To { get; }

            public Transition(IState to, Func<bool> condition)
            {
                To = to;
                Condition = condition;
            }
        }

        private Transition GetTransition()
        {
            foreach(var transition in _anyTransitions)
                if (transition.Condition())
                    return transition;
      
            foreach (var transition in _currentTransitions)
                if (transition.Condition())
                    return transition;

            return null;
        }
    }
}
