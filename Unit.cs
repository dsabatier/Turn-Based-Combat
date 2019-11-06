using System.Collections.Generic;

namespace TurnBasedEncounter
{
    /// <summary>
    /// Base participant in each combat
    /// </summary>
    public class Unit
    {
        public static Unit NullUnit { get; } = new Null(new UnitStats(new List<IEncounterAction>(), new IntDepletableStat(-1)));

        public readonly UnitStats UnitStats;
        public readonly List<IEncounterAction> EncounterActions;

        public Unit(UnitStats stats)
        {
            UnitStats = stats;
        }

        private class Null : Unit
        {
            public Null(UnitStats stats) : base(stats)
            {
            }
        }
    }
}