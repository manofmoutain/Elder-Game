using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;



public class SignIn : MonoBehaviour
{
    string url = "http://ring.nutc.edu.tw/garmin/Joyce/sel.php";
    public TMP_InputField accounttxt;
    public TMP_InputField passwordtxt;
    public TMP_Text errortxt;
    public static string account;
    public static string password;
    public static string userid;

    void Start()
    {
        Debug.Log("SignIn");
    }
    public void gostart()
    {
        Debug.Log("gostart");

        //判斷密碼格式
        if(accounttxt.text != null && passwordtxt != null){

            Debug.Log(accounttxt.text);
            Debug.Log(passwordtxt.text);

            account = accounttxt.text;
            password = passwordtxt.text;

            StartCoroutine(login());

        }
        
    }
    IEnumerator login()
    {
        //查資料  userid 
        WWWForm form = new WWWForm();
        form.AddField("action", "login");
        form.AddField("account", account);
        form.AddField("password", password);
        //form.AddField("fid", id);
        WWW www = new WWW(url, form);

        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
        }
        Debug.Log(www.text);

        //判斷帳密是否正確，正確->換頁，錯誤->顯示錯誤訊息
        if(www.text=="Success"){
            SceneManager.LoadScene("menu");
        }else{
            errortxt.gameObject.SetActive(true);
            errortxt.text = www.text;
        }
 
    }
    

}

