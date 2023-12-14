using Data.Enums;
using GameLogic.Interfaces;
using Models;
using Models.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace GameInfoModels
{
    public class SquadUnitsProvider : ISquadUnitsProvider
    {
        public List<IUnit> Units { get; set; } = new List<IUnit>();
        public void AddUnit(IUnit unit)
        {
            Units.Add(unit);
        }
        public void AddUnit(GameObject unit)
        {
            Unit newUnit = new(unit);
            Units.Add(newUnit);
        }
        public void RemoveDeadUnits()
        {
            Units.RemoveAll(u => u.IsDead == true);
        }
        public void ResetUnitPosition()
        {
            foreach (var unit in Units)
            {
                unit.UnitObject.transform.localPosition = Vector3.zero;
                unit.UnitObject.transform.localRotation = Quaternion.identity;
                unit.Agent.isStopped = true;
                unit.UnitState = GameState.Idle;
            }
        }
    }
}
