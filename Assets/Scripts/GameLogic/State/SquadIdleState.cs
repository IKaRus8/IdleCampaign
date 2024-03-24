using Data.Enums;
using Models;

namespace GameLogic.State
{
	public class SquadIdleState : SquadUnitBaseState
	{
		public SquadIdleState() : base(GameState.Idle)
		{

		}
		public override void RunCurrentState()
		{
		}
	}
}
