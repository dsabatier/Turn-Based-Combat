using System;

namespace TurnBasedCombat
{
    /// <summary>
    /// Add/Remove from the stat.  It will announce when it is depleted.
    /// </summary>
    public abstract class DepletableStat<T> where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        public event Action OnDepleted = () => { };

        public readonly T Max;
        protected T _amount;
        public T Amount => _amount;

        public DepletableStat(T max)
        {
            Max = max;
            _amount = max;
        }

        protected void RaiseDepletedEvent()
        {
            OnDepleted(); 
        }
        
        public abstract void Remove(T amount);
        public abstract void Add(T amount);
    }
}