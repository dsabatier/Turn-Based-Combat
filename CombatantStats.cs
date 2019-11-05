using System;
using System.Collections.Generic;

namespace TurnBasedCombat
{
    /// <summary>
    /// Required properties for each combatant
    /// </summary>
    public class CombatantStats
    {
        private static readonly CombatantStats _null = new CombatantStats(-1, new List<ICombatAction>(), new IntDepletableStat(-1));
        public static CombatantStats NullTurn => _null;
        
        public readonly IntDepletableStat Health;
        public readonly int Initiative;
        public readonly List<ICombatAction> Actions;
        
        public CombatantStats(int initiative, List<ICombatAction> combatActions, IntDepletableStat health)
        {
            Initiative = initiative;
            Actions = combatActions;
            Health = health;
        }
    }
}