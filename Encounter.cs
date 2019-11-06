using System;
using System.Collections.Generic;

namespace TurnBasedEncounter
{
    /// <summary>
    /// A CombatScene is made up of combatants who take turns applying Attacks to each other until the win conditions
    /// have been met. 
    /// </summary>
    public class Encounter
    {
        /// <summary>
        /// Fired when the combat has been completed
        /// </summary>
        public event Action OnComplete = () => { };

        /// <summary>
        /// Fired when the combat has started
        /// </summary>
        public event Action OnStart = () => { };
        
        private readonly List<Unit> _units;
        private int _currentUnitIndex;

        public Unit CurrentUnit => _units[_currentUnitIndex];
        
        /// <summary>
        /// Create a new CombatScene
        /// </summary>
        /// <param name="units">A list of all combatants participating in this combat</param>
        public Encounter(List<Unit> units)
        {
            _units = units;
        }

        /// <summary>
        /// Begin this encounter
        /// </summary>
        public void Begin()
        {
            OnStart();
            _currentUnitIndex = 0;
            Console.WriteLine(_currentUnitIndex);
        }

        public void Next()
        {
            _currentUnitIndex++;
            _currentUnitIndex %= _units.Count;
            Console.WriteLine(_currentUnitIndex);
        }

        public void End()
        {
            OnComplete();
        }
        
    }
}