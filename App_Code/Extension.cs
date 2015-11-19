namespace reserva
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public static class Extension
    {
        public static string ToPrepare(this string str)
        {
            return str.Trim().Replace("'", "''").Replace("--", "");
        }

        public static bool isFilled(this string str)
        {
            return !String.IsNullOrEmpty(str);
        }

        public static string ToData(this DateTime str)
        {
            return (str != DateTime.MinValue) ? str.ToString("dd/MM/yyyy") : "";
        }

        public static string RemoveMask(this string str)
        {
            return str.Replace(".", "").Replace("-", "").Replace("/", "");
        }

        public static long ConvertToTimestamp(this DateTime value)
        {
            DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan elapsedTime = value - Epoch;
            return (long)elapsedTime.TotalSeconds;
        }
    }
}