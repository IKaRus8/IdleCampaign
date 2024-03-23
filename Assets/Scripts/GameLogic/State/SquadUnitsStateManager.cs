using Data.Enums;
using GameInfoModels.Interfaces;
using GameLogic.Interfaces;
using Models;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameLogic.State
{
	public class SquadUnitsStateManager : ISquadUnitsStateManager
	{
		private readonly ISquadUnitsProvider _squadUnitsProvider;
		private readonly IEnemySquadsProvider _enemySquadsProvider;
		private readonly IUnitOptions _unitOptions;

		private SquadUnitBaseState _currentState;

		private Dictionary<GameState, SquadUnitBaseState> _allStates;

		public SquadUnitsStateManager(IUnitOptions unitOptions, IEnemySquadsProvider enemySquadsProvider, ISquadUnitsProvider squadUnitsProvider)
		{
			_enemySquadsProvider = enemySquadsProvider;
			_squadUnitsProvider = squadUnitsProvider;
			_unitOptions = unitOptions;

			_allStates = new Dictionary<GameState, SquadUnitBaseState>()
			{
				{ GameState.Idle, new SquadIdleState() },
				{ GameState.Walk, new SquadWalkState(unitOptions.Velocity,unitOptions.SquadRigidbody) },
				{ GameState.Chase, new SquadChaseState(unitOptions.Velocity,unitOptions.SquadRigidbody) },
				{ GameState.Attack, new SquadAttackState(enemySquadsProvider,squadUnitsProvider,unitOptions.UnitAttackRadius,unitOptions.SquadAttackRadius) }
			};

			_currentState = _allStates[GameState.Walk];
		}
		public void RunState()
		{
			CheckEnemy();
			_currentState.RunCurrentState();
		}
		private void CheckEnemy()
		{
			if (_squadUnitsProvider.Units.Count == 0)
			{
				SwitchState(GameState.Idle);
				return;

			}
			if (_enemySquadsProvider.EnemySquads.Count() == 0)
			{
				SwitchState(GameState.Walk);
				return;
			}
			var nearestEnemy = _enemySquadsProvider.EnemySquads[0].NearestEnemyToUnitZAxis;
			var nearestUnit = _squadUnitsProvider.NearestUnitToEnemyZAxis;
			if (nearestUnit == null)
			{
				SwitchState(GameState.Idle);
				return;
			}
			if (nearestEnemy == null)
			{
				SwitchState(GameState.Walk);
				return;
			}
			var enemyContainerPosition = nearestEnemy.EnemyPosition;
			var unitContainerPosition = nearestUnit.UnitPosition;

			var distance = Vector3.Distance(enemyContainerPosition, unitContainerPosition);

			switch (_currentState.GameState)
			{
				case GameState.Walk:
					CheckEnemyForWalkState(distance);
					break;
				case GameState.Chase:
					CheckEnemyForChaseState(distance);
					break;
				case GameState.Attack:
					CheckEnemyForAttackState(distance);
					break;
				default:
					break;
			}
		}
		private void CheckEnemyForWalkState(float distance)
		{
			if (distance > _unitOptions.SquadChaseRadius)
			{
				return;
			}
			SwitchState(GameState.Chase);
		}
		private void CheckEnemyForChaseState(float distance)
		{
			if (distance < _unitOptions.SquadAttackRadius)
			{
				SwitchState(GameState.Attack);
				return;
			}
			if (distance < _unitOptions.SquadChaseRadius)
			{
				return;
			}
			SwitchState(GameState.Walk);
		}
		private void CheckEnemyForAttackState(float distance)
		{
			if (distance < _unitOptions.SquadAttackRadius)
			{
				return;
			}
			SwitchState(GameState.Walk);
		}
		public void SwitchState(GameState gameState)
		{
			if (_currentState.GameState != gameState)
			{
				_currentState = _allStates[gameState];
				ChangePlayerBehaviour();
			}
		}
		private void ChangePlayerBehaviour()
		{
			switch (_currentState.GameState)
			{
				case GameState.Walk:
					ChangeStateInWalk();
					break;
				case GameState.Attack:
					ChangeStateInAttack();
					break;
				default:
					break;
			}
		}
		private void ChangeStateInWalk()
		{
			_squadUnitsProvider.RemoveDeadUnits();
			_squadUnitsProvider.ResetUnitsPosition();
		}
		private void ChangeStateInAttack()
		{
			_unitOptions.SquadRigidbody.velocity = Vector3.forward;
		}
	}
}
