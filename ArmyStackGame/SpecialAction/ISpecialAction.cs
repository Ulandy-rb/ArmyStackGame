using ArmyStackGame.Units;
using System;
using System.Collections.Generic;

namespace ArmyStackGame.SpecialAction
{
    /// <summary>
    /// Интерфейс спец действия
    /// </summary>
    interface ISpecialAction
    {
        int Chance { get; }
        int Range { get; }
        int Power { get; }

        bool IsFriendly { get; }
        void DoSpecialAction(IArmy targetArmy, int position, IEnumerable<int> targetRange);
	}
}
