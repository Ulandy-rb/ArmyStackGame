using ArmyStackGame.Improvements;
using ArmyStackGame.SpecialAction;
using ArmyStackGame.Units.ImproveDecorator.Improvements;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Units.ImproveDecorator
{
	abstract class ImproveDecorator<T>: IImprover where T: Unit, IImprovable, IUnit
	{
		int ImprovementsCount => ((IImprovable)Unit).ImprovementsCount + 1;

		
		public bool CanImprove(Type type)
		{
			if(GetType().GetGenericTypeDefinition() == type)
			{
				return false;
			}
			return ((IImprovable)Unit).CanImprove(type);
		}

		public IUnit Unit { get; protected set; }
		public int Health { get; set; }
		public virtual int Attack { get; }
		public virtual int Defense { get; }
		public int MaxHealth { get; }
		public bool IsDamage => Health < MaxHealth;
		public bool IsAlive { get; set; } = true;
		protected ImproveDecorator(T unit)
		{
			this.Unit = unit;
			Health = ((IUnit)unit).Health;
			Attack = ((IUnit)unit).Attack;
			Defense = ((IUnit)unit).Defense;
			MaxHealth = ((IUnit)unit).MaxHealth;
		}

	}
}
