using LiStream.DataHandler.Interfaces;
using LiStream.Playables.Interfaces;

namespace LiStream.Displayables.Interfaces
{
    public interface IDisplayablePage
    {
        int GetColumns();
        int GetColumsForItem(int index);
        int GetRows();
        void Display();
        IList<IDisplayable> GetDisplayables();
        void SetDisplayables(IList<IDisplayable> displayables);
        MenuOption GetSelectedMenuOption();
        IDisplayablePage GetNavigateBackPage();
        void SelectedAction(MenuOption pageOption, int selectedIndex);
    }
}
