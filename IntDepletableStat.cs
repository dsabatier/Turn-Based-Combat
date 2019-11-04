using System;

namespace TurnBasedCombat
{
    [Serializable]
    public class IntDepletableStat : DepletableStat<int>
    {
        public IntDepletableStat(int max) : base(max)
        {
        }

        public override void Add(int amount)
        {
            _amount += Math.Min(amount, Max);
        }
        
        public override void Remove(int amount)
        {
            _amount -= Math.Max(0, amount);

            if (_amount == 0)
                RaiseDepletedEvent();
        }

        public void Deplete()
        {
            Remove(_amount);
        }

        public void Replenish()
        {
            Add(Max - _amount);
        }


    }
}