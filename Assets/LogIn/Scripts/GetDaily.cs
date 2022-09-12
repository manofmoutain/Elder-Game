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
    string url = "http://ring.nutc.edu.tw/garmin/Joyce/get_Daily.php";

    public TMP_Text[] Membertxt = new TMP_Text[7];
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
      //matchHeight();
    }
    IEnumerator GetDailies()
    {
        account=SignIn.account;
        password=SignIn.password;
        //account="qqnice@gm.nutc.edu.tw";
        //password="QQnice22";
        //查資料  userid 
        WWWForm form = new WWWForm();
        form.AddField("action", "GetDaily");
        form.AddField("account", "jimmy880316@gmail.com");
        form.AddField("password", "jimmy1999");
        WWW www = new WWW(url, form);

        yield return www;

        var received_data = Regex.Split(www.text, "</next>");
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
        }else{
            Debug.Log(www.text);
            //運動 >=30min 達標
            Membertxt[0].text = received_data[0] + "分鐘";
            if (int.Parse(received_data[1])>=30){
                Membertxt[0].color = new Color32(45,166,0,255);
            }else{
                Membertxt[0].color = new Color32(73,72,67,255);
            }
            //睡眠 >6hr 達標
            if (received_data[1]=="0"){ //60分鐘以內
                Membertxt[1].text = received_data[2] + "分鐘";
                Membertxt[0].color = new Color32(73,72,67,255);
            }else{
                Membertxt[1].text = received_data[1] + "小時" + received_data[2]+"分鐘";
                if (int.Parse(received_data[1])>=6){
                    Membertxt[1].color = new Color32(45,166,0,255);
                }else{
                    Membertxt[1].color = new Color32(73,72,67,255);
                }
            }
            //生活探測器
            Membertxt[3].text = "未完成";
            //健康小學堂
            Membertxt[4].text = "未完成";
            //社交小達人
            Membertxt[5].text = "未完成";
            //闖關遊戲
            Membertxt[6].text = "未完成";
        }
        

        
        //int cnt = (received_data.Length) / 4;
        /*for (int i = 0; i < cnt; i++)
        {
            myfieldid[i] = received_data[3 * i];
            end[i] = received_data[3 * i + 1 ];
            fweeding[i] = received_data[3 * i + 2];
        }*/
        //Debug.Log(cnt);
    }

    //set content size
    public void matchHeight()
    {
        //var height = Dailytxt.GetComponent<RectTransform>().rect.height+100;
        //content.sizeDelta=new Vector2(0, height);
    }
}
