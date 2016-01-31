using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learn_TDD.Helpers
{
    public static class Extentions
    {
        public static int AsInt(this object value)
        {
            if (value == null)
                return -1;

            if (value is int)
                return Convert.ToInt32(value);
            else
                return -1;

        }

        public static string AsString(this object value)
        {
            if (value == null)
                return string.Empty;

            if (value is string)
                return value.ToString();
            else
                return string.Empty;

        }
    }
}