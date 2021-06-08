using ArmyStackGame.Configs;
using ArmyStackGame.SpecialAction;
using ArmyStackGame.Units;
using ArmyStackGame.Units.ImproveDecorator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Improvements
{
	class HorseImprove<T> : ImproveDecorator<T> where T : Unit, IImprovable, IUnit
	{
		private int currDefense;
		private int currAttack;
		public override int Defense => base.Defense + currDefense;
		public override int Attack => base.Attack + currAttack;

		public HorseImprove(T unit) : base(unit)
		{
			var config = UnitConfig.Improves[ImproveTypes.Horse];
			currDefense = config.Defence;
			currAttack = config.Attack;
		}
	}
}
