using ArmyStackGame.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Army
{
	class Army : IArmy
	{
		public List<IUnit> Units { get; set; }

		public Army(int cost, IUnitFactory factory)
		{
			Units = factory.CreateArmy(cost);
		}
	}
}
