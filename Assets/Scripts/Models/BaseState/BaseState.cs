using Data.Enums;

namespace Models
{
    public abstract class BaseState
    {
        public GameState GameState { get; }
        public BaseState( GameState state)
        {
            GameState = state;
        }

        public abstract void RunCurrentState();
    }
}
