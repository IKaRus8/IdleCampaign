namespace UI.Interfaces
{
    public interface IScreenManager
    {
        void Show<T>() where T : IBaseScreen;

        void HideAll();
    }
}