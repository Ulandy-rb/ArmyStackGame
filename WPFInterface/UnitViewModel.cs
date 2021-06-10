using ArmyStackGame;
using ArmyStackGame.Strategy;
using ArmyStackGame.Units;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPFInterface
{
	class UnitViewModel
	{
		public ImageSource ImageFirst { get; }
		public string ImageSpecialAction { get; }
		IUnit Unit { get; }
		public UnitViewModel(IUnit unit)
		{
			ImageSpecialAction = "gfdgfd";
			this.Unit = unit;
			//if (Unit.GetType() == typeof(MagicUnit))
			//{
				ImageFirst = new BitmapImage( new Uri("C:\\Users\\outarova\\source\\repos\\ArmyStackGame\\WPFInterface\\Recources\\mag.png"));
			//}
			//if (Unit.GetType() == typeof(MagicUnit))
			//{
			//	ImageFirst = new BitmapImage(new Uri("C:\\Users\\outarova\\source\\repos\\ArmyStackGame\\WPFInterface\\Recourses\\mag.png"));
			//}
			//if (Unit.GetType() == typeof(MagicUnit))
			//{
			//	ImageFirst = new BitmapImage(new Uri("C:\\Users\\outarova\\source\\repos\\ArmyStackGame\\WPFInterface\\Recourses\\mag.png"));
			//}
			//if (Unit.GetType() == typeof(MagicUnit))
			//{
			//	ImageFirst = new BitmapImage(new Uri("C:\\Users\\outarova\\source\\repos\\ArmyStackGame\\WPFInterface\\Recourses\\mag.png"));
			//}
			//if (Unit.GetType() == typeof(MagicUnit))
			//{
			//	ImageFirst = new BitmapImage(new Uri("C:\\Users\\outarova\\source\\repos\\ArmyStackGame\\WPFInterface\\Recourses\\mag.png"));
			//}
			//if (Unit.GetType() == typeof(MagicUnit))
			//{
			//	ImageFirst = new BitmapImage(new Uri("C:\\Users\\outarova\\source\\repos\\ArmyStackGame\\WPFInterface\\Recourses\\mag.png"));
			//}
			//else
			//	ImageFirst = null;
		}
	}
}
