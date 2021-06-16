﻿using ArmyStackGame.Units;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Army
{
	class Army : IArmy
	{
		public List<IUnit> Units { get; set; }
		public string Name { get; set; }
		public bool IsAllDead => Units.Count == 0;

		public Army(string name, int cost, IUnitFactory factory)
		{
			Name = name;
			Units = factory.CreateArmy(cost);
		}

		public override string ToString()
		{
			string army = $"Армия\n";
			if (Units.Count == 0)
			{
				army += "Пусто" + "\n";
			}
			else
			{
				foreach (var unit in Units)
				{
					army += unit.ToString() + "\n";
				}
			}

			return army;
		}

	}
}
