using LiStream.Playables.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Iterator
{
    internal class SongIterator : IIterator<ISong>
    {
        private readonly IList<ISong> _songs;
        private int _current;

        public SongIterator(IList<ISong> songs)
        {
            _songs = songs;
        }

        public ISong CurrentItem()
        {
            if (IsDone())
            {
                return null;
            }

            return _songs[_current];
        }

        public ISong First()
        {
            _current = 0;
            return _songs[_current];
        }

        public bool IsDone()
        {
            return _current >= _songs.Count;
        }

        public ISong Next()
        {
            _current++;
            return CurrentItem();
        }
    }
}
