using Data.Enums;
using Models.Interfaces;

namespace Models
{
	public abstract class EnemyBaseState
	{
		public GameState GameState { get; }
		public EnemyBaseState(GameState state)
		{
			GameState = state;
		}
		public abstract void RunCurrentState(IEnemy enemy);

	}
}
