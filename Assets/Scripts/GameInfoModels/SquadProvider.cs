using GameLogic.Interfaces;
using Models;
using Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameInfoModels
{
    public class SquadProvider : ISquadProvider
    {
        public List<IUnit> Units { get; set; } = new List<IUnit>();
        public void AddUnit(IUnit unit)
        {
            Units.Add(unit);
        }
        public void AddUnit(GameObject unit)
        {
            Unit player = new(unit);
            Units.Add(player);
        }
        public void RemoveUnit(IUnit unit)
        {
            Units.Remove(unit);
        }
    }
}
