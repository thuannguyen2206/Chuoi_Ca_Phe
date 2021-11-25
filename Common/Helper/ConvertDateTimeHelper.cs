using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Helper
{
    public static class ConvertDateTimeHelper
    {
        public static DateTime? ConvertDateTime(string timeAsString)
        {
            if (string.IsNullOrEmpty(timeAsString))
            {
                return null;
            }
            DateTime.TryParse(timeAsString, out DateTime time);
            return time;
        }
    }
}
