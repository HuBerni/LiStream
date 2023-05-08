using LiStream.Displayables.Interfaces;
using LiStreamConsole.Navigation.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LiStreamConsole.Navigation
{
    public class CursorNavigator : ICursorNavigator
    {
        CursorColumn _currentColumn = CursorColumn.Left;
        Dictionary<CursorColumn, int> columnRowIndex = new Dictionary<CursorColumn, int>();

        public CursorNavigator()
        {
            Reset();
        }

        public void Reset()
        {
            columnRowIndex = new Dictionary<CursorColumn, int>()
            {
                { CursorColumn.Left, 0 },
                { CursorColumn.Middle, 0 },
                { CursorColumn.Right, 0 }
            };
        }

        public CursorColumn GetCursorColumn()
        {
            return _currentColumn;
        }

        public int GetCursorRowForColumn(CursorColumn column)
        {
            return columnRowIndex[column];
        }

        public void HandleKeyEntry(ConsoleKeyInfo keyInfo, IDisplayablePage page)
        {
            switch(keyInfo.Key)
            {
                case ConsoleKey.RightArrow:
                    if (_currentColumn == CursorColumn.Left && page.GetColumns() > 1)
                    {
                        _currentColumn = CursorColumn.Middle;
                    }
                    else if (_currentColumn == CursorColumn.Middle && page.GetColumns() > 2)
                    {
                        _currentColumn = CursorColumn.Right;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (_currentColumn == CursorColumn.Right)
                    {
                        _currentColumn = CursorColumn.Middle;
                    }
                    else if (_currentColumn == CursorColumn.Middle)
                    {
                        _currentColumn = CursorColumn.Left;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (columnRowIndex[_currentColumn] > 0)
                    {
                        columnRowIndex[_currentColumn]--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (page.GetRows() > columnRowIndex[_currentColumn])
                    {
                        columnRowIndex[_currentColumn]++;
                    }
                    break;
            }
        }

        public void SetCursorColumn(CursorColumn column)
        {
            _currentColumn = column;
        }
    }
}
