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
    public TMP_Text datetxt;
    public TMP_Text[] Valuetxt = new TMP_Text[5];
    public GameObject[] Progressbar;
    public Image[] BadgeImg;
    public Image[] rankImg;
    public Sprite[] BadgedoneSprite;
    public Sprite[] progressdoneSprite;
    public Sprite[] rankSprite;
    

    private string account;
    private string password;
    
    void Start()
    {
        
    }
    void Update(){}
    public void gostart()
    {
        Debug.Log("gostart");
        setDate();
        StartCoroutine(GetWeekRecords());
    }
    private void setDate(){
        DateTime begin = DateTime.Now.AddDays(-6);
        DateTime finish = DateTime.Now;
        datetxt.text = begin.Year + "年" + begin.Month + "月" + begin.Day + "日 " + weekENtoZW(begin.DayOfWeek.ToString()) + "\n至\n" + finish.Year + "年" + finish.Month + "月" + finish.Day + "日 " + weekENtoZW(finish.DayOfWeek.ToString());
    }
    private string weekENtoZW(string week){
        Debug.Log(week);
        if(week == "Monday"){
            return  "週一";
        }else if(week == "Tuesday"){
            return "週二";
        }else if(week == "Wednesday"){
            return "週三";
        }else if(week == "Thursday"){
            return "週四";
        }else if(week == "Friday"){
           return "週五";
        }else if(week == "Saturday"){
            return "週六";
        }else{
            return "週日";
        }
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
        // 5項指標的等級 與 顏色
        Color red = new Color32(244, 32, 38, 255);
        Color yellow = new Color32(242, 154, 20, 255);
        Color green = new Color32(110,192,81,255);

        var received_data = Regex.Split(www.text, "</next>");
        //var received_data = Regex.Split("99</next>7.5</next>8</next>10</next>2", "</next>");

        if (string.IsNullOrEmpty(www.text)){
            Debug.Log(www.error);
            debugtxt.text = www.error;

            for(int i =0; i<5 ; i++){
                Valuetxt[i].text = "0";
                Progressbar[i].GetComponent<ProgressBar>().GetCurrentFillRewardBar(150,0,red,progressdoneSprite[0]);
                rankImg[i].sprite = rankSprite[0];
            }
            
        }else{
            Debug.Log(www.text);
            debugtxt.text = www.text;

            // 5項指標的值
            for (int i = 0; i < 5; i++){
                Valuetxt[i].text = received_data[i];
            }
            
            // 0運動 改顏色 >=150(優秀) >=75(良好) <75(再加油)
            if(Int32.Parse(received_data[0])>=150){
                BadgeImg[0].sprite = BadgedoneSprite[0];
                rankImg[0].sprite = rankSprite[2];
                Progressbar[0].GetComponent<ProgressBar>().GetCurrentFillRewardBar(150,150,green,progressdoneSprite[1]);
            }else if(Int32.Parse(received_data[0])>=75){
                rankImg[0].sprite = rankSprite[1];
                Progressbar[0].GetComponent<ProgressBar>().GetCurrentFillRewardBar(150,Int32.Parse(received_data[0]),yellow,progressdoneSprite[0]);
            }else{
                rankImg[0].sprite = rankSprite[0];
                Progressbar[0].GetComponent<ProgressBar>().GetCurrentFillRewardBar(150,Int32.Parse(received_data[0]),red,progressdoneSprite[0]);
            }
            // 1睡眠 改顏色 >=7(優秀) >=6(良好) 0<6小時(再加油)
            if(float.Parse(received_data[0])>=7){
                BadgeImg[1].sprite = BadgedoneSprite[1];
                rankImg[1].sprite = rankSprite[2];
                Progressbar[1].GetComponent<ProgressBar>().GetCurrentFillRewardBar(7,7,green,progressdoneSprite[1]);
            }else if(float.Parse(received_data[0])>=6){
                rankImg[1].sprite = rankSprite[1];
                Progressbar[1].GetComponent<ProgressBar>().GetCurrentFillRewardBar(7,float.Parse(received_data[1]),yellow,progressdoneSprite[0]);
            }else{
                rankImg[1].sprite = rankSprite[0];
                Progressbar[1].GetComponent<ProgressBar>().GetCurrentFillRewardBar(7,float.Parse(received_data[1]),red,progressdoneSprite[0]);
            }
            // 2生 3健 4社 改顏色 567(優秀) 34(良好) 012(再加油) 
            for(int i = 2 ; i<5 ; i++){ 
                if(Int32.Parse(received_data[i])>=5){
                    BadgeImg[i].sprite = BadgedoneSprite[i];
                    rankImg[i].sprite = rankSprite[2];
                    Progressbar[i].GetComponent<ProgressBar>().GetCurrentFillRewardBar(7,7,green,progressdoneSprite[1]);
                }else if(Int32.Parse(received_data[i])>=3){
                    rankImg[i].sprite = rankSprite[1];
                    Progressbar[i].GetComponent<ProgressBar>().GetCurrentFillRewardBar(7,Int32.Parse(received_data[i]),yellow,progressdoneSprite[0]);
                }else{
                    rankImg[i].sprite = rankSprite[0];
                    Progressbar[i].GetComponent<ProgressBar>().GetCurrentFillRewardBar(7,Int32.Parse(received_data[i]),red,progressdoneSprite[0]);
                }
            }
            
        }   
    }
}
