using ArmyStackGame.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Army
{
	interface IUnitCreator
	{
		IUnit Create();
	}
}
