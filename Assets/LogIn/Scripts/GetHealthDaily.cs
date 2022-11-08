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
    public GameObject progressbar;


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

        var received_data = Regex.Split(www.text, "</next>");
        if (!string.IsNullOrEmpty(www.error) || www.text == "0</next>0</next>0</next>0</next>0")
        {
            Debug.Log(www.error);
            Membertxt[0].text = "無資料"; //步數
            Membertxt[1].text = "無資料"; //心率
            Membertxt[2].text = "無資料"; //壓力指數
            Membertxt[3].text = "無資料"; //心率 評價
            Membertxt[4].text = "無資料"; //壓力指數 評價
            Membertxt[0].fontSize = 120;
            Membertxt[1].fontSize = 120;
            Membertxt[2].fontSize = 120;
            Debug.Log(www.text);
            progressbar.GetComponent<ProgressBar>().GetCurrentFillValue(5000, 0);
        }
        else{
            Debug.Log(www.text);
            
            
            Membertxt[0].text = received_data[0];//步數
            Membertxt[1].text = received_data[1];//心率
            Membertxt[2].text = received_data[4];//壓力指數
            // Debug.Log(int.Parse(received_data[1]));
            //Membertxt[5].text = "差" + (4500-int.Parse(received_data[1])) + "步";
            //步數判斷
            if(Int32.Parse(received_data[0])>5000){
                progressbar.GetComponent<ProgressBar>().GetCurrentFillValue(5000, 5000);
            }else{
                progressbar.GetComponent<ProgressBar>().GetCurrentFillValue(5000, Int32.Parse(received_data[0]));
            }
            //心率判斷
            if (Int32.Parse(received_data[1])<55){
                Membertxt[3].text = "心率過低";
                Membertxt[3].color = new Color32(255,83,83,255);
            }else if (Int32.Parse(received_data[1])>100){
                Membertxt[3].text = "心率過高";
                Membertxt[3].color = new Color32(255,83,83,255);
            }else{
                Membertxt[3].text = "心率正常";
                Membertxt[3].color = new Color32(45,166,0,255);
            }
            
            if (Int32.Parse(received_data[4])<26){
                Membertxt[4].text = "休息";
                Membertxt[4].color = new Color32(45,166,0,255);
            }else if (Int32.Parse(received_data[4])<51){
                Membertxt[4].text = "低度壓力";
                Membertxt[4].color = new Color32(45,166,0,255);
            }else if (Int32.Parse(received_data[4])<76){
                Membertxt[4].text = "中度壓力";
                Membertxt[4].color = new Color32(219,94,60,255);
            }else{
                Membertxt[4].text = "高度壓力";
                Membertxt[4].color = new Color32(255,83,83,255);
            }
        }

    }
}