using LiStream.Commands;
using LiStream.Commands.Interfaces;
using LiStream.DataHandler.Interfaces;
using LiStream.Playables.Interfaces;
using LiStream.User.Interfaces;
using LiStream.User.Interfaces.Profile;
using LiStreamConsole;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;

public class ConsoleMenu
{
    private string[] _leftOptions = new string[0];
    private string[] _middleOptions = new string[0];
    private string[] _rightOptions = new string[0];

    private int _selectedLeftIndex;
    private int _selectedMiddleIndex;
    private int _selectedRightIndex;

    private ConsoleKeyInfo _keyInfo;

    private enum ColState
    {
        Left = 0,
        Middle = 40,
        Right = 80
    }

    private ColState _colState;
    private IDataHandler _dataHandler;
    private IInvoker _invoker;

    public ConsoleMenu(IDataHandler datahandler, IInvoker invoker)
    {
        _dataHandler = datahandler;
        Console.CursorVisible = false;
        _colState = ColState.Middle;
        _invoker = invoker;
    }

    public void MainMenu()
    {
        clearOptions();
        var options = Enum.GetNames(typeof(MainMenuOptions));
        _middleOptions = options;
        MainMenuOptions option = MainMenuOptions.Songs;

        do
        {
            _colState = ColState.Middle;
            printMenues(middleHeader: "Select: ");

            menuInput();

            Enum.TryParse(_middleOptions[_selectedMiddleIndex], out option);

            if (_keyInfo.Key == ConsoleKey.Enter)
            {
                switch (option)
                {
                    case MainMenuOptions.Songs:
                        showSongs(_dataHandler.GetSongs());
                        break;
                    case MainMenuOptions.Playlists:
                        showPlaylists(_dataHandler.GetPlaylists());
                        break;
                    case MainMenuOptions.Artists:
                        showArtists(_dataHandler.GetArtistProfiles());
                        break;
                    case MainMenuOptions.Albums:
                        showAlbums(_dataHandler.GetAlbums());
                        break;
                    case MainMenuOptions.Exit:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }

                clearOptions();
                _middleOptions = options;
            }

        } while (true);
    }

    private SongMenuOptions showSongs(IList<ISong> songs, IList<IPlaylist>? playlists = null, string firstColHeader = "Songs:")
    {
        clearOptions();
        var options = createOptions(songs.Select(x => x.Name));
        _leftOptions = options;
        SongMenuOptions songState = SongMenuOptions.Idle;

        do
        {
            printMenues(firstColHeader, $"Selected Song:\n\n\n\n\n\n\n\n", "Playlists:");

            if (_selectedLeftIndex >= 0 && _selectedLeftIndex < songs.Count)
                songPreview(songs[_selectedLeftIndex]);

            menuInput();
               
            if (_selectedLeftIndex < songs.Count)
            {
                songState = songMenu(songs[_selectedLeftIndex]);

                if (songState == SongMenuOptions.AddToPlaylist || _colState == ColState.Right)
                {
                    if (playlists is null)
                        playlists = _dataHandler.GetPlaylists();

                    songPlaylistMenu(playlists, songs[_selectedLeftIndex].Id);
                }

                if (songState == SongMenuOptions.GetSimilar)
                {
                    showSongs(_dataHandler.GetSimilarList(songs[_selectedLeftIndex]), playlists, $"Similar songs for\n{songs[_selectedLeftIndex].Name}:");
                    clearOptions();
                    _leftOptions = options;
                }

                if (songState == SongMenuOptions.GoToArtist)
                {
                    showArtist(songs[_selectedLeftIndex].Artist);
                    clearOptions();
                    _leftOptions = options;
                }

                if (songState == SongMenuOptions.GoToAlbum)
                {
                    showSongs(_dataHandler.GetSongs().Where(x => x.Album?.Id == songs[_selectedLeftIndex].Album.Id).ToList()
                        , playlists, 
                        $"Songs from Album\n{songs[_selectedLeftIndex].Album?.Name}:");
                    clearOptions();
                    _leftOptions = options;
                }

                if (_colState == ColState.Right && _keyInfo.Key == ConsoleKey.Enter)
                    _dataHandler.InsertSongToPlaylist(songs[_selectedLeftIndex].Id, playlists[_selectedRightIndex].Id, new Guid("A15AC3CE-52F1-4B72-BE36-D1AC05390796"));

                if (songState is SongMenuOptions.Play or SongMenuOptions.Pause or SongMenuOptions.Restart)
                {
                    songs = updateSongStates(songs);
                }

                continue;
            }

            _middleOptions = new string[0];

        } while (_keyInfo.Key != ConsoleKey.Enter || _selectedLeftIndex != _leftOptions.Length - 1);

        _keyInfo = new ConsoleKeyInfo();

        return SongMenuOptions.GoBack;
    }

