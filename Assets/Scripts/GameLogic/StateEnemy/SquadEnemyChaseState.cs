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
	public class SquadEnemyChaseState : SquadEnemyBaseState
	{
		private IEnemySquadsProvider _enemySquadsProvider;

		private float _velocity = 10f;
		public SquadEnemyChaseState(IEnemySquadsProvider enemySquadsProvider) : base(GameState.Chase)
		{
			_enemySquadsProvider = enemySquadsProvider;
		}

		public override void RunState()
		{
			foreach(var enemy in _enemySquadsProvider.EnemySquads[0].Enemies)
			{
				var rb = enemy.Rigidbody;
				rb.velocity = Vector3.back * _velocity;
			}
		}

	}
}
