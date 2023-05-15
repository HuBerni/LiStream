namespace LiStream.Displayables.Interfaces
{
    public interface IDisplayableManager
    {
        IDisplayablePage GetDisplayablePage(IDisplayablePage page, MenuOption option);
        MenuOption GetPageMenuOption(IDisplayablePage page);
    }
}
