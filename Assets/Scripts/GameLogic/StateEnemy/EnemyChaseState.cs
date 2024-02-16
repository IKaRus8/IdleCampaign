using Data.Enums;
using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.StateEnemy
{
	internal class EnemyChaseState : EnemyBaseState
	{
		private float _attackRadius;
		public EnemyChaseState(float attackRadius) : base(GameState.Chase)
		{
			_attackRadius = attackRadius;
		}

		public override void RunCurrentState(IEnemy enemy)
		{
			throw new NotImplementedException();
		}

	}
}
