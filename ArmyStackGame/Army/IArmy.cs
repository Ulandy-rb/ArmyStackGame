using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Units
{
	public interface IArmy 
	{
		List<IUnit> Units { get; set; }
	}
}
