using System;

namespace TurnBasedCombat
{
    [Flags]
    public enum DamageType
    {
        Physical,
        Magical,
        Fire,
        Lightning
    }
}