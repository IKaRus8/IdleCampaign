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
	internal class EnemyWalkState : EnemyBaseState
	{
		public EnemyWalkState() : base(GameState.Walk)
		{
		}

		public override void RunCurrentState(IEnemy enemy)
		{
			throw new NotImplementedException();
		}

	}
}
