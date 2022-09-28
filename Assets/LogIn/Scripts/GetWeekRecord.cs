using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GetWeekRecord : MonoBehaviour
{
    string url = "http://ring.nutc.edu.tw/garmin/Joyce/get_WeekRecord.php";
    public TMP_Text debugtxt;
    public TMP_Text[] Valuetxt = new TMP_Text[6];
    public TMP_Text[] Ranktxt = new TMP_Text[6];
    public GameObject BadgeGroup;
    public GameObject[] Progressbar;
    public Sprite done;
    public Sprite notyet;

    private string account;
    private string password;
    private int rewardcnt;
    private Image[] badges;
    void Start()
    {
        StartCoroutine(GetWeekRecords());
    }
    void Update(){}
    public void gostart()
    {
        Debug.Log("gostart");
        rewardcnt = 0;
        StartCoroutine(GetWeekRecords());
        
    }
    IEnumerator GetWeekRecords()
    {
        account=SignIn.account;
        password=SignIn.password;
        //查資料  userid 
        WWWForm form = new WWWForm();
        form.AddField("action", "GetWeekRecord");
        form.AddField("account", account);
        form.AddField("password", password);
        WWW www = new WWW(url, form);

        yield return www;

        var received_data = Regex.Split(www.text, "</next>");
        if (string.IsNullOrEmpty(www.error)){
            Debug.Log(www.error);
            debugtxt.text = www.error;
            Valuetxt[0].text = "運動  無資料";
            Valuetxt[1].text = "睡眠  無資料";
            Valuetxt[2].text = "生活探測器  0分";
            Valuetxt[3].text = "健康小學堂  0分";
            Valuetxt[4].text = "社交小達人  0分";
            Valuetxt[5].text = "動腦時間  0關";
            
            for(int i =0; i<6 ; i++){
                Ranktxt[i].gameObject.SetActive(false);
                Progressbar[i].GetComponent<ProgressBar>().GetCurrentFill(150,0,new Color32(45,166,0,255));
            }

        }else{
            Debug.Log(www.text);
            debugtxt.text = www.text;
            // 6項指標的值
            Valuetxt[0].text = "運動  " + received_data[0] + "分鐘";
            Valuetxt[1].text = "睡眠  " + received_data[1] + "小時";
            Valuetxt[2].text = "生活探測器  " + received_data[2] + "分";
            Valuetxt[3].text = "健康小學堂  " + received_data[3] + "分";
            Valuetxt[4].text = "社交小達人  " + received_data[4] + "分";
            Valuetxt[5].text = "動腦時間  " + received_data[5] + "關";

            // 6項指標的等級 與 顏色
            Color colorBlack = new Color32(73, 72, 67, 255);
            Color colorGreen = new Color32(45, 166, 0, 255);
            Color colorYellow = new Color32(255, 211, 69, 255);
            Color colorRed = new Color32(255, 83, 83, 255);
            // 0運動 改顏色 >=150(優秀) >=75(良好) <75(再加油)
            if(Int32.Parse(received_data[0])>=150){
                Ranktxt[0].text = "優秀";
                Ranktxt[0].color = colorGreen;
                Progressbar[0].GetComponent<ProgressBar>().GetCurrentFill(150,Int32.Parse(received_data[0]),colorGreen);
                rewardcnt++;
            }else if(Int32.Parse(received_data[0])>=150){
                Ranktxt[0].text = "良好";
                Ranktxt[0].color = colorBlack;
                Progressbar[0].GetComponent<ProgressBar>().GetCurrentFill(150,Int32.Parse(received_data[0]),colorYellow);
            }else{
                Ranktxt[0].text = "再加油";
                Ranktxt[0].color = colorRed;
                Progressbar[0].GetComponent<ProgressBar>().GetCurrentFill(150,Int32.Parse(received_data[0]),colorRed);
            }
            // 1睡眠 改顏色 >=7(優秀) >=6(良好) 0<6小時(再加油)
            if(Int32.Parse(received_data[5])>=7){
                Ranktxt[1].text = "優秀";
                Ranktxt[1].color = colorGreen;
                Progressbar[1].GetComponent<ProgressBar>().GetCurrentFill(7,7,colorGreen);
                rewardcnt++;
            }else if(Int32.Parse(received_data[5])>=6){
                Ranktxt[1].text = "良好";
                Ranktxt[1].color = colorBlack;
                Progressbar[1].GetComponent<ProgressBar>().GetCurrentFill(7,6,colorYellow);
            }else{
                Ranktxt[1].text = "再加油";
                Ranktxt[1].color = colorRed;
                Progressbar[1].GetComponent<ProgressBar>().GetCurrentFill(7,5,colorRed);
            }
            // 2生 3健 4社 改顏色 567(優秀) 34(良好) 012(再加油) 
            for(int i = 2 ; i<5 ; i++){ 
                if(Int32.Parse(received_data[i])>=5){
                    Ranktxt[i].text = "優秀";
                    Ranktxt[i].color = colorGreen;
                    rewardcnt++;
                    Progressbar[i].GetComponent<ProgressBar>().GetCurrentFill(7,Int32.Parse(received_data[i]),colorGreen);

                }else if(Int32.Parse(received_data[i])>=3){
                    Ranktxt[i].text = "良好";
                    Ranktxt[i].color = colorBlack;
                    Progressbar[i].GetComponent<ProgressBar>().GetCurrentFill(7,Int32.Parse(received_data[i]),colorYellow);

                }else{
                    Ranktxt[i].text = "再加油";
                    Ranktxt[i].color = colorRed;
                    Progressbar[i].GetComponent<ProgressBar>().GetCurrentFill(7,Int32.Parse(received_data[i]),colorRed);

                }
            }
            // 5動腦時間 改顏色 >=6(優秀) 345(良好) 012(再加油)
            if(Int32.Parse(received_data[5])>=6){ 
                Ranktxt[5].text = "優秀";
                Ranktxt[5].color = colorGreen;
                Progressbar[5].GetComponent<ProgressBar>().GetCurrentFill(6,Int32.Parse(received_data[5]),colorGreen);
                rewardcnt++;
            }else if(Int32.Parse(received_data[5])>=3){
                Ranktxt[5].text = "良好";
                Ranktxt[5].color = colorBlack;
                Progressbar[5].GetComponent<ProgressBar>().GetCurrentFill(6,Int32.Parse(received_data[5]),colorYellow);
            }else{
                Ranktxt[5].text = "再加油";
                Ranktxt[5].color = colorRed;
                Progressbar[5].GetComponent<ProgressBar>().GetCurrentFill(6,Int32.Parse(received_data[5]),colorRed);
            }
        }
        

        badges = BadgeGroup.GetComponentsInChildren<Image>();
        for(int i = 0 ; i<rewardcnt ; i++){
            badges[i].sprite = done;
        }
        for(int i = rewardcnt ; i<6 ; i++){
            badges[i].sprite = notyet;
        }
    }
        
}
