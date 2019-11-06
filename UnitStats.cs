using System;
using System.Collections.Generic;

namespace TurnBasedEncounter
{
    /// <summary>
    /// Required properties for each combatant
    /// </summary>
    public class UnitStats
    {
        public readonly IntDepletableStat Health;
        public readonly List<IEncounterAction> Actions;
        
        public UnitStats(List<IEncounterAction> combatActions, IntDepletableStat health)
        {
            Actions = combatActions;
            Health = health;
        }
    }
}