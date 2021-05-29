using System;
using System.Collections.Generic;
using System.Text;
using ArmyStackGame.SpecialAction;

namespace ArmyStackGame.Units
{
	class ArcherUnit : Unit, IHealable, ISpecialAction, IClonable
	{
		public ArcherUnit(int maxhealth, int defense, int attack) : base(maxhealth, defense, attack)
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
