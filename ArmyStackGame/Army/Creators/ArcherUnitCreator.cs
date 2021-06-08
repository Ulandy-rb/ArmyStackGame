using ArmyStackGame.Configs;
using ArmyStackGame.Units;

namespace ArmyStackGame.Army
{
	internal class ArcherUnitCreator : IUnitCreator
	{
		public IUnit Create()
		{
			var healer = UnitConfig.Units[UnitType.ArcherUnit];
			return new ArcherUnit(healer.Health, healer.Defense, healer.Attack, healer.Chance, healer.Range, healer.Power);
		}
	}
}