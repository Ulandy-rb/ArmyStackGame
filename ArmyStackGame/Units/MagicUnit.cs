using System;
using System.Collections.Generic;
using System.Text;
using ArmyStackGame.SpecialAction;

namespace ArmyStackGame.Units
{
	class MagicUnit :Unit, ISpecialAction
	{
		public MagicUnit(int maxhealth, int defense, int attack) : base(maxhealth, defense, attack)
		{

		}

        public void DoSpecialAction()
        {
            throw new NotImplementedException();
        }
    }
}