    private IList<ISong> updateSongStates(IList<ISong> songs)
    {
        foreach (ISong song in songs.Where(x => x.IsPlaying == true))
        {
            if (!songs[_selectedLeftIndex].IsPlaying)

            if (song != songs[_selectedLeftIndex])
            {
                song.Restart();
                song.Pause();
            }

        }

        _leftOptions = songs.Select(x => x.Name).Concat(new[] { string.Empty, "Back" }).ToArray();

        if (songs[_selectedLeftIndex].IsPlaying)
            _leftOptions[_selectedLeftIndex] = $"> {songs[_selectedLeftIndex].Name}";

        if (!songs[_selectedLeftIndex].IsPlaying)
            _leftOptions[_selectedLeftIndex] = songs[_selectedLeftIndex].Name;

        return songs;
    }

    private void songPlaylistMenu(IList<IPlaylist> playlists, Guid songID)
    {
        _rightOptions = playlists.Select(x => x.Name).ToArray();


        if (_colState == ColState.Right && _keyInfo.Key == ConsoleKey.Enter)
        {
            var success = _dataHandler.InsertSongToPlaylist(songID, playlists[_selectedRightIndex].Id, new Guid("A15AC3CE-52F1-4B72-BE36-D1AC05390796"));
            _keyInfo = new ConsoleKeyInfo();
        }
    }

    private SongMenuOptions songMenu(ISong song)
    {
        _middleOptions = new string[] 
        {   "Restart",
            string.Empty,
            "Add to Playlist",
            "Go to Artist",
            "Get Similar",
            string.Empty
        };

        if (song.Album != null)
            _middleOptions[_middleOptions.Length - 1] = "Go to Album";

        if (_colState == ColState.Middle && _keyInfo.Key == ConsoleKey.Enter)
        {
            switch (_middleOptions[_selectedMiddleIndex])
            {
                case "Restart":
                    _invoker.ExecuteCommand(new RestartCommand(song));
                    return SongMenuOptions.Restart;
                case "Add to Playlist":
                    return SongMenuOptions.AddToPlaylist;
                case "Go to Artist":
                    return SongMenuOptions.GoToArtist;
                case "Get Similar":
                    return SongMenuOptions.GetSimilar;
                case "Go to Album":
                    return SongMenuOptions.GoToAlbum;
                default:
                    break;
            }

            _keyInfo = new ConsoleKeyInfo();
        }

        if (_colState == ColState.Left && _keyInfo.Key == ConsoleKey.Enter)
        {
            if (song.IsPlaying)
            {
                song.Pause();
                return SongMenuOptions.Pause;
            }

            song.Play();
            return SongMenuOptions.Play;
        }

        return SongMenuOptions.GoBack;
    }

    private void showPlaylists(IList<IPlaylist> playlists)
    {
        clearOptions();
        var options = createOptions(playlists.Select(x => x.Name));
        _leftOptions = options;

        do
        {
            printMenues("Playlists: ");

            if (_selectedLeftIndex < playlists.Count)
                playlistPreview(playlists[_selectedLeftIndex]);

            menuInput();

            if (_keyInfo.Key == ConsoleKey.Enter && _selectedLeftIndex < playlists.Count)
            {
                var songIDs = _dataHandler.GetPlaylist(playlists[_selectedLeftIndex].Id).Playables.Select(x => x.Id).ToList();
                var songs = _dataHandler.GetSongs().Where(x => songIDs.Contains(x.Id)).ToList();
                showSongs(songs, playlists, $"Songs from Playlist\n{playlists[_selectedLeftIndex].Name}:");
                _leftOptions = options;
            }

        } while (_keyInfo.Key != ConsoleKey.Enter || _selectedLeftIndex != _leftOptions.Length - 1);

        _keyInfo = new ConsoleKeyInfo();
    }

