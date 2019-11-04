using System;

namespace TurnBasedCombat
{
    public class ConditionObserver : IObserver<ConditionObservable>
    {
        /// <summary>
        /// Fired when the condition is met
        /// </summary>
        public event Action OnCompleteEvent = () => { };
        
        /// <summary>
        /// Fired when the condition is evaluated but it is not met
        /// </summary>
        public event Action OnNextEvent = () => { };

        private IDisposable _unsubscriber;

        public ConditionObserver()
        {
            
        }

        public virtual void Subscribe(IObservable<ConditionObservable> provider)
        {
            if (provider != null)
                _unsubscriber = provider.Subscribe(this);
        }
        
        public void OnNext(ConditionObservable value)
        {
            OnNextEvent();
        }

        public void OnError(Exception error)
        {
            throw error;
        }

        public void OnCompleted()
        {
            OnCompleteEvent();
        }

        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }
    }
}