using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using LiStream.Playables.Interfaces;
using LiStream.User.Interfaces.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Playables
{
    public class Album : IAlbum, IDisplayable
    {
        public Guid Id { get; private set; }

        public string? Name { get; private set; }

        public DateTime ReleaseDate { get; private set; }

        public IArtistProfile? Artist { get; private set; }

        public IList<IPlayable>? Playables { get; private set; }

        public int CurrentPlayableIndex { get; private set; }

        public Album(Guid id, string name, DateTime releaseDate, IArtistProfile artist, IList<IPlayable>? playables)
        {
            Id = id;
            Name = name;
            ReleaseDate = releaseDate;
            Artist = artist;
            Playables = playables;
        }
        public void Next()
        {
            if (CurrentPlayableIndex == Playables?.Count - 1)
            {
                CurrentPlayableIndex = 0;
                return;
            }

            CurrentPlayableIndex++;
        }

        public void Previous()
        {
            if (CurrentPlayableIndex == 0)
            {
                CurrentPlayableIndex = (Playables?.Count - 1) > 0 ? (Playables!.Count - 1) : 0;

                return;
            }

            CurrentPlayableIndex--;
        }

        public void PlayItem(int index)
        {
            if (index < 0 || index > Playables?.Count - 1)
                throw new IndexOutOfRangeException();

            CurrentPlayableIndex = index;
        }

        public string GetDisplayableName()
        {
            return Name;
        }

        public IList<DisplayableInformation> GetAdditionalInformation()
        {
            return new List<DisplayableInformation> 
            { 
                new DisplayableInformation("Name", Name),
                new DisplayableInformation("Artist", Artist?.DisplayName ?? string.Empty),
                new DisplayableInformation("Release Date", ReleaseDate.ToShortDateString()),
            };
        }

        public bool IsPlaying()
        {
            return false;
        }

        public void Play()
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Restart()
        {
            throw new NotImplementedException();
        }
    }
}
