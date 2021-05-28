using ArmyStackGame.Units;
using System.Collections.Generic;

namespace ArmyStackGame.Army
{
	public interface IUnitFactory
	{
		List<IUnit> CreateArmy(int cost);
	}
}