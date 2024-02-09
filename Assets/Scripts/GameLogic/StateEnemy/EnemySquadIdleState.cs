using Data.Enums;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.StateEnemy
{
	public class EnemySquadIdleState : EnemySquadBaseState
	{
		public EnemySquadIdleState() : base(GameState.Idle)
		{
		}

		public override void RunCurrentState()
		{

		}
	}
}