    private void showAlbums(IList<IAlbum> albums, string header = "Albums:")
    {
        clearOptions();
        var options = createOptions(albums.Select(x => x.Name));
        _leftOptions = options;

        do
        {
            printMenues(header);

            if (_selectedLeftIndex < albums.Count)
                albumPreview(albums[_selectedLeftIndex]);
            menuInput();

            if (_keyInfo.Key == ConsoleKey.Enter && _selectedLeftIndex < albums.Count)
            {
                showSongs(_dataHandler.GetSongs().Where(x => x.Album?.Id == albums[_selectedLeftIndex].Id).ToList(), 
                    firstColHeader: $"Songs from Album\n{albums[_selectedLeftIndex].Name}:");
                clearOptions();
                _leftOptions = options;
            }

        } while (_keyInfo.Key != ConsoleKey.Enter || _selectedLeftIndex != _leftOptions.Length - 1);

        _keyInfo = new ConsoleKeyInfo();
    }

    private void showArtists(IList<IArtistProfile> artists)
    {
        clearOptions();
        var options = createOptions(artists.Select(x => x.DisplayName));
        _leftOptions = options;

        do
        {
            printMenues("Artists: ");

            if (_selectedLeftIndex < artists.Count)
                artistPreview(artists[_selectedLeftIndex]);

            menuInput();

            if (_keyInfo.Key == ConsoleKey.Enter && _selectedLeftIndex < artists.Count)
            {
                showArtist(artists[_selectedLeftIndex]);
                clearOptions();
                _leftOptions = options;
            }

        } while (_keyInfo.Key != ConsoleKey.Enter || _selectedLeftIndex != _leftOptions.Length - 1);

        _keyInfo = new ConsoleKeyInfo();
    }

    private void showArtist(IArtistProfile artist)
    {
        clearOptions();
        var options = createOptions(new string[] {"Albums", "Songs", "Get Similar"});
        _leftOptions = options;

        do
        {
            printMenues($"Artist: {artist.DisplayName}");
            artistPreview(artist);

            menuInput();

            if (_keyInfo.Key == ConsoleKey.Enter)
            {
                switch (_leftOptions[_selectedLeftIndex])
                {
                    case "Albums":
                        showAlbums(_dataHandler.GetArtistAlbums(artist.Id), $"{artist.DisplayName}'s albums:");
                        clearOptions();
                        _leftOptions = options;
                        break;
                    case "Songs":
                        showSongs(_dataHandler.GetSongs().Where(x => x.Artist.Id == artist.Id).ToList(), firstColHeader: $"{artist.DisplayName}'s songs:");
                        clearOptions();
                        _leftOptions = options;
                        break;
                    case "Get Similar":
                        showArtists(_dataHandler.GetSimilarList(artist));
                        break;
                }
            }

        } while (_keyInfo.Key != ConsoleKey.Enter || _selectedLeftIndex != _leftOptions.Length - 1);

        _keyInfo = new ConsoleKeyInfo();
    }

    private void songPreview(ISong song)
    {
        Console.SetCursorPosition(40, 2);
        Console.Write($"Title: {song.Name}");

        Console.SetCursorPosition(40, 3);
        Console.Write($"Artist: {song.Artist.DisplayName}");

        Console.SetCursorPosition(40, 4);
        Console.Write($"Album: {song.Album?.Name}");

        Console.SetCursorPosition(40, 5);
        Console.Write($"Release date: {song.ReleaseDate.ToString("dd-MM-yyyy")}");

        Console.SetCursorPosition(40, 6);
        Console.Write($"Lenght: {song.Lenght}");
    }

    private void playlistPreview(IPlaylist playlist)
    {
        Console.SetCursorPosition(40, 0);
        Console.Write("Playlist preview:");

        Console.SetCursorPosition(40, 2);
        Console.WriteLine($"Name: {playlist.Name}");

        Console.SetCursorPosition(40, 3);
        Console.WriteLine($"Owner: {playlist.Owner.DisplayName}");

        Console.SetCursorPosition(40, 4);
        Console.WriteLine($"Creation date: {playlist.CreationDate.ToString("dd-MM-yyyy")}");

    }

    private void albumPreview(IAlbum album)
    {
        Console.SetCursorPosition(40, 0);
        Console.Write("Album preview:");

        Console.SetCursorPosition(40, 2);
        Console.WriteLine($"Name: {album.Name}");

        Console.SetCursorPosition(40, 3);
        Console.WriteLine($"Artist: {album.Artist.DisplayName}");

        Console.SetCursorPosition(40, 4);
        Console.WriteLine($"Release date: {album.ReleaseDate.ToString("dd-MM-yyyy")}");
    }

