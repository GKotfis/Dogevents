﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Dogevents.Core.Helpers
{
    public static class CommonHelpers
    {
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsNotEmpty(this string value)
        {
            return !IsEmpty(value);
        }

        public static bool IsAny<T>(this IEnumerable<T> source)
        {
            return source != null && source.Any();
        }

        public static int ToUnixTime(this DateTime value)
        {
            return (int)value.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
}