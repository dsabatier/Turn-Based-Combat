using System;

namespace TurnBasedCombat
{
    public class Turn
    {
        public event Action<Turn> OnComplete = turn => { };
        private Combatant _combatant;

        private IAttack _attack;
        
        public Turn(Combatant combatant)
        {
            _combatant = combatant;
        }
        
        /// <summary>
        /// Executes an attack on the target
        /// </summary>
        /// <param name="target"></param>
        public void MakeAttack(Combatant target)
        {
            target.ReceiveDamage(_attack.GetDamage());
        }
        
        /// <summary>
        /// Select which combat action will be taken
        /// </summary>
        /// <param name="attack"></param>
        public void SetAttack(IAttack attack)
        {
            _attack = attack;
        }

        /// <summary>
        /// Called by UI when the turn has been completed
        /// </summary>
        public void CompleteTurn()
        {
            OnComplete(this);
            OnComplete = null;
        }
    }
}