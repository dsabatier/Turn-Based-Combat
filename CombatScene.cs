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
        
        private readonly List<Combatant> _combatants;
        
        // TODO: this doesn't seem good, maybe create IObservable<Round> and IObserver<Round> that is passed in from the client?
        private Round _currentRound = Round.NullRound;
        public Round CurrentRound => _currentRound;
        
        private ConditionObserver _winConditionObserver;
        private ConditionObservable _winConditionObservable;
        
        /// <summary>
        /// Create a new CombatScene
        /// </summary>
        /// <param name="combatants">A list of all combatants participating in this combat</param>
        /// <param name="winConditionObservable">The observable condition required for this condition to be completed</param>
        public CombatScene(List<Combatant> combatants, ConditionObservable winConditionObservable)
        {
            _combatants = combatants;
            _winConditionObservable = winConditionObservable;
        }

        /// <summary>
        /// Begin this combat
        /// </summary>
        public void StartCombat()
        {
            _currentRound = new Round(_combatants, _winConditionObservable);
            _currentRound.OnComplete += HandleRoundCompleted;

            _winConditionObserver = new ConditionObserver();
            _winConditionObserver.OnCompleteEvent += HandleWinConditionCompleteEvent;
            _winConditionObserver.OnNextEvent += HandleNextRoundEvent;

            _winConditionObserver.Subscribe(_winConditionObservable);
        }

        private void HandleNextRoundEvent()
        {
            _currentRound = new Round(_combatants, _winConditionObservable);
            _currentRound.OnComplete += HandleRoundCompleted;
        }

        private void HandleWinConditionCompleteEvent()
        {
            _currentRound.OnComplete -= HandleRoundCompleted;
            _winConditionObserver.Unsubscribe();
            
            _currentRound = null;

            OnComplete();
        }

        private void HandleRoundCompleted()
        {
            _currentRound.OnComplete -= HandleRoundCompleted;
        }
    }
}