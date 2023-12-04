using Models.Interfaces;

namespace GameLogic.State.Interfaces
{
    public interface IUnitStateManager
    {
        void RunCurrentStateUnit(IUnit unit);
    }
}
