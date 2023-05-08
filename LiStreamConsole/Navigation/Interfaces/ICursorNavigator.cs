using LiStream.Displayables.Interfaces;

namespace LiStreamConsole.Navigation.Interfaces
{
    public interface ICursorNavigator
    {
        CursorColumn GetCursorColumn();
        void SetCursorColumn(CursorColumn column);
        int GetCursorRowForColumn(CursorColumn column);
        void HandleKeyEntry(ConsoleKeyInfo keyInfo, IDisplayablePage page);
        void Reset();
    }
}
