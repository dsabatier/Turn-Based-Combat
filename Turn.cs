using System;

namespace TurnBasedCombat
{
    public class Turn
    {
        private static readonly Turn _null = new Turn(Combatant.NullCombatant);
        public static Turn NullTurn => _null;
        
        private Turn _currentTurn = NullTurn;

        public event Action OnStart = () => { };
        public event Action OnComplete = () => { };
        public readonly Combatant Combatant;
        
        public Turn(Combatant combatant)
        {
            Combatant = combatant;
        }
    }
}