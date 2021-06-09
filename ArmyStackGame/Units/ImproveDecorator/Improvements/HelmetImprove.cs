using ArmyStackGame.Configs;
using ArmyStackGame.SpecialAction;
using ArmyStackGame.Units;
using ArmyStackGame.Units.ImproveDecorator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Improvements
{
	class HelmetImprove<T> : ImproveDecorator<T> where T : Unit, IImprovable, IUnit
	{
		private int currDefense;
		public override int Defense => base.Defense + currDefense;
		public HelmetImprove(T unit) : base(unit)
		{
			var config = UnitConfig.Improves[ImproveTypes.Helmet];
			currDefense = config.Defence;
		}
		public override string ToString()
		{
			return $"{base.ToString()} + Helment: Defense - {currDefense} ";
		}
	}

}
