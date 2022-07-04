using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class GetDaily : MonoBehaviour
{
    string url = "http://ring.nutc.edu.tw/garmin/Joyce/sel.php";

    public TMP_Text Dailytxt;
    private string account;
    private string password;

    public RectTransform content;

    void Start()
    {
        StartCoroutine(GetDailies());
    }
    public void gostart()
    {
        Debug.Log("gostart");

        StartCoroutine(GetDailies());
        
    }
    void Update() {
      matchHeight();
    }
    IEnumerator GetDailies()
    {
        account=SignIn.account;
        password=SignIn.password;
        account="qqnice@gm.nutc.edu.tw";
        password="QQnice22";
        //查資料  userid 
        WWWForm form = new WWWForm();
        form.AddField("action", "GetDaily");
        form.AddField("account", account);
        form.AddField("password", password);
        WWW www = new WWW(url, form);

        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
        }
        Debug.Log(www.text);

        Dailytxt.text = www.text;
        Dailytxt.text = www.text.Replace("</next>", "\n");
        var received_data = Regex.Split(www.text, "</next>");
        int cnt = (received_data.Length) / 4;
        /*for (int i = 0; i < cnt; i++)
        {
            myfieldid[i] = received_data[3 * i];
            end[i] = received_data[3 * i + 1 ];
            fweeding[i] = received_data[3 * i + 2];
        }*/
        Debug.Log(cnt);
    }

    //set content size
    public void matchHeight()
    {
        var height = Dailytxt.GetComponent<RectTransform>().rect.height+100;
        content.sizeDelta=new Vector2(0, height);
    }
}
