using LiStream.Displayables.Interfaces;
using LiStreamConsole.Navigation;
using LiStreamConsole.Navigation.Interfaces;

namespace LiStreamConsole.Displayables
{
    public abstract class ConsoleDisplayable
    {
        protected ICursorNavigator CursorNavigator;
        protected IPageNavigator PageNavigator;

        public ConsoleDisplayable(ICursorNavigator cursorNavigator, IPageNavigator pageNavigator)
        {
            CursorNavigator = cursorNavigator;
            PageNavigator = pageNavigator;
        }

        private void PrintOptions(IList<string> options, string header, CursorColumn column)
        {
            var indentation = (int)column;
            bool activeCol = CursorNavigator.GetCursorColumn() == column;
            Console.SetCursorPosition(indentation, 0);
            Console.Write(header);
            Console.CursorTop += 2;
            Console.CursorLeft = indentation;

            for (int i = 0; i < options.Count; i++)
            {
                if (i == CursorNavigator.GetCursorRowForColumn(column) && activeCol)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else if (i == CursorNavigator.GetCursorRowForColumn(column))
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.Write(options[i]);
                Console.ResetColor();
                Console.CursorTop++;
                Console.CursorLeft = indentation;
            }
        }
        protected void PrintLeftMenu(IList<string> options, string header)
        {
            options.Add("\nBack");
            PrintOptions(options, header, CursorColumn.Left);
        }

        protected void PrintMiddleMenu(IList<string> options, string header)
        {
            PrintOptions(options, header, CursorColumn.Middle);
        }

        protected void PrintRightMenu(IList<string> options,  string header)
        {
            PrintOptions(options, header, CursorColumn.Right);
        }
    }
}
