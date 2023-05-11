namespace LiStream.Displayables.Interfaces
{
    public interface IDisplayableManger
    {
        IDisplayablePage GetDisplayablePage(IDisplayablePage page, MenuOptions option);
        MenuOptions GetPageMenuOption(IDisplayablePage page);
    }
}
