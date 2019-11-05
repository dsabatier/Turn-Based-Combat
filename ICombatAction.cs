using System;

namespace TurnBasedCombat
{
    public interface ICombatAction
    {
        event Action OnSelected;
        void Select();
    }
}