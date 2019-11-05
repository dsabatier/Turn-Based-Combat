using System;
using System.Collections.Generic;

namespace TurnBasedCombat
{
    /// <summary>
    /// A CombatScene is made up of combatants who take turns applying Attacks to each other until the win conditions
    /// have been met. 
    /// </summary>
    public class CombatScene
    {
        /// <summary>
        /// Fired when the combat has been completed
        /// </summary>
        public event Action OnComplete = () => { };

        /// <summary>
        /// Fired when the combat has started
        /// </summary>
        public event Action OnStart = () => { };
        
        /// <summary>
        /// Fired when a turn has started
        /// </summary>
        public event Action<Turn> OnTurnStart = (turn) => { };

        /// <summary>
        /// Fired when a turn has been completed
        /// </summary>
        public event Action OnTurnComplete = () => { };
        
        private readonly List<Combatant> _combatants;
        private Turn _currentTurn;
        
        /// <summary>
        /// Create a new CombatScene
        /// </summary>
        /// <param name="combatants">A list of all combatants participating in this combat</param>
        public CombatScene(List<Combatant> combatants)
        {
            _combatants = combatants;
        }

        /// <summary>
        /// Begin this encounter
        /// </summary>
        public void Start()
        {
            _currentTurn = new Turn(_combatants[0]);

            _currentTurn.OnStart += HandleTurnStarted;
            _currentTurn.OnComplete += HandleTurnComplete;
            OnStart();
        }

        public void NextTurn()
        {
            
        }
        
        private void HandleTurnStarted()
        {
            OnTurnStart(_currentTurn);
            _currentTurn.OnStart -= HandleTurnStarted;
        }

        private void HandleTurnComplete()
        {
            OnTurnComplete();
            _currentTurn.OnComplete -= HandleTurnComplete;
        }
    }
}