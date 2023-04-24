using LiStream.Playables.Interfaces;
using LiStream.User.Interfaces.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Evaluator.Interfaces
{
    public interface IEvaluator
    {
        ISong GetSimilar(ISong song, IList<ISong> toCompare);
        IList<ISong> GetSimilarList(ISong song, IList<ISong> toCompare);

        IPlayableCollection GetSimilar(IPlayableCollection collection, IList<IPlayableCollection> toCompare);
        IList<IPlayableCollection> GetSimilarList(IPlayableCollection collection, IList<IPlayableCollection> toCompare);

        IArtistProfile GetSimilar(IArtistProfile artist, IList<IArtistProfile> toCompare);
        IList<IArtistProfile> GetSimilarList(IArtistProfile artist, IList<IArtistProfile> toCompare);
    }
}
