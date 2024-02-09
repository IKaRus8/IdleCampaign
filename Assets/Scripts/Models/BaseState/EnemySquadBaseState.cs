using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public abstract class EnemySquadBaseState
	{
		public GameState GameState { get; }
		public EnemySquadBaseState(GameState state)
		{
			GameState = state;
		}

		public abstract void RunCurrentState();

	}
}
