using Models.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Interfaces
{
    public interface ISquadUnitsProvider
    {
        List<IUnit> Units { get; set; }
		public Vector3 SquadUnitsPosition { get; }
		void AddUnit(IUnit unit);
        void AddUnit(GameObject unit);
        void RemoveDeadUnits();
        void ResetUnitsPosition();
    }
}
