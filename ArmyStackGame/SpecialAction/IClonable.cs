using System;
using ArmyStackGame.Units;

namespace ArmyStackGame.SpecialAction
{
    /// <summary>
    /// Интерфейс клонирования
    /// </summary>
    public interface IClonable
    {
        public IClonable Clone();
    }
}
