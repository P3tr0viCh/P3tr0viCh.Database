using System;

namespace P3tr0viCh.Database
{
    public static class DateTimeExtensions
    {
        public static string FormatDate = "yyyy-MM-dd";
        public static string FormatDateTime = "yyyy-MM-dd HH:mm:ss";

        public static string ToSqlDateString(this DateTime dateTime) => dateTime.ToString(FormatDate);
        public static string ToSqlDateTimeString(this DateTime dateTime) => dateTime.ToString(FormatDateTime);
    }
}