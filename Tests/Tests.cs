using System;
using System.Collections.Generic;
using NUnit.Framework;
using TurnBasedEncounter;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Can_Create_Encounter()
        {
            // Unit1
            List<IEncounterAction> encounterActions = new List<IEncounterAction>();
            Unit unit1 = new Unit(new UnitStats(encounterActions, new IntDepletableStat(10)));
            
            // Unit2
            encounterActions = new List<IEncounterAction>();
            Unit unit2 = new Unit(new UnitStats(encounterActions, new IntDepletableStat(10)));
            
            Encounter encounter = new Encounter(new List<Unit>() { unit1, unit2 });
            encounter.Begin();
            
            Assert.IsNotNull(encounter.CurrentUnit);
        }

        [Test]
        public void Can_Loop_Through_Turns()
        {
            // Unit1
            List<IEncounterAction> encounterActions = new List<IEncounterAction>();
            Unit unit1 = new Unit(new UnitStats(encounterActions, new IntDepletableStat(10)));
            
            // Unit2
            encounterActions = new List<IEncounterAction>();
            Unit unit2 = new Unit(new UnitStats(encounterActions, new IntDepletableStat(10)));
            
            // Unit3
            encounterActions = new List<IEncounterAction>();
            Unit unit3 = new Unit(new UnitStats(encounterActions, new IntDepletableStat(10)));
            
            Encounter encounter = new Encounter(new List<Unit>() { unit1, unit2, unit3 });
            encounter.Begin();
            encounter.Next();
            encounter.Next();
            encounter.Next();
            
            Assert.IsNotNull(encounter.CurrentUnit);
        }

        [Test]
        public void Can_Deplete()
        {
            IntDepletableStat stat = new IntDepletableStat(10);
            stat.Deplete();

            Assert.AreEqual(stat.Amount, 0);
        }
        
        [Test]
        public void Can_Replenish()
        {
            IntDepletableStat stat = new IntDepletableStat(10);
            stat.Deplete();
            stat.Replenish();
            
            Assert.AreEqual(stat.Amount, 10);
        }

        [Test]
        public void Can_Be_Depleted()
        {
            IntDepletableStat stat = new IntDepletableStat(10);
            stat.Remove(5);
            Assert.AreEqual(stat.Amount, 5);
        }

        [Test]
        public void Can_Be_Overkilled()
        {
            IntDepletableStat stat = new IntDepletableStat(10);
            stat.Remove(100);
            
            Assert.AreEqual(stat.Amount, 0);
        }

        [Test]
        public void Max_Set_Correctly()
        {
            IntDepletableStat stat = new IntDepletableStat(10);
            
            Assert.AreEqual(stat.Amount, 10);
        }

        [Test]
        public void Event_Fires_On_Encounter_Start()
        {
            bool eventFired = false;
            List<IEncounterAction> encounterActions = new List<IEncounterAction>();
            Unit unit1 = new Unit(new UnitStats(encounterActions, new IntDepletableStat(10)));
            
            Encounter encounter = new Encounter(new List<Unit>() { unit1 });
            encounter.OnStart += () => eventFired = true;
            encounter.Begin();
            
            Assert.IsTrue(eventFired);
        }

        [Test]
        public void Event_Fires_On_Encounter_End()
        {
            bool eventFired = false;
            List<IEncounterAction> encounterActions = new List<IEncounterAction>();
            Unit unit1 = new Unit(new UnitStats(encounterActions, new IntDepletableStat(10)));
            
            Encounter encounter = new Encounter(new List<Unit>() { unit1 });
            encounter.OnComplete += () => eventFired = true;
            encounter.Begin();
            encounter.End();
            
            Assert.IsTrue(eventFired);
        }
    }
}