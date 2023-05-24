using LiStream.Evaluators.Interfaces;
using LiStream.Playables.Interfaces;
using LiStream.User.Interfaces.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Evaluators
{
    public class Evaluator : IEvaluator
    {
        private const double _similarityThreshold = 0.005;

        public ISong GetSimilar(ISong song, IList<ISong> toCompare)
        {
            ISong? mostSimilar = null;
            double highestSimilarity = 0;

            foreach (ISong item in toCompare)
            {
                double similarity = 0;

                similarity = SameBytesPercentage(song.Data, item.Data);

                if (similarity > highestSimilarity && similarity != 1)
                {
                    highestSimilarity = similarity;
                    mostSimilar = item;
                }
            }

            return mostSimilar;
        }

        public IList<ISong> GetSimilarList(ISong song, IList<ISong> toCompare)
        {
            IList<ISong> mostSimilarList = new List<ISong>();

            foreach (var item in toCompare)
            {
                double similarity = 0;

                similarity = SameBytesPercentage(song.Data, item.Data);

                if (similarity > _similarityThreshold && similarity != 1)
                {
                    mostSimilarList.Add(item);
                }
            }

            return mostSimilarList;
        }

        public IPlayableCollection GetSimilar(IPlayableCollection collection, IList<IPlayableCollection> toCompare)
        {
            throw new NotImplementedException();
        }

        public IList<IPlayableCollection> GetSimilarList(IPlayableCollection collection, IList<IPlayableCollection> toCompare)
        {
            throw new NotImplementedException();
        }

        public IArtistProfile GetSimilar(IArtistProfile artist, IList<IArtistProfile> toCompare)
        {
            var rand = new Random();
            var compList = toCompare.ToList();
            compList.Remove(compList.FirstOrDefault(x => x.Id.Equals(artist.Id)));
            return compList[rand.Next(0, compList.Count)];
        }

        public IList<IArtistProfile> GetSimilarList(IArtistProfile artist, IList<IArtistProfile> toCompare)
        {
            var compList = toCompare.ToList();
            compList.Remove(compList.FirstOrDefault(x => x.Id.Equals(artist.Id)));
            return compList.OrderBy(x => Guid.NewGuid()).Take(3).ToList(); 
        }

        private double SameBytesPercentage(byte[] data1, byte[] data2)
        {
            int sameBytes = 0;
            int length = data1.Length > data2.Length ? data2.Length : data1.Length;

            if (data1 == data2)
                return 1;

            for (int i = 0; i < length; i++)
            {
                if (data1[i] == data2[i])
                {
                    sameBytes++;
                }
            }

            return (double)sameBytes / data1.Length;
        }
    }
}
