using System.Globalization;

namespace AhmadShop.Common.Extensions;

public static partial class DateExtension
{
    public static DateTime ToMiladiDateTime(this string shamsiDate)
    {
        int year = int.Parse(shamsiDate.Substring(0, 4));
        int month = int.Parse(shamsiDate.Substring(4, 2));
        int day = int.Parse(shamsiDate.Substring(6, 2));

        PersianCalendar pc = new PersianCalendar();
        DateTime dateTime = pc.ToDateTime(year, month, day, 0, 0, 0, 0);

        return dateTime;
    }

    public static DateOnly ToMiladiDate(this string shamsiDate)
    {
        int year = int.Parse(shamsiDate.Substring(0, 4));
        int month = int.Parse(shamsiDate.Substring(4, 2));
        int day = int.Parse(shamsiDate.Substring(6, 2));

        PersianCalendar pc = new PersianCalendar();
        DateTime dateTime = pc.ToDateTime(year, month, day, 0, 0, 0, 0);

        return DateOnly.FromDateTime(dateTime);
    }

    public static string ToPersianDate(this DateTime miladiDate, DateFormat format)
    {
        var pc = new PersianCalendar();

        // Convert the Miladi date to Shamsi
        int year = pc.GetYear(miladiDate);
        int month = pc.GetMonth(miladiDate);
        int day = pc.GetDayOfMonth(miladiDate);

        // Get the last two digits of the year
        string shortYear = (year % 100).ToString("D2");

        return format switch
        {
            DateFormat.yyyyMMddHHmmss => $"{year}{month:D2}{day:D2}{miladiDate.Hour:D2}{miladiDate.Minute:D2}{miladiDate.Second:D2}",
            DateFormat.yyyyMMdd => $"{year}{month:D2}{day:D2}",
            DateFormat.yyyy_MM_dd => $"{year}-{month:D2}-{day:D2}",
            DateFormat.yyMMdd => $"{shortYear}{month:D2}{day:D2}",
            DateFormat.yy_MM_dd => $"{shortYear}-{month:D2}-{day:D2}",
            _ => $"{year}-{month:D2}-{day:D2} {miladiDate.Hour:D2}:{miladiDate.Minute:D2}:{miladiDate.Second:D2}.{miladiDate.Millisecond:D3}",
        };
    }

    public static string ToPersianDate(this DateOnly date, DateFormat format)
    {
        var pc = new PersianCalendar();
        var miladiDate = date.ToDateTime(new TimeOnly());
        int year = pc.GetYear(miladiDate);
        int month = pc.GetMonth(miladiDate);
        int day = pc.GetDayOfMonth(miladiDate);

        string shortYear = (year % 100).ToString("D2");

        return format switch
        {
            DateFormat.yyyyMMddHHmmss => $"{year}{month:D2}{day:D2}{miladiDate.Hour:D2}{miladiDate.Minute:D2}{miladiDate.Second:D2}",
            DateFormat.yyyyMMdd => $"{year}{month:D2}{day:D2}",
            DateFormat.yyyy_MM_dd => $"{year}-{month:D2}-{day:D2}",
            DateFormat.yyMMdd => $"{shortYear}{month:D2}{day:D2}",
            DateFormat.yy_MM_dd => $"{shortYear}-{month:D2}-{day:D2}",
            _ => $"{year}-{month:D2}-{day:D2} {miladiDate.Hour:D2}:{miladiDate.Minute:D2}:{miladiDate.Second:D2}.{miladiDate.Millisecond:D3}",
        };
    }


    public enum DateFormat
    {
        None = 0,
        yyyyMMddHHmmss = 1,
        yyyyMMdd = 2,
        yyyy_MM_dd = 3,
        yyMMdd = 4,
        yy_MM_dd = 5
    }
    public enum TimeFormat
    {
        None = 0,
        HHmmss,
        HHmm,
        HH_mm_ss,
        HH_mm
    }
}