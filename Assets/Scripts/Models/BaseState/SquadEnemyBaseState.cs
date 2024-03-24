using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public abstract class SquadEnemyBaseState
	{
		public GameState GameState { get; }
		public SquadEnemyBaseState(GameState state)
		{
			GameState = state;
		}

		public virtual void EnterState() { }
		public abstract void RunState();
		public virtual void ExitState() { }

	}
}
