using ArmyStackGame.Configs;
using ArmyStackGame.Units;

namespace ArmyStackGame.Army
{
	internal class LightUnitCreator : IUnitCreator
	{
		public IUnit Create()
		{
			var healer = UnitConfig.Units[UnitType.LightUnit];
			return new LightUnit(healer.Health, healer.Defense, healer.Attack);
		}
	}
}