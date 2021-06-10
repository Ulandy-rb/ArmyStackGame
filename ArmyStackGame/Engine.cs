using ArmyStackGame.Army;
using ArmyStackGame.Commands;
using ArmyStackGame.Logger;
using ArmyStackGame.SpecialAction;
using ArmyStackGame.Strategy;
using ArmyStackGame.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame
{
	public class Engine
	{
        /// <summary>
        /// Стратегия боя
        /// </summary>
        public IStrategy Strategy;

        /// <summary>
        /// Менеджер команд
        /// </summary>
        public UndoRedoManager CommandManager;

        /// <summary>
        /// Закончена ли игра
        /// </summary>
        public bool IsGameEnded => FirstArmy.IsAllDead || SecondArmy.IsAllDead;

        /// <summary>
        /// Победила ли первая армия
        /// </summary>
        public bool IsFirstArmyWin => IsGameEnded && SecondArmy.IsAllDead;
        /// <summary>
        /// Победила ли вторая армия
        /// </summary>
        public bool IsSecondArmyWin => IsGameEnded && FirstArmy.IsAllDead;
        /// <summary>
        /// Экземпляр класса
        /// </summary>
        private static Engine instance;

        /// <summary>
        /// Первая армия
        /// </summary>
        public IArmy FirstArmy { get; private set; }
        /// <summary>
        /// Вторая армия
        /// </summary>
        public IArmy SecondArmy { get; private set; }


		/// <summary>
		/// Получить экземпляр класса
		/// </summary>
		private Engine()
		{
            ILogger logger = new ConsoleLogger();
            CommandManager = new UndoRedoManager(logger);
		}
        public static Engine GetInstance()
        {
            if (instance == null)
            {
                instance = new Engine();
            }

            return instance;
        }

        public void NewGame(int cost, IStrategy strategy)
		{
            this.Strategy = strategy;
            // Создание армий
            var factory = new RandomFactory();

            FirstArmy = new Army.Army(cost, factory);
            SecondArmy = new Army.Army(cost, factory);
        }

        /// <summary>
        /// Следующий ход
        /// </summary>
        public void NextStep()
        {
            if (IsGameEnded)
                return;
            HandToHandAttck();
            CollectDeadUnits();
            SpecialAttack(FirstArmy, SecondArmy);
            SpecialAttack(SecondArmy, FirstArmy);
			CollectDeadUnits();

            CommandManager.EndTurn();
        }

        public void ChangeStrategy(IStrategy newstrategy)
		{
            if (Strategy.GetType() != newstrategy.GetType())
            {
                ICommand command = new ChangeStrategyCommand(Strategy, newstrategy);
                CommandManager.RunCommand(command);

                CommandManager.EndTurn();
            }
        }

        public void PlayToEnd()
		{
            while(true)
			{
                if (IsGameEnded)
                    return;
                NextStep();
			}
		}
		private void CollectDeadUnits()
		{
            var command = new DeleteDeathUnitsCommand(FirstArmy);
            CommandManager.RunCommand(command);
            command = new DeleteDeathUnitsCommand(SecondArmy);
            CommandManager.RunCommand(command);
		}

		private void SpecialAttack(IArmy army, IArmy enemyArmy)
		{
			for (int i = 0; i < army.Units.Count; i++)
			{
                var unit = army.Units[i];
                if (unit is ISpecialAction specialUnit)
                {
                    var range = Strategy.GetPosiblePositionsForActions(army, enemyArmy, specialUnit, i);
                    if (specialUnit.IsFriendly)
                        specialUnit.DoSpecialAction(army, i, range);
                    else
                        specialUnit.DoSpecialAction(enemyArmy, i, range);
                }
            }

		}

        private void HandToHandAttck()
        {
            var opponents = Strategy.GetIndexOpponents(FirstArmy, SecondArmy);
            List<Tuple<IUnit, IUnit>> opponentsList = GetOpponents(opponents);
			for (int i = 0; i < opponentsList.Count; i++)
			{
                var item = opponentsList[i];
                var unit = item.Item1;
                var enemyUnit = item.Item2;
                if (unit.IsAlive && unit.Attack > 0 && enemyUnit.IsAlive)
                {
                    ICommand command = new HitCommand(unit, enemyUnit, unit.Attack);
                    CommandManager.RunCommand(command);

                    if (enemyUnit.IsAlive && enemyUnit is IImprovable improvableUnit && improvableUnit.ImprovementsCount > 0)
                    {
                        if (new Random().Next(1) == 1)
                        {
                            command = new DeleteImprovmentCommand(unit, improvableUnit, FirstArmy, i);
                            CommandManager.RunCommand(command);
                        }
                    }
                }
            }
        }
		private List<Tuple<IUnit, IUnit>> GetOpponents(List<int> indexes)
		{
            List<Tuple<IUnit, IUnit>> opponentsList = new List<Tuple<IUnit, IUnit>>();
            foreach (var index in indexes)
            {
                opponentsList.Add(new Tuple<IUnit, IUnit>(FirstArmy.Units[index], SecondArmy.Units[index]));
                opponentsList.Add(new Tuple<IUnit, IUnit>(SecondArmy.Units[index], FirstArmy.Units[index]));
            }
            return opponentsList;
		}
	}
}
