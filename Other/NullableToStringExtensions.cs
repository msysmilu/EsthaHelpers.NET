﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsthaHelpers.Other
{
    public static class NullableToStringExtensions
    {
        public static string ToString<T>(this T? value, string format, string coalesce = null)
            where T : struct, IFormattable
        {
            if (value == null)
            {
                return coalesce;
            }
            else
            {
                return value.Value.ToString(format, null);
            }
        }
    }
}