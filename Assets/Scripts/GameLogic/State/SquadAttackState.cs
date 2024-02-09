﻿using Data.Enums;
using GameInfoModels.Interfaces;
using GameLogic.Interfaces;
using Models;
using UnityEngine;

namespace GameLogic.State
{
    public class SquadAttackState : BaseState
    {
        private readonly ISquadUnitsProvider _squadUnitsProvider;
        private readonly UnitStateManager _unitStateManager;
        public SquadAttackState(IEnemySquadsProvider enemySquadsProvider, ISquadUnitsProvider squadUnitsProvider, float unitAttackRadius, float chaseRadius) : base(GameState.Attack)
        {
            _squadUnitsProvider = squadUnitsProvider;
            _unitStateManager = new UnitStateManager(unitAttackRadius, chaseRadius, enemySquadsProvider);
        }
        public override void RunCurrentState()
        {
            foreach (var unit in _squadUnitsProvider.Units)
            {
                _unitStateManager.UnitState(unit);
            }
        }

    }
}
