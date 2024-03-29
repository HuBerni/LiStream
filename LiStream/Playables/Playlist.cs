﻿using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using LiStream.Playables.Interfaces;
using LiStream.User.Interfaces;
using LiStream.User.Interfaces.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Playables
{
    public class Playlist : IPlaylist, IDisplayable
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public IUserProfile Owner { get; private set; }

        public DateTime CreationDate { get; private set; }

        public IList<IPlayable>? Playables { get; private set; }

        public int CurrentPlayableIndex { get; private set; }

        public Playlist(Guid id, string name, IUserProfile owner, DateTime creationDate, IList<IPlayable>? playables)
        {
            Id = id;
            this.Name = name;
            Owner = owner;
            CreationDate = creationDate;
            Playables = playables;
        }

        public void AddSong(ISong song)
        {
            throw new NotImplementedException();
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

        public void RemoveSong(ISong song)
        {
            throw new NotImplementedException();
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
                new DisplayableInformation("Owner", Owner.DisplayName),
                new DisplayableInformation("Creation Date", CreationDate.ToShortDateString())
            };
        }

        public bool IsPlaying()
        {
            throw new NotImplementedException();
        }
    }
}
