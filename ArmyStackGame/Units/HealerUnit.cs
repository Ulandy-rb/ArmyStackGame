using System;
using System.Collections.Generic;
using System.Text;
using ArmyStackGame.SpecialAction;

namespace ArmyStackGame.Units
{
	class HealerUnit : Unit, IHealable, ISpecialAction
	{
		public HealerUnit(int maxhealth, int defense, int attack) : base(maxhealth, defense, attack)
		{

		}

        public void DoSpecialAction()
        {
            throw new NotImplementedException();
        }

        public void Heal()
        {
            throw new NotImplementedException();
        }
    }
}
