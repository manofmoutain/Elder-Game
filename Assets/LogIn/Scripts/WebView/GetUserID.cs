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
    string url = "http://ring.nutc.edu.tw/garmin/Joyce/get_userID.php";
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
    public void gostart(string remaccount,string rempassword)
    {
        Debug.Log("gostart");
        account = remaccount;
        password = rempassword;
        StartCoroutine(getuserid());
        
    }
    IEnumerator getuserid()
    {
        Debug.Log("getuserid()");
        //查資料  userid 
        WWWForm form = new WWWForm();
        form.AddField("action", "GetUserID");
        form.AddField("account", account);
        form.AddField("password", password);
        WWW www = new WWW(url, form);

        yield return www;
        Debug.Log("getuserid()");
        if(www.error == "Null" || string.IsNullOrEmpty(www.text) || string.IsNullOrWhiteSpace(www.text))
        {
            Debug.Log(www.error);

        }else{
            Debug.Log(www.text);
            var received_data = Regex.Split(www.text, "</next>");
            userid=received_data[0];
            username=received_data[1];
            Debug.Log("getuserid" + userid);
            Debug.Log("getusername" + username);
        }
        SceneManager.LoadScene("menu");
    }
}
