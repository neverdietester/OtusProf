using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public static class Extensions
    {
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            if (collection == null || !collection.Any())
                throw new ArgumentException("Collection must not be null or empty.");

            return collection.OrderByDescending(convertToNumber).FirstOrDefault();
        }
    }
}
