﻿using System;

namespace ChainComparable
{
    internal static class Comparer
    {
        public static int SafeCompare<T>(
            T left,
            T right)
            where T : IComparable<T>
        {
            if (object.ReferenceEquals(left, right))
            {
                return 0;
            }

            if (left is null)
            {
                return -1;
            }

            if (right is null)
            {
                return 1;
            }

            return left.CompareTo(right);
        }
    }
}
