﻿using Models.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Interfaces
{
    public interface ISquadUnitsProvider
    {
        List<IUnit> Units { get; set; }
        void AddUnit(IUnit unit);
        void AddUnit(GameObject unit);
        void RemoveUnit(IUnit unit);
    }
}
