using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Units
{
	public class Unit : IUnit
	{
		#region Свойства
		public virtual int Health { get; set; }
		public virtual int Attack { get; set; }
		public virtual int Defense { get; set; }
		public virtual int MaxHealth { get; set; }
		public virtual bool IsDamage => Health < MaxHealth;
		public virtual bool IsAlive => Health > 0;
		#endregion

		#region Инициализация 
		public Unit(int maxhealth, int defense, int attack)
		{
			Health = MaxHealth = maxhealth;
			Attack = attack;
			Defense = defense;
			Attack = attack;
		}
		#endregion

		#region Методы
		public void TakeDamage(int damage)
		{
			Health -= damage;
		}

		public override string ToString()
		{
			return $"Health - {Health}, Attack - {Attack}, Defense - {Defense}";
		}
		#endregion
	}
}
