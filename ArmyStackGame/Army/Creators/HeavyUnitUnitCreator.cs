using ArmyStackGame.Configs;
using ArmyStackGame.Units;

namespace ArmyStackGame.Army
{
	internal class HeavyUnitUnitCreator : IUnitCreator
	{
		public IUnit Create()
		{
			var healer = UnitConfig.Units[UnitType.HeavyUnit];
			return new HeavyUnit(healer.Health, healer.Defense, healer.Attack);
		}
	}
}