using ArmyStackGame.Improvements;
using ArmyStackGame.SpecialAction;
using ArmyStackGame.Units.ImproveDecorator.Improvements;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Units.ImproveDecorator
{
	abstract class ImproveDecorator<T>: IImprover, IUnit where T: IImprovable, IUnit
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
		public int Health
		{
			get => Unit.Health;
			set => Unit.Health = value;
		}
		public virtual int Attack => Unit.Attack;
		public virtual int Defense => Unit.Defense;
		public int MaxHealth => Unit.MaxHealth;
		public bool IsDamage => Unit.IsDamage;
		public bool IsAlive => Unit.IsAlive;
		public int Id => Unit.Id;

		protected ImproveDecorator(T unit)
		{
			this.Unit = unit;
		}
		public override string ToString()
		{
			return Unit.ToString();
		}
	}
}
