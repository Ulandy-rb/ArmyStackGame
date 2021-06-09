using ArmyStackGame.Logger;
using ArmyStackGame.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Commands
{
	class ChangeStrategyCommand :ICommand
	{

		/// <summary>
		/// Исходная стратегия
		/// </summary>
		private readonly IStrategy sourceStrategy;
		/// <summary>
		/// Стратегия
		/// </summary>
		private readonly IStrategy strategy;

		#region Инициализация

		public ChangeStrategyCommand(IStrategy sourceStrategy, IStrategy strategy)
		{
			this.sourceStrategy = sourceStrategy;
			this.strategy = strategy;
		}

		#endregion

		#region Методы

		public void Run(ILogger logger)
		{
			Engine.GetInstance().Strategy = strategy;
			logger.Log("Strategy changed");
		}

		public void Undo(ILogger logger)
		{
			Engine.GetInstance().Strategy = sourceStrategy;
		}

		#endregion
	}
}
