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

    public TMP_Text[] Membertxt;
    public Image gender;
    public Sprite female;
    public Sprite male;
    private string account;
    private string password;

    void Start()
    {
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
        // 性別 名字 年齡 身高 體重 BMI
        var received_data = Regex.Split(www.text, "</next>");

        //性別
        if (received_data[0]=="女"){
            gender.sprite = female;
        }
        if (received_data[0]=="男"){
            gender.sprite = male;
        }
        //名字 年齡
        Membertxt[0].text = received_data[1] + " " + received_data[2] +"歲";
        
        //身高
        string[] subsHeight = received_data[3].Split('.');
        Membertxt[1].text = subsHeight[0];
        Membertxt[2].text = "." + subsHeight[1];
        //體重
        string[] subsWeight = received_data[4].Split('.');
        Membertxt[3].text = subsWeight[0];
        Membertxt[4].text = "." + subsWeight[1];
        //BMI
        string[] subsBMI = received_data[5].Split('.');
        Membertxt[5].text = subsBMI[0];
        Membertxt[6].text = "." + subsBMI[1];

    }
}
