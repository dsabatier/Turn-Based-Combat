using System;
using System.Collections.Generic;

namespace TurnBasedCombat
{
    /// <summary>
    /// Base participant in each combat
    /// </summary>
    public abstract class Combatant : IDamageable, IAttacker
    {
        /// <summary>
        /// Called by combatant when it is defeated
        /// </summary>
        public event Action OnDefeat = () => { };
        public readonly CombatantStats CombatantStats;
        public abstract void ReceiveDamage(Damage attack);
        public abstract void Attack(Combatant target = null);

        public Combatant(CombatantStats stats)
        {
            CombatantStats = stats;
        }
    }

    /// <summary>
    /// Required properties for each combatant
    /// </summary>
    [Serializable]
    public class CombatantStats
    {
        public readonly IntDepletableStat Health;
        public readonly int Initiative;
        public readonly List<IAttack> Attacks;
        
        public CombatantStats(int initiative, List<IAttack> attacks, IntDepletableStat health)
        {
            Initiative = initiative;
            Attacks = attacks;
            Health = health;
        }
    }
}