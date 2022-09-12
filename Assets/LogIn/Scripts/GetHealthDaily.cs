using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class GetHealthDaily : MonoBehaviour
{
    string url = "http://ring.nutc.edu.tw/garmin/Joyce/get_HealthDaily.php";

    public TMP_Text[] Membertxt = new TMP_Text[5];
    private string account;
    private string password;
    

    void Start()
    {
        StartCoroutine(GetHealthDailies());
    }
    public void gostart()
    {
        Debug.Log("gostart");

        StartCoroutine(GetHealthDailies());
        
    }
    IEnumerator GetHealthDailies()
    {
        account=SignIn.account;
        password=SignIn.password;
        //查資料  userid 
        WWWForm form = new WWWForm();
        form.AddField("action", "GetHealthDaily");
        form.AddField("account", account);
        form.AddField("password", password);
        WWW www = new WWW(url, form);

        yield return www;
        var received_data = Regex.Split(www.text, "</next></next>");
        if (!string.IsNullOrEmpty(www.error) || received_data[0] == "0" )
        {
            Debug.Log(www.error);
            Membertxt[0].text = "心率 : 無資料";
            Membertxt[1].text = "最大心跳 : 無資料";
            Membertxt[2].text = "最小心跳 : 無資料";
            Membertxt[3].text = "步數 : 0步";
            Membertxt[4].text = "壓力指數 : 無資料";
            Membertxt[5].text = "差4500步";
            Membertxt[6].text = "";
            Debug.Log(www.text);
        }
        else{
            Debug.Log(www.text);
            
            
            Membertxt[0].text = "心率 : " + received_data[0];
            Membertxt[1].text = "最大心跳 : " + received_data[1];
            Membertxt[2].text = "最小心跳 : " + received_data[2];
            Membertxt[3].text = "步數 : " + received_data[3] + "步";
            Membertxt[4].text = "壓力指數 : " + received_data[4];
            // Debug.Log(int.Parse(received_data[1]));
            Membertxt[5].text = "差" + (4500-int.Parse(received_data[1])) + "步";
            if (Int32.Parse(received_data[4])<26){
                Membertxt[6].text = "休息";
                Membertxt[6].color = new Color32(45,166,0,255);
            }else if (Int32.Parse(received_data[4])<51){
                Membertxt[6].text = "低度壓力";
                Membertxt[6].color = new Color32(45,166,0,255);
            }else if (Int32.Parse(received_data[4])<76){
                Membertxt[6].text = "中度壓力";
                Membertxt[6].color = new Color32(219,94,60,255);
            }else{
                Membertxt[4].text = "高度壓力";
                Membertxt[6].color = new Color32(255,83,83,255);
            }
        }

    }
}