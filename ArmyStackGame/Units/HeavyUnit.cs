using System;
using System.Collections.Generic;
using System.Text;
using ArmyStackGame.SpecialAction;

namespace ArmyStackGame.Units
{
	class HeavyUnit : Unit, IHealable
	{
		public HeavyUnit(int maxhealth, int defense,  int attack) : base(maxhealth, defense, attack)
		{

		}

        public void Heal()
        {
            throw new NotImplementedException();
        }
    }
}
