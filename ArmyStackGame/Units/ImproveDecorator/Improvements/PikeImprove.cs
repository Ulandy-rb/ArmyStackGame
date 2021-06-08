using ArmyStackGame.Configs;
using ArmyStackGame.SpecialAction;
using ArmyStackGame.Units;
using ArmyStackGame.Units.ImproveDecorator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Improvements
{
	class PikeImprove<T> : ImproveDecorator<T> where T : Unit, IImprovable, IUnit
	{
		private int currAttack;
		public override int Attack => base.Attack + currAttack;
		public PikeImprove(T unit) : base(unit)
		{
			var config = UnitConfig.Improves[ImproveTypes.Pike];
			currAttack = config.Attack;
		}
	}
}
