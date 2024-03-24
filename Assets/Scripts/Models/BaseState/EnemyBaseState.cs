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
		public virtual void EnterState() { }
		public abstract void RunState(IEnemy enemy);
		public virtual void ExitState() { }

	}
}
