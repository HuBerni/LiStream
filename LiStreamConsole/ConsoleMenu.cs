using LiStream.Playables.Interfaces;
using LiStreamConsole;
using System;

public class ConsoleMenu
{
    private string[] _options;
    private int _selectedOptionIndex;

    //give me a main menu with options "Songs", "Playlists", "Artists", "Albums" and "Exit", when i select the "Songs" it should call the ShowSongs method

    public MainMenuOptions MainMenu()
    {
        _options = Enum.GetNames(typeof(MainMenuOptions));
        ConsoleKeyInfo keyInfo;

        do
        {
            printOptions("Select an option:\n");

            keyInfo = Console.ReadKey(false);

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                menuUp();
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                menuDown();
            }
        } while (keyInfo.Key != ConsoleKey.Enter);

        return (MainMenuOptions)_selectedOptionIndex;   
    }

    public ISong ShowSongs(IList<ISong> songs)
    {
        _options = songs.Select(x => x.Name).Concat(new[] { "Back" }).ToArray();

        ConsoleKeyInfo keyInfo;

        do
        {
            printOptions("Select a song:\n");
            songPreview(songs[_selectedOptionIndex]);

            keyInfo = Console.ReadKey(false);

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                menuUp();
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                menuDown();
            }

        } while (keyInfo.Key != ConsoleKey.Enter);

        if (_selectedOptionIndex == _options.Length - 1)
            return null;

        return songs[_selectedOptionIndex];
    }

    private void songPreview(ISong song)
    {
        Console.SetCursorPosition(50, 0);
        Console.Write("Song preview:\n\n");

        Console.SetCursorPosition(50, 2);
        Console.Write($"Title: {song.Name}");

        Console.SetCursorPosition(50, 3);
        Console.Write($"Artist: {song.Artist.DisplayName}");

        Console.SetCursorPosition(50, 4);
        Console.Write($"Album: {song.Album?.Name}");
    }

    private void printOptions(string header)
    {
        Console.Clear();
        Console.WriteLine(header);

        for (int i = 0; i < _options.Length; i++)
        {
            if (i == _selectedOptionIndex)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine(_options[i]);
            Console.ResetColor();
        }
    }

    private void menuUp()
    {
        _selectedOptionIndex--;
        if (_selectedOptionIndex < 0)
        {
            _selectedOptionIndex = _options.Length - 1;
        }
    }

    private void menuDown()
    {
        _selectedOptionIndex++;
        if (_selectedOptionIndex >= _options.Length)
        {
            _selectedOptionIndex = 0;
        }
    }
}
