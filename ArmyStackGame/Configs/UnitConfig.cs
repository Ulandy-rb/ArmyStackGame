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
					Cost = 25,
					Chance = 75,
					Range = 1,
					Power = 0
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
					Cost = 50,
					Chance = 50,
					Range = 3,
					Power = 70
				}
			},
			{
				UnitType.HealerUnit, new UnitParams
				{
					Health = 100,
					Attack = 15,
					Defense = 15,
					Cost = 75,
					Chance = 75,
					Range = 1,
					Power = 30
				}
			},
			{
				UnitType.MagicUnit, new UnitParams
				{
					Health = 100,
					Attack = 50,
					Defense = 50,
					Cost = 75,
					Chance = 50,
					Range = 1
				}
			},
			{
				UnitType.TumbleweedUnit, new UnitParams
				{
					Health = 400,
					Attack = 0,
					Defense = 90,
					Cost = 100

				}
			}

		};

		public static Dictionary<ImproveTypes, ImproveParams> Improves { get; } = new Dictionary<ImproveTypes, ImproveParams>()
		{
			{
				ImproveTypes.Helmet, new ImproveParams
				{
					Defence = 10
				}
			},
			{
				ImproveTypes.Horse, new ImproveParams
				{
					Defence = 10,
					Attack = 15
				}
			},
			{
				ImproveTypes.Pike, new ImproveParams
				{
					Defence = 15
				}
			},
			{
				ImproveTypes.Shield, new ImproveParams
				{
					Defence = 15
				}
			}

		};
	}	
}
