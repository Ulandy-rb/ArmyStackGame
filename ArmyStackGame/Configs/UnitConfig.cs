using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Configs
{
	public class UnitConfig
	{
		public static Dictionary<UnitType, UnitParams> Units { get; } = new Dictionary<UnitType, UnitParams>()
		{
			{
				UnitType.LightUnit, new UnitParams
				{
					Health = 100,
					Attack = 30,
					Defense = 30,
					Cost = 25

				}
			},
			{
				UnitType.HeavyUnit, new UnitParams
				{
					Health = 100,
					Attack = 70,
					Defense = 70,
					Cost = 75

				}
			},
			{
				UnitType.ArcherUnit, new UnitParams
				{
					Health = 100,
					Attack = 40,
					Defense = 30,
					Cost = 50

				}
			},
			{
				UnitType.HealerUnit, new UnitParams
				{
					Health = 100,
					Attack = 15,
					Defense = 15,
					Cost = 75
				}
			},
			{
				UnitType.MagicUnit, new UnitParams
				{
					Health = 100,
					Attack = 50,
					Defense = 50,
					Cost = 75

				}
			},
			{
				UnitType.TumbleweedUnit, new UnitParams
				{
					Health = 100,
					Attack = 0,
					Defense = 90,
					Cost = 100

				}
			}

		};
	}	
}
