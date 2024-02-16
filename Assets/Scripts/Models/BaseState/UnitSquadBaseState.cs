using Data.Enums;

namespace Models
{
    public abstract class UnitSquadBaseState
    {
        public GameState GameState { get; }
        public UnitSquadBaseState( GameState state)
        {
            GameState = state;
        }

        public abstract void RunCurrentState();
    }
}
