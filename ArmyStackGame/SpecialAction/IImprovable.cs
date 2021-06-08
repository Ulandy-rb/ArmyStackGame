using ArmyStackGame.Units;
using ArmyStackGame.Units.ImproveDecorator;
using ArmyStackGame.Units.ImproveDecorator.Improvements;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.SpecialAction
{
	interface IImprovable
	{
		#region Свойства

		/// <summary>
		/// Количество улучшений
		/// </summary>
		int ImprovementsCount { get; set; }

		#endregion

		#region Методы

		/// <summary>
		/// Можно ли улучшить
		/// </summary>
		bool CanImprove(Type type);

		#endregion
	}
}
