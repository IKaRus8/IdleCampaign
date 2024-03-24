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
	internal class EnemyIdleState : EnemyBaseState
	{
		public EnemyIdleState() : base(GameState.Idle)
		{
		}

		public override void RunState(IEnemy enemy)
		{
		}
	}
}
