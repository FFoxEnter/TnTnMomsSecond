using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

public static class RestApi
{
    public static string accessToken;
    public static string AnonymousToken;

    public static string DevUrl = "http://3.35.142.107/api/";

    public static class EndPoint
    {
        public static string User = "u/";
        public static string Admin = "a/";

        public static class EXAMPLE
        {
            /// <summary>
            /// Data A 예시.
            /// </summary>
            public static string HelloWorld = "hello/world";
        }
    }

    private enum Type
    {
        GET,
        POST,
        PATCH,
        DELETE
    }

    private static IEnumerator RestRequest(string uri, string type, object data, Action<UnityWebRequest> callback)
    {
        string url = $"{DevUrl}{uri}";
        Debug.Log("Request Url : " + url);

        byte[] jsonByte = null;

        if (data != null)
        {
            string jsonStr = JsonUtility.ToJson(data);
            jsonByte = Encoding.UTF8.GetBytes(jsonStr);
        }

        var request = new UnityWebRequest(url, type);
        request.uploadHandler = new UploadHandlerRaw(jsonByte);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + accessToken);

        yield return request.SendWebRequest();

        string[] pages = uri.Split('/');
        int page = pages.Length - 1;

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.result);
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
            callback.Invoke(request);
        }

        switch (request.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError(pages[page] + ": Error: " + request.error);
                break;
            case UnityWebRequest.Result.ProtocolError:
                Debug.LogError(pages[page] + ": HTTP Error: " + request.error);
                break;
            case UnityWebRequest.Result.Success:
                Debug.Log(pages[page] + ":\nReceived: " + request.downloadHandler.text);
                break;
        }
    }

    private static IEnumerator LoginRequest(string uri, string type, object data, Action<UnityWebRequest> callback)
    {
        string url = $"{DevUrl}{uri}";
        Debug.Log("Request Url : " + url);

        byte[] jsonByte = null;

        if (data != null)
        {
            string jsonStr = JsonUtility.ToJson(data);
            jsonByte = Encoding.UTF8.GetBytes(jsonStr);
        }

        var request = new UnityWebRequest(url, type);
        request.uploadHandler = new UploadHandlerRaw(jsonByte);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        string[] pages = uri.Split('/');
        int page = pages.Length - 1;

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.result);
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
            callback.Invoke(request);
        }

        switch (request.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError(pages[page] + ": Error: " + request.error);
                break;
            case UnityWebRequest.Result.ProtocolError:
                Debug.LogError(pages[page] + ": HTTP Error: " + request.error);
                break;
            case UnityWebRequest.Result.Success:
                Debug.Log(pages[page] + ":\nReceived: " + request.downloadHandler.text);
                break;
        }
    }

    private static IEnumerator ExternalUrlRequest(string externaluri, string uri, string type, object data, Action<UnityWebRequest> callback)
    {
        string url = $"{externaluri}{uri}";
        Debug.Log("Request Url : " + url);

        byte[] jsonByte = null;

        if (data != null)
        {
            string jsonStr = JsonUtility.ToJson(data);
            jsonByte = Encoding.UTF8.GetBytes(jsonStr);
        }

        var request = new UnityWebRequest(url, type);
        request.uploadHandler = new UploadHandlerRaw(jsonByte);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        string[] pages = uri.Split('/');
        int page = pages.Length - 1;

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.result);
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
            callback.Invoke(request);
        }

        switch (request.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError(pages[page] + ": Error: " + request.error);
                break;
            case UnityWebRequest.Result.ProtocolError:
                Debug.LogError(pages[page] + ": HTTP Error: " + request.error);
                break;
            case UnityWebRequest.Result.Success:
                Debug.Log(pages[page] + ":\nReceived: " + request.downloadHandler.text);
                break;
        }
    }

    public static void Get(string url, Action<UnityWebRequest> callback)
    {
        StaticCoroutine.StartCoroutine(RestRequest(url, Enum.GetName(typeof(Type), Type.GET), null, callback));
    }

    public static void Post(string uri, object data, Action<UnityWebRequest> callback)
    {
        StaticCoroutine.StartCoroutine(RestRequest(uri, Enum.GetName(typeof(Type), Type.POST), data, callback));
    }

    public static void Patch(string uri, object data, Action<UnityWebRequest> callback)
    {
        StaticCoroutine.StartCoroutine(RestRequest(uri, Enum.GetName(typeof(Type), Type.PATCH), data, callback));
    }

    public static void Delete(string url, Action<UnityWebRequest> callback)
    {
        StaticCoroutine.StartCoroutine(RestRequest(url, Enum.GetName(typeof(Type), Type.DELETE), null, callback));
    }

    public static void Login(string uri, object data, Action<UnityWebRequest> callback)
    {
        StaticCoroutine.StartCoroutine(LoginRequest(uri, Enum.GetName(typeof(Type), Type.POST), data, callback));
    }

    public static void ExternalGetRequest(string externaluri, string uri, Action<UnityWebRequest> callback)
    {
        StaticCoroutine.StartCoroutine(ExternalUrlRequest(externaluri, uri, Enum.GetName(typeof(Type), Type.GET), null, callback));
    }

}