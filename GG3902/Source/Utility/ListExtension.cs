using System.Collections.Generic;
using System.Linq;

namespace GG3902
{
    public static class ListExtension
    {
        public static List<List<T>> Chop<T>(this List<T> list, int parts)
        {
            List<List<T>> chunks = new List<List<T>>();
            int chunkCount = list.Count() / parts;

            if (list.Count % parts > 0)
            {
                chunkCount++;
            }

            for (int i = 0; i < chunkCount; i += 1)
            {
                chunks.Add(list.Skip(i * parts).Take(parts).ToList());
            }

            return chunks;
        }
    }
}
