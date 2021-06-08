using ArmyStackGame.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Commands
{
	class DeleteDeathUnitsCommand : ICommand
	{
		private readonly IArmy targetArmy;
		private List<Tuple<int, IUnit>> deathUnits; 

		public DeleteDeathUnitsCommand( IArmy targetArmy)
		{
			this.targetArmy = targetArmy;
		}
		public void Run()
		{
			for (int i = 0; i < targetArmy.Units.Count; i++)
			{
				if (!targetArmy.Units[i].IsAlive)
				{
					deathUnits.Add(new Tuple<int, IUnit>(i, targetArmy.Units[i]));
					targetArmy.Units.RemoveAt(i);
				}
			}
		}

		public void Undo()
		{
			for (int i = 0; i < deathUnits.Count; i++)
			{
				targetArmy.Units.Insert(deathUnits[i].Item1, deathUnits[i].Item2);
			}
		}
	}
}
