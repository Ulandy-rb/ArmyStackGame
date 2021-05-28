using ArmyStackGame.Configs;
using ArmyStackGame.Units;

namespace ArmyStackGame.Army
{
	internal class MagicUnitCreator : IUnitCreator
	{
		public IUnit Create()
		{
			var healer = UnitConfig.Units[UnitType.MagicUnit];
			return new MagicUnit(healer.Health, healer.Defense, healer.Attack);
		}
	}
}