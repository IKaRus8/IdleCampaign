using Data.Enums;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.StateEnemy
{
	public class EnemySquadChaseState : EnemySquadBaseState
	{
		public EnemySquadChaseState() : base(GameState.Chase)
		{
		}

		public override void RunCurrentState()
		{

		}
	}
}
