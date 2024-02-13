using Data.Enums;
using GameInfoModels.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameLogic.StateEnemy
{
	public class EnemySquadChaseState : EnemySquadBaseState
	{
		private IEnemySquadsProvider _enemySquadsProvider;
		private Vector3 _vectorMoveForward = Vector3.forward * 10f;
		public EnemySquadChaseState(IEnemySquadsProvider enemySquadsProvider) : base(GameState.Chase)
		{
			_enemySquadsProvider = enemySquadsProvider;
		}

		public override void RunCurrentState()
		{
			foreach(var enemy in _enemySquadsProvider.EnemySquads[0].Enemies)
			{
				var unitNavMesh = enemy.Agent;
				if (unitNavMesh.destination != Vector3.zero)
					if (unitNavMesh.SetDestination(enemy.EnemyPosition + _vectorMoveForward))
					{
						unitNavMesh.isStopped = false;
					}


			}
		}
	}
}
