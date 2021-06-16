using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Units
{
	public interface IUnit
	{
		int Health { get; set; }
		int Attack { get; }
		int Defense { get; }
		int MaxHealth { get; }
		bool IsDamage { get; }
		bool IsAlive { get; }
		int Id { get; }
		public void TakeDamage(int damage)
		{
		}

		public string ToString();
	}
}
