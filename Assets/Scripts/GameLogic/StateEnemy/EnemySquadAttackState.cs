using Data.Enums;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.StateEnemy
{
	public class EnemySquadAttackState : EnemySquadBaseState
	{
		public EnemySquadAttackState() : base(GameState.Attack)
		{
		}

		public override void RunCurrentState()
		{

		}
	}
}
