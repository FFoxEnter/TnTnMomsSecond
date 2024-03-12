using UnityEngine;
using System;
using Newtonsoft.Json;

[Serializable]
public class LoginManager : MonoBehaviour
{
    public event Action OnLoginSuccess;

    public void InnerAwake()
    {
        //Login();
    }

    public void Login()
    {
        DataModel.LoginInfo resLogin = new DataModel.LoginInfo()
        {
            studentId = "unity",
            password = "user",
        };

        string tempPostStudentLogin = $"{RestApi.EndPoint.User}{RestApi.EndPoint.EXAMPLE.HelloWorld}";
        RestApi.Login(tempPostStudentLogin, resLogin, (req) =>
        {
            // 다운로드 핸들러에서 Json을 가져오기.
            string reqData = req.downloadHandler.text;

            // Base 데이터를 기반으로 역직렬화.
            var jObjectLoginData = JsonConvert.DeserializeObject<DataModel.Base>(reqData);

            if (jObjectLoginData.data != null)
            {
                // 데이터를 Token 클래스로 역직렬화.
                var token = jObjectLoginData.data.ToObject<DataModel.Token>();

                // token에서 accessToken에 접근.
                string accessToken = token?.accessToken;

                RestApi.accessToken = accessToken;

                Debug.Log("RestApi.accessToken: " + RestApi.accessToken);

                // 로그인 성공 시 이벤트 발생.
                OnLoginSuccess?.Invoke();
            }
            else
            {
                Debug.Log("data 오브젝트에 데이터가 없습니다.");
            }
        });
    }


}