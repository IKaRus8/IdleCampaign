namespace UI.Interfaces
{
    public interface IPopupService
    {
        void CreatePopup(string popupPath, bool useBackground = false);

        void ClosePopup(IPopup popup);
    }
}