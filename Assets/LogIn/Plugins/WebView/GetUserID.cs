using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class GetUserID : MonoBehaviour
{
    string url = "http://ring.nutc.edu.tw/garmin/Joyce/sel.php";
    public TMP_InputField accounttxt;
    public TMP_InputField passwordtxt;
    public static string account;
    public static string password;
    public static string userid;
    public static string username;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void gostart()
    {
        Debug.Log("gostart");

        //判斷密碼格式
        if(accounttxt.text != null && passwordtxt != null){

            Debug.Log(accounttxt.text);
            Debug.Log(passwordtxt.text);

            account = accounttxt.text;
            password = passwordtxt.text;

            StartCoroutine(getuserid());

        }
        
    }
    IEnumerator getuserid()
    {
        //查資料  userid 
        WWWForm form = new WWWForm();
        form.AddField("action", "getuserid");
        form.AddField("account", account);
        form.AddField("password", password);
        WWW www = new WWW(url, form);

        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
        }
        Debug.Log(www.text);

        
        if(www.text!=null){
            var received_data = Regex.Split(www.text, "</next>");
            userid=received_data[0];
            username=received_data[1];
            Debug.Log("getuserid" + userid);
        }
    }
}
