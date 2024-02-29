using Models.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Interfaces
{
    public interface ISquadUnitsProvider
    {
        List<IUnit> Units { get; set; }
		public IUnit NearestUnit { get; }
		void AddUnit(IUnit unit);
        void AddUnit(GameObject unit);
        void RemoveDeadUnits();
        void ResetUnitsPosition();
    }
}
