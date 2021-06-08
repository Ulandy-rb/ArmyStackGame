using ArmyStackGame.Army;
using ArmyStackGame.Commands;
using ArmyStackGame.Improvements;
using ArmyStackGame.Units;
using System;
using System.Collections.Generic;

namespace ArmyStackGame
{
	class Program
	{
		static void Main(string[] args)
		{
			var army = new Army.Army(100, new RandomFactory());
			HeavyUnit heavyUnit = new HeavyUnit(1, 2, 3);
			LightUnit lightUnit = new LightUnit(1, 2, 4,1,7);
			lightUnit.DoSpecialAction(army, 1,new List<int>() { 1,2});


			var c = new UndoRedoManager();
			c.RunCommand(new HitCommand(army.Units[0], army.Units[0], 5));
			c.RunCommand(new HitCommand(army.Units[0], army.Units[0], 5));
			c.EndTurn();
			c.RunCommand(new HitCommand(army.Units[0], army.Units[0], 5));
			c.EndTurn();
		}
	}
}
