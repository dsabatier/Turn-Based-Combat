using System.Collections.Generic;

namespace TurnBasedCombat
{
    /// <summary>
    /// Base participant in each combat
    /// </summary>
    public class Combatant
    {
        public static Combatant NullCombatant { get; } = new Combatant(null);

        public readonly CombatantStats CombatantStats;
        public readonly List<ICombatAction> CombatActions;

        public Combatant(CombatantStats stats)
        {
            CombatantStats = stats;
        }
    }
}