using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HepsiBizde
{
    public static class Converter
    {
        public static Int32 IfNullThenZero(this object value)
        {
            if (value != DBNull.Value)
            {
                return Convert.ToInt32("NULL");
            }
            else
            {
                return Convert.ToInt32(value);
            }
        }
    }
}