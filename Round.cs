using System;
using System.Collections.Generic;
using System.Linq;

namespace TurnBasedCombat
{
    public class Round
    {
        private static readonly Round _null = new Round(new List<Combatant>(), new ConditionObservable());
        public static Round NullRound => _null;
        
        /// <summary>
        /// Called when this round has been completed;
        /// </summary>
        public event Action OnComplete = () => { };
        
        private readonly List<Turn> _initiativeOrder;
        private readonly ConditionObservable _winConditionObservable;

        /// <summary>
        /// One round of combat is made up of one turn per combatant
        /// </summary>
        /// <param name="combatants"></param>
        /// <param name="winConditionObservable"></param>
        /// <exception cref="Exception"></exception>
        public Round(List<Combatant> combatants, ConditionObservable winConditionObservable)
        {
            if(combatants == null)
                throw new Exception("Combatants cannot be null");

            _initiativeOrder = combatants
                .OrderBy(combatant => combatant.CombatantStats.Initiative)
                .Select(c => new Turn(c))
                .ToList();
            
            _winConditionObservable = winConditionObservable;
        }
        
        /// <summary>
        /// Call from UI when you are ready for next round of combat to begin
        /// </summary>
        public void StartRound()
        {
            _initiativeOrder.LastOrDefault().OnComplete += HandleTurnComplete;
        }

        /// <summary>
        /// At the end of each turn, announce the round is complete, remove that turn from the list
        /// and evaluate if win conditions have been met.
        ///
        /// The next round should be called by the UI when it's ready
        /// </summary>
        /// <param name="turn"></param>
        private void HandleTurnComplete(Turn turn)
        {
            if (_initiativeOrder.Count > 0)
                OnComplete();
            
            _initiativeOrder.Remove(turn);
            _winConditionObservable.Evaluate();
        }
    }
}