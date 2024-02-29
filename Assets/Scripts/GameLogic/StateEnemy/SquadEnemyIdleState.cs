using Data.Enums;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.StateEnemy
{
	public class SquadEnemyIdleState : SquadEnemyBaseState
	{
		public SquadEnemyIdleState() : base(GameState.Idle)
		{
		}

		public override void RunState()
		{

		}
	}
}
