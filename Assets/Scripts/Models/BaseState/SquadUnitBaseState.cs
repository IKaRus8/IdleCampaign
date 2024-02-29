using Data.Enums;

namespace Models
{
    public abstract class SquadUnitBaseState
    {
        public GameState GameState { get; }
        public SquadUnitBaseState( GameState state)
        {
            GameState = state;
        }

        public abstract void RunCurrentState();
    }
}
