using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Units
{
	public class TumbleweedUnit : Unit
	{
		public TumbleweedUnit(int maxhealth, int defense, int attack) : base(maxhealth, defense, attack)
		{
			Id = ++Unit.ID;
		}
		public override string ToString()
		{
			return $"Tumbleweed #{Id}: {base.ToString()}";
		}
	}
}
