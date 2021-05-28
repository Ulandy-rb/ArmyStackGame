using ArmyStackGame.Configs;
using ArmyStackGame.Units;

namespace ArmyStackGame.Army
{
	internal class TumbleweedUnitCreator : IUnitCreator
	{
		public IUnit Create()
		{
			var healer = UnitConfig.Units[UnitType.TumbleweedUnit];
			return new TumbleweedUnit(healer.Health, healer.Defense, healer.Attack);
		}
	}
}