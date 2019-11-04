namespace TurnBasedCombat
{
    public abstract class Damage
    {
        protected DamageType _damageType;
        protected int _amount;

        protected Damage()
        {
            
        }
        
        public Damage(DamageType damageType, int amount)
        {
            _damageType = damageType;
            _amount = amount;
        }

        public int Amount => _amount;
        public DamageType Type => _damageType;
    }
}