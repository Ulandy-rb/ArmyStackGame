using ArmyStackGame.SpecialAction;
using ArmyStackGame.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Strategy
{
	public interface IStrategy
	{
		List<int> GetIndexOpponents(IArmy firstarmy,IArmy secondArmy);
		IEnumerable<int> GetPosiblePositionsForActions(IArmy army, IArmy enemyArmy, ISpecialAction currUnit, int currUnitPosition);
	}
}
