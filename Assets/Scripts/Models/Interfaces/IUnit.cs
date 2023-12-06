﻿using Data.Enums;
using UnityEngine;
using UnityEngine.AI;

namespace Models.Interfaces
{
    public interface IUnit
    {
        IEnemy TargetToPursue { get; set; }
        GameState UnitState { get; set; }
        GameObject UnitObject { get; set; }
        NavMeshAgent Agent { get; }
        Vector3 UnitPosition { get; }
        float MaxHealth { get; }
        float Attack { get; }
    }
}