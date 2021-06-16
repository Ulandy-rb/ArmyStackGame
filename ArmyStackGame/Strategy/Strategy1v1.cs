using ArmyStackGame.SpecialAction;
using ArmyStackGame.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmyStackGame.Strategy
{
	public class Strategy1v1 : IStrategy
	{
		public List<int> GetIndexOpponents(IArmy firstarmy, IArmy secondArmy)
		{
			var indexList = new List<int>() { 0 };
			return indexList;
		}

		public IEnumerable<int> GetPosiblePositionsForActions(IArmy army, IArmy enemyArmy, ISpecialAction currUnit, int currUnitPosition)
		{
			var isFirst = currUnitPosition == 0;
			if (isFirst)
				return null;
			var targetArmy = currUnit.IsFriendly ? army : enemyArmy;
			var range = currUnit.Range;
			var startIndex = currUnitPosition - range;
			var endIndex = currUnitPosition + range;
			if(currUnit.IsFriendly)
			{
				if (startIndex < 0)
					startIndex = 0;
				if (endIndex > targetArmy.Units.Count - 1)
					endIndex = targetArmy.Units.Count - 1;
			}
			else
			{
				int tmp = startIndex;
				startIndex = 0;
				if (tmp >= 0)
					return null;
				else
					endIndex = Math.Abs(tmp);
				if (endIndex > targetArmy.Units.Count - 1)
					endIndex = targetArmy.Units.Count - 1;
			}
			var count = endIndex - startIndex + 1;

			if (count == 0)
			{
				return null;
			}

			return Enumerable.Range(startIndex, count);
		}
	}
}
