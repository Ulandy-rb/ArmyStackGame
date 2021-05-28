using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Units
{
	public interface IUnit
	{
		#region
		int Health { get; set; }
		int Attack { get; }
		int Defense { get; }
		int MaxHealth { get; }
		bool IsDamage { get; }
		bool IsAlive { get; }
		#endregion

		#region Методы
		public void TakeDamage(int damage)
		{
		}
		#endregion
	}
}
