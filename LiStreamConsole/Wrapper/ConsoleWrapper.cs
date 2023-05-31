using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiStreamConsole.Wrapper.Interfaces;

namespace LiStreamConsole.Wrapper
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        public void Write(string format, params object[] arg)
        {
            Console.Write(format, arg);
        }

        public void WriteLine(string format, params object[] arg)
        {
            Console.WriteLine(format, arg);
        }

        public ConsoleKeyInfo ReadKey(bool intercept)
        {
            return Console.ReadKey(intercept);
        }

        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey(false);
        }
    }
}
