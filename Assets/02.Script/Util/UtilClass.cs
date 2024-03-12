using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class UtilClass
{
    /// <summary>
    /// string utc 시간을 string DateTime으로 변환
    /// </summary>
    /// <param name="timestr">string tile</param>
    /// <param name="type"></param>
    /// <returns></returns>
    public static string ConvertUTCTime(string timestr, string type = "yy-MM-dd HH:mm")
    {
        try
        {
            var time = DateTime.Parse(timestr).ToUniversalTime().ToLocalTime().ToString(type);
            return time;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    /// <summary>
    /// string utc 시간을 DateTime으로 변환
    /// </summary>
    /// <param name="timestr">string tile</param>
    /// <param name="type"></param>
    /// <returns></returns>
    public static DateTime ConvertUTCTimeToDatetime(string timestr)
    {
        try
        {
            var time = DateTime.Parse(timestr).ToUniversalTime().ToLocalTime();
            return time;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// 날짜에 매칭되는 데이터 있는 지 검사
    /// </summary>
    /// <param name="dateTimes"></param>
    /// <returns></returns>
    public static bool MatchDate(List<DateTime> dateTimes)
    {
        var matchDate = dateTimes.Exists((date) =>  date.Date.Day == DateTime.Now.Date.Day);
        return matchDate;
    }

    // 부모 오브젝트에서 재귀적으로 특정 타입의 부모 컴포넌트를 찾는 함수
    public static T FindComponentInParent<T>(Transform currentTransform) where T : Component
    {
        if (currentTransform == null)
            return null;

        T component = currentTransform.GetComponent<T>();
        if (component != null)
            return component;

        return FindComponentInParent<T>(currentTransform.parent);
    }

    /// <summary>
    /// 시작시간 ~ 종료시간 내 에 있는지 체크
    /// </summary>
    /// <param name="startDate">시작 시간</param>
    /// <param name="endDate">종료 시간</param>
    /// <returns></returns>
    public static bool IsScheduleExsist(string startDate, string endDate)
    {
        var start = DateTime.Parse(startDate);
        var end = DateTime.Parse(endDate);
        // 시작 시간과 종료 시간 설정
        /*DateTime startTime = new DateTime(2023, 11, 7, 9, 0, 0); // 예: 2023년 11월 7일 오전 9시
        DateTime endTime = new DateTime(2023, 11, 7, 17, 0, 0); // 예: 2023년 11월 7일 오후 5시*/

        // 검사할 시간 설정
        DateTime checkTime = DateTime.Today;

        // 시작 시간과 종료 시간 내에 있는지 확인
        if (checkTime >= start && checkTime <= end)
        {
            Console.WriteLine("검사한 시간은 시작 시간과 종료 시간 사이에 있습니다.");
        }
        else
        {
            Console.WriteLine("검사한 시간은 시작 시간과 종료 시간 사이에 없습니다.");
        }
        
        return true;
    }

    static public string CreateHTML(int width, int height, string src)
    {
        StringBuilder strBuilder = new StringBuilder();
        return "";
    }

    static public void ClearOutRenderTexture(RenderTexture renderTexture)
    {
        RenderTexture rt = RenderTexture.active;
        RenderTexture.active = renderTexture;
        GL.Clear(true, true, Color.black);
        RenderTexture.active = rt;
    }

    static public Transform GetChildObj(Transform modelTr, string strName)
    {
        Transform[] AllData = modelTr.GetComponentsInChildren<Transform>();

        foreach (Transform trans in AllData)
        {
            if (trans.name == strName)
            {
                return trans;
            }
        }
        Debug.Log("오브젝트가 없음");
        return null;
    }

    static public RenderTexture GetRenderTexture(int width, int height, int depth = 0, RenderTextureFormat format = RenderTextureFormat.Default)
    {
        var textuere = new RenderTexture(width, height, depth, format);
        textuere.Create();

        return textuere;
    }

    
}
