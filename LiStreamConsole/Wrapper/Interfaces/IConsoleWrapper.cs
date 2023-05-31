namespace LiStreamConsole.Wrapper.Interfaces
{
    public interface IConsoleWrapper
    {
        ConsoleKeyInfo ReadKey(bool intercept);
        ConsoleKeyInfo ReadKey();
        void Write(string value);
        void Write(string format, params object[] arg);
        void WriteLine();
        void WriteLine(string value);
        void WriteLine(string format, params object[] arg);
    }
}