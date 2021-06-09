using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Units
{
	class TumbleweedUnit : Unit
	{
		public TumbleweedUnit(int maxhealth, int defense, int attack) : base(maxhealth, defense, attack)
		{

		}
		public override string ToString()
		{
			return $"Tumbleweed: {base.ToString()}";
		}
	}
}