    private void artistPreview(IArtistProfile artist)
    {
        Console.SetCursorPosition(40, 0);
        Console.Write("Artist preview:");

        Console.SetCursorPosition(40, 2);
        Console.WriteLine($"Name: {artist.DisplayName}");

        Console.SetCursorPosition(40, 3);
        Console.WriteLine($"Bio: {artist.Bio}");
    }

    private void printOptions(string[] options, int selectedIndex, string header, bool activeCol, int x)
    {
        Console.SetCursorPosition(x, 0);
        Console.Write(header);
        Console.CursorTop += 2;
        Console.CursorLeft = x;

        for (int i = 0; i < options.Length; i++)
        {
            if (i == selectedIndex && activeCol)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if(i == selectedIndex)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.Write(options[i]);
            Console.ResetColor();
            Console.CursorTop++;
            Console.CursorLeft = x;
        }
    }

    private void printMenues(string leftHeader = "", string middleHeader = "", string rightHeader = "")
    {
        Console.Clear();

        printLeftMenu(_leftOptions.Count() != 0 ? leftHeader : string.Empty);
        printMiddleMenu(_middleOptions.Count() != 0 ? middleHeader : string.Empty);
        printRightMenu(_rightOptions.Count() != 0 ? rightHeader : string.Empty);
    }

    private void printLeftMenu(string header)
    {
        printOptions(_leftOptions, _selectedLeftIndex, header, _colState == ColState.Left, (int)ColState.Left);
    }

    private void printMiddleMenu(string header)
    {
        printOptions(_middleOptions, _selectedMiddleIndex, header, _colState == ColState.Middle, (int)ColState.Middle);
    }

    private void printRightMenu(string header)
    {
        printOptions(_rightOptions, _selectedRightIndex, header, _colState == ColState.Right, (int)ColState.Right);
    }

    private void menuInput()
    {
        _keyInfo = Console.ReadKey(false);

        switch (_colState)
        {
            case ColState.Left:
                handleMenuUpDown(ref _selectedLeftIndex, ref _leftOptions);
                break;
            case ColState.Middle:
                handleMenuUpDown(ref _selectedMiddleIndex, ref _middleOptions);
                break;
            case ColState.Right:
                handleMenuUpDown(ref _selectedRightIndex, ref _rightOptions);
                break;
        }

        switchColState();
    }
    private void clearOptions()
    {
        _colState = ColState.Left;
        _leftOptions = new string[0];
        _middleOptions = new string[0];
        _rightOptions = new string[0];
        _selectedLeftIndex = 0;
        _selectedMiddleIndex = 0;
        _selectedRightIndex = 0;
    }
    private void handleMenuUpDown(ref int selectedIndex, ref string[] options)
    {
        switch (_keyInfo.Key)
        {
            case ConsoleKey.UpArrow:
                selectedIndex--;
                break;
            case ConsoleKey.DownArrow:
                selectedIndex++;
                break;
        }

        if (selectedIndex < 0)
        {
            selectedIndex = options.Length - 1;
        }
        else if (selectedIndex >= options.Length)
        {
            selectedIndex = 0;
        }

        if (options[selectedIndex] == string.Empty)
        {
            handleMenuUpDown(ref selectedIndex, ref options);
        }
    }
    private void switchColState()
    {
        if (_keyInfo.Key == ConsoleKey.RightArrow)
        {
            if (_colState == ColState.Left && _middleOptions.Length > 0)
            {
                _colState = ColState.Middle;
            }
            else if (_colState == ColState.Middle && _rightOptions.Length > 0)
            {
                _colState = ColState.Right;
            }
        }
        else if (_keyInfo.Key == ConsoleKey.LeftArrow)
        {
            if (_colState == ColState.Right && _middleOptions.Length > 0)
            {
                _colState = ColState.Middle;
            }
            else if (_colState == ColState.Middle && _leftOptions.Length > 0)
            {
                _colState = ColState.Left;
            }
        }
    }
    private string[] createOptions(IEnumerable<string> arr)
    {
        return arr.ToArray().Concat(new string[] { string.Empty, "Back" }).ToArray();
    }
}
