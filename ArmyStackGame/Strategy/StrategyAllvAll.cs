﻿using ArmyStackGame.SpecialAction;
using ArmyStackGame.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Strategy
{
	public class StrategyAllvAll : IStrategy
	{
		public List<int> GetIndexOpponents(IArmy firstarmy, IArmy secondArmy)
		{
			var indexList = new List<int>();
			var min = Math.Min(firstarmy.Units.Count, secondArmy.Units.Count);
			for (int i = 0; i < min; i++)
			{
				indexList.Add(i);
			}
			return indexList;
		}

		public IEnumerable<int> GetPosiblePositionsForActions(IArmy army, IArmy enemyArmy, ISpecialAction currUnit, int currUnitPosition)
		{
			var min = Math.Min(army.Units.Count, enemyArmy.Units.Count);

			var isFirst = currUnitPosition < min;
			if (isFirst)
				return null;

			var targetArmy = currUnit.IsFriendly ? army : enemyArmy;
			var range = currUnit.Range;

			var newCurrUnitPosition = currUnitPosition - min + 1;
			int startIndex, endIndex;

			if (currUnit.IsFriendly)
			{
				startIndex = newCurrUnitPosition - range;
				endIndex = newCurrUnitPosition + range;

				if (startIndex < 0)
					startIndex = 0;
			}
			else
			{
				startIndex = 0;
				endIndex = newCurrUnitPosition - range + 1;
				if (endIndex >= 0)
					return null;
				endIndex = Math.Abs(endIndex);
			}

			var indexes = GetRangeIndexes(targetArmy, startIndex, endIndex, min);

			if (indexes == null)
			{
				return null;
			}
			return indexes;
		}

		private List<int> GetRangeIndexes(IArmy targetArmy, int startIndex, int endIndex, int min)
		{
			var indexes = new List<int>();
			if (startIndex == 0)
			{
				for (int i = 0; i < min; i++)
				{
					indexes.Add(i);
				}
				startIndex++;
			}
			startIndex = startIndex + min - 1;
			endIndex = endIndex + min;
			if (endIndex > targetArmy.Units.Count - 1)
				endIndex = targetArmy.Units.Count - 1;

			for (int i = startIndex; i <= endIndex; i++)
			{
				indexes.Add(i);
			}
			return indexes;
		}
	}
}
