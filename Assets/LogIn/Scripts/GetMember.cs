using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class GetMember : MonoBehaviour
{
    string url = "http://ring.nutc.edu.tw/garmin/Joyce/get_Member.php";

    public TMP_Text[] Membertxt = new TMP_Text[14];
    private string account;
    private string password;

    void Start()
    {
        StartCoroutine(GetMembers());
    }
    public void gostart()
    {
        Debug.Log("gostart");

        StartCoroutine(GetMembers());
        
    }
    IEnumerator GetMembers()
    {
        account=SignIn.account;
        password=SignIn.password;
        //查資料  userid 
        WWWForm form = new WWWForm();
        form.AddField("action", "GetMember");
        form.AddField("account", account);
        form.AddField("password", password);
        WWW www = new WWW(url, form);

        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
        }
        Debug.Log(www.text);

        var received_data = Regex.Split(www.text, "</next></next>");
        
        for (int i = 0; i < 6; i++)
        {
            Membertxt[i].text = received_data[i];
        }
        

    }
}
