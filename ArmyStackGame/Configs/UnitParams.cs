using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Configs
{
	public struct UnitParams
	{
		/// <summary>
		///  Здоровье
		/// </summary>
		public int Health;
		/// <summary>
		/// Сила аттаки 
		/// </summary>
		public int Attack;
		/// <summary>
		/// Защита
		/// </summary>
		public int Defense;
		/// <summary>
		/// Стоимость
		/// </summary>
		public int Cost;
		/// <summary>
		/// Шанс выполнения спецдействия
		/// </summary>
		public int Chance;
		/// <summary>
		/// Дальность взаимодействия спец возвожности, измеряется в юнитах
		/// </summary>
		public int Range;
		/// <summary>
		/// Сила действия спец возможности
		/// </summary>
		public int Power;
	}
}
