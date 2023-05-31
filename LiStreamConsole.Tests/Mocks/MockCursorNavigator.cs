using LiStream.Displayables.Interfaces;
using LiStreamConsole.Navigation;
using LiStreamConsole.Navigation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStreamConsole.Tests.Mocks
{
    public class MockCursorNavigator : ICursorNavigator
    {
        public CursorColumn GetCursorColumn()
        {
            throw new NotImplementedException();
        }

        public int GetCursorRowForColumn(CursorColumn column)
        {
            throw new NotImplementedException();
        }

        public void HandleKeyEntry(ConsoleKeyInfo keyInfo, IDisplayablePage page)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void SetCursorColumn(CursorColumn column)
        {
            throw new NotImplementedException();
        }
    }
}
