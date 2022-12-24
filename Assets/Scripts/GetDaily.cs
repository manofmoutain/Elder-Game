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
    public TMP_Text[] Membertxt = new TMP_Text[6];
    //public TMP_Text debugtxt;
    
    public GameObject[] progessCircle;
    public Image[] doneImg;
    public Sprite[] sprite;
    private string account;
    private string password;

    //public RectTransform content;

    void Start()
    {
        StartCoroutine(GetDailies(DateTime.Now.Date.ToString("yyyy-MM-dd")));
        TMP_Text datetxt = GameObject.Find("selDate").GetComponent<TMP_Text>(); //通過名字，找到畫面中的相應物件
        datetxt.text = DateTime.Now.Year + "年" + DateTime.Now.Month + "月" + DateTime.Now.Day + "日 " + weekENtoZW(DateTime.Now.DayOfWeek.ToString());
        
    }
    public void gostart(string date)
    {
        Debug.Log("gostart");
        StartCoroutine(GetDailies(date));
        
        
    }
    private string weekENtoZW(string week){
        Debug.Log(week);
        if(week == "Monday"){
            return  "周一";
        }else if(week == "Tuesday"){
            return "周二";
        }else if(week == "Wednesday"){
            return "周三";
        }else if(week == "Thursday"){
            return "周四";
        }else if(week == "Friday"){
           return "周五";
        }else if(week == "Saturday"){
            return "周六";
        }else{
            return "周日";
        }
    }
    void Update() {
      //matchHeight();
    }
    IEnumerator GetDailies(string targetdate)
    {
        account=SignIn.account;
        password=SignIn.password;
        
        //查資料  userid 
        WWWForm form = new WWWForm();
        form.AddField("action", "GetDaily");
        form.AddField("account", account);
        form.AddField("password", password);
        form.AddField("date", targetdate);

        WWW www = new WWW(url, form);

        yield return www;

        var received_data = Regex.Split(www.text, "</next>");
        if (!string.IsNullOrEmpty(www.error)){
            Debug.Log(www.error);//無資料
        }else{
            Debug.Log(www.text);
            //debugtxt.text = www.text;


            //運動 >=30min 達標
            Color red = new Color32(207, 102, 101, 255);
            Color green = new Color32(109,193,81,255);
            if (int.Parse(received_data[0])>=30){
                Membertxt[0].text = received_data[0];
                progessCircle[0].GetComponent<ProgressBar>().GetCurrentFillCircle(30, 30, green);
            }else{
                Membertxt[0].text = received_data[0];
                progessCircle[0].GetComponent<ProgressBar>().GetCurrentFillCircle(30, int.Parse(received_data[0]), red);
            }

            //睡眠 >6hr 達標
            if (float.Parse(received_data[1])>=6.0){
                Membertxt[1].text = received_data[1];
                progessCircle[1].GetComponent<ProgressBar>().GetCurrentFillCircle(6, 6, green);
            }else{
                Membertxt[1].text = received_data[1];
                progessCircle[1].GetComponent<ProgressBar>().GetCurrentFillCircle(6, float.Parse(received_data[1]), red);
            }    

            //生活探測器 健康小學堂 社交小達人
            for(int i = 0; i<3 ; i++){
                if (int.Parse(received_data[i+2])>0){
                    doneImg[i].sprite = sprite[1];
                }else{
                    doneImg[i].sprite = sprite[0];
                }
            }
        }

    }

    //set content size
    /*public void matchHeight()
    {
        //var height = Dailytxt.GetComponent<RectTransform>().rect.height+100;
        //content.sizeDelta=new Vector2(0, height);
    }*/
}
