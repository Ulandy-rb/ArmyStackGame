using ArmyStackGame.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Strategy
{
	class Opponents
	{
		public IArmy army { get; }
		public IArmy enemyArmy { get; }
		public int position { get; }
		public int enemyPosition { get; }

		public Opponents(IArmy army, IArmy enemyArmy, int position, int enemyPosition)
		{
			this.army = army;
			this.enemyArmy = enemyArmy;
			this.position = position;
			this.enemyPosition = enemyPosition;
		}
	}
}
