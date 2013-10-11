using System;
using System.Collections.Generic;

namespace uHelper.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsEqualWith<T>(this List<T> first, List<T> second)
        {
            if (first.Count != second.Count)
                return false;
            
            for (int i = 0; i < first.Count; i++)
                    if (!first[i].Equals(second[i]))
                        return false;
            return true;
        }

        public static int RawCompare(this List<byte> first, List<byte> second)
        {
            long longestLength = (first.Count > second.Count ? first.Count : second.Count);

            for (int i = 0; i < longestLength; i++)
            {
                if (i >= first.Count)
                    return -1;
                if (i >= second.Count)
                    return 1;
                if (first[i] > second[i])
                    return 1;
                if (first[i] < second[i])
                    return -1;
            }
            return 0;
        }

        public static T MaxBy<T, U>(this IEnumerable<T> array, Func<T, U> selector) where U : IComparable<U>
        {
            if (array == null)
                throw new ArgumentNullException("array","Array is null!");
            var curElem = default(T);
            var curValue = default(U);
            bool first = true;
            foreach (var elem in array)
            {
                if (first)
                {
                    curElem = elem;
                    curValue = selector(elem);
                    first = false;
                }
                else
                {
                    U cmpValue = selector(elem);
                    if (cmpValue.CompareTo(curValue)>0)
                    {
                        curValue = cmpValue;
                        curElem = elem;
                    }

                }
            }
            if (first)
                throw new InvalidOperationException("Sequence is empty!");
            return curElem;
        }

        public static T MinBy<T, U>(this IEnumerable<T> array, Func<T, U> selector) where U : IComparable<U>
        {
            if (array == null)
                throw new ArgumentNullException("array", "Array is null!");
            var curElem = default(T);
            var curValue = default(U);
            bool first = true;
            foreach (var elem in array)
            {
                if (first)
                {
                    curElem = elem;
                    curValue = selector(elem);
                    first = false;
                }
                else
                {
                    U cmpValue = selector(elem);
                    if (cmpValue.CompareTo(curValue) < 0)
                    {
                        curValue = cmpValue;
                        curElem = elem;
                    }

                }
            }
            if (first)
                throw new InvalidOperationException("Sequence is empty!");
            return curElem;
        }
    }
}
