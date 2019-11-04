using System;
using System.Collections.Generic;

namespace TurnBasedCombat
{
    public class ConditionObservable : IObservable<ConditionObservable>
    {
        private List<IObserver<ConditionObservable>> _observers = new List<IObserver<ConditionObservable>>();
        
        public IDisposable Subscribe(IObserver<ConditionObservable> observer)
        {
            _observers.Add(observer);
            
            return new Unsubscriber(_observers, observer);
        }

        /// <summary>
        /// Evaluates condition and alerts observers if the conditions have been met
        /// </summary>
        public void Evaluate()
        {
            bool conditionsMet = true;
            if (conditionsMet)
            {
                foreach (var observer in _observers)
                {
                    observer.OnCompleted();
                }
            }
            else
            {
                foreach (var observer in _observers)
                {
                    observer.OnNext(this);
                }
            }
        }
        
        private class Unsubscriber : IDisposable
        {
            private List<IObserver<ConditionObservable>> _observers;
            private IObserver<ConditionObservable> _observer;
            
            public Unsubscriber(List<IObserver<ConditionObservable>> observers,
                IObserver<ConditionObservable> observer)
            {
                _observers = observers;
                _observer = observer;
            }
            
            public void Dispose()
            {
                if (_observers != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
            
        }
    }
}