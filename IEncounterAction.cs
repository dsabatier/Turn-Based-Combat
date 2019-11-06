using System;

namespace TurnBasedEncounter
{
    public interface IEncounterAction
    {
        event Action OnSelected;
        void Select();
    }
}