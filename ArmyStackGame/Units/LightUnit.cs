using System;
using System.Collections.Generic;
using System.Text;
using ArmyStackGame.SpecialAction;

namespace ArmyStackGame.Units
{
	class LightUnit : Unit, IClonable, IHealable, ISpecialAction
	{
		public LightUnit(int maxhealth, int defense, int attack) : base (maxhealth, defense, attack)
		{

		}

        public IUnit Clone()
        {
            throw new NotImplementedException();
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
