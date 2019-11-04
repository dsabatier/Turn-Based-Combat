namespace TurnBasedCombat
{
    /// <summary>
    /// Decorate damage to stack effects
    /// </summary>
    public class DamageDecorator : Damage
    {
        public DamageDecorator(Damage damage)
        {
            _amount += damage.Amount;
            _damageType |= damage.Type;
        }
    }
}