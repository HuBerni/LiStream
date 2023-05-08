namespace LiStream.Displayables.Interfaces
{
    public interface IDisplayableManger
    {
        IDisplayablePage GetDisplayable(IDisplayablePage page, MainMenuOptions option);
        MainMenuOptions GetPageMenuOption(IDisplayablePage page);
    }
}
