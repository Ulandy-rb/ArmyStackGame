using System;
using System.Collections.Generic;
using System.Text;
using ArmyStackGame.SpecialAction;
using ArmyStackGame.Units.ImproveDecorator.Improvements;

namespace ArmyStackGame.Units
{
	class HeavyUnit : Unit, IHealable, IImprovable
	{
		public HeavyUnit(int maxhealth, int defense,  int attack) : base(maxhealth, defense, attack)
		{

		}

		//public int ImprovementsCount => 0;

		public int ImprovementsCount { get; set; } = 0;

		public bool CanImprove(Type type)
		{
			return true;
		}

		public void Heal(int healPower)
		{
			Health += healPower;
		}

		public override string ToString()
		{
			return $"Heavy Unit: {base.ToString()}";
		}
	}
}
