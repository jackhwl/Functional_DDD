using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    static class EnumerableExtensions
    {
        public static void Do<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            // sequence.ToList().ForEach(action); ToList  O(n)
            foreach(T obj in sequence)
                action(obj);  // O(1)
        }
    }
}
