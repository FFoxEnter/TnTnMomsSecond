using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public static class WorldTime
{
    /// <summary>
    /// 다음 일정 날짜 - 오늘 날짜 
    /// </summary>
    public static int TimeSpanCheck(string activityStartTime)
    {
        DateTime dtFutureDate = new DateTime();
        dtFutureDate = Convert.ToDateTime(activityStartTime);
        Debug.Log("dtFutureDate: " + dtFutureDate);

        DateTime dtNowTime = DateTime.Now;
        TimeSpan timeDiff = dtFutureDate - dtNowTime;
        Debug.Log("timeDiffDays: " + timeDiff.Days);

        int diffDays = timeDiff.Days + 1;
        if (timeDiff.Days < 1)
        {
            diffDays = timeDiff.Days;
        }
        return diffDays;
    }

    /// <summary>
    /// 다음 일정 날짜 - 오늘 날짜 
    /// </summary>
    public static bool TimeSpanCheckBool(string activityEndTime)
    {
        DateTime dtFutureDate = new DateTime();
        dtFutureDate = Convert.ToDateTime(activityEndTime);

        DateTime dtNowTime = DateTime.Now;

        int dateCompardResult = DateTime.Compare(dtFutureDate, dtNowTime);
        if (dateCompardResult > 0)
        {
            // 일정 남았음
            return false;
        }
        else
        {
            // 일정 지남
            return true;
        }

        
    }


    public static string UTCNowDate(string sortType)
    {
        return DateTime.Now.ToString(sortType);
    }

    public static string GetCurDdayStringShortYear()
    {
        string CurrentDay = UTCNowDate("yy-MM-dd");

        return CurrentDay;
    }


    public static string GetCurDdayStringFullYear()
    {
        string CurrentDay = UTCNowDate("yyyy-MM-dd");

        return CurrentDay;
    }

    public static string GetCurDdayStringShortYearFullTime()
    {
        string CurrentDay = UTCNowDate("yy-MM-dd  HH:mm");

        return CurrentDay;
    }


    public static List<DateTime> GetDatesBetween(DateTime startDate, DateTime endDate)
    {
        List<DateTime> dates = new List<DateTime>();

        // 시작 날짜부터 종료 날짜까지 반복하면서 날짜 목록에 추가
        for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
        {
            dates.Add(date);
        }

        return dates;
    }

    public static string StringToDateFormat(string src)
    {
        if (DateTime.TryParse(src, out DateTime createdAtDateTime))
        {
            return createdAtDateTime.ToString("yyyy-MM-dd  HH:mm", CultureInfo.InvariantCulture);
        }
        return "";
    }

    public static string StringToDateFormatYY(string src)
    {
        if (DateTime.TryParse(src, out DateTime createdAtDateTime))
        {
            return createdAtDateTime.ToString("yy-MM-dd  HH:mm", CultureInfo.InvariantCulture);
        }
        return "";
    }

    public static string StringToDateYY(string date)
    {
        DateTime dateTime;
        string inputFormat = "yyyy-MM-dd HH:mm:ss";
        string outputFormat = "yy-MM-dd HH:mm";

        if (DateTime.TryParseExact(date, inputFormat, null, DateTimeStyles.None, out dateTime))
        {
            // 지정된 출력 포맷으로 시간을 문자열로 변환합니다.
            return dateTime.ToString(outputFormat);

        }
        return string.Empty;
    }

    public static string StringToDateYMD(string date)
    {
        DateTime dateTime;
        string inputFormat = "yyyy-MM-dd HH:mm:ss";
        string outputFormat = "yy-MM-dd";

        if (DateTime.TryParseExact(date, inputFormat, null, DateTimeStyles.None, out dateTime))
        {
            // 지정된 출력 포맷으로 시간을 문자열로 변환합니다.
            return dateTime.ToString(outputFormat);

        }
        return string.Empty;
    }

    public static DateTime? StringToDateFormatYMD(string date)
    {
        if (DateTime.TryParse(date, out DateTime createdAtDateTime))
        {
            return createdAtDateTime.Date;
        }
        else
            return null;
    }
}