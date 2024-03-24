using Data.Enums;
using GameInfoModels.Interfaces;
using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameLogic.StateEnemy
{
	internal class EnemyWalkState : EnemyBaseState
	{
		private float _velocity = 10f;

		public EnemyWalkState() : base(GameState.Walk)
		{
		}
		public override void EnterState()
		{

		}
		public override void RunState(IEnemy enemy)
		{
			var rb = enemy.Rigidbody;
			rb.velocity = Vector3.back * _velocity;
		}
		public override void ExitState()
		{

		}

	}
}
