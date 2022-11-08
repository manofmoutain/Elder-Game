using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class GetHealthGroup : MonoBehaviour
{
    string url = "http://ring.nutc.edu.tw/garmin/Joyce/get_HealthDaily.php";

    public TMP_Text Titletxt;
    public TMP_Text date;
    public ScrollRect scrollRect;
    public GameObject[] content = new GameObject[3];
    public TMP_Text[] Membertxt = new TMP_Text[5]; // 步數 心率 最大 最小 壓力
    public GameObject progressCircle;
    private string account;
    private string password;


    void Start()
    {
        StartCoroutine(GetHealthGroups());
        string week = "";
        if(DateTime.Now.DayOfWeek.ToString() == "Monday"){
            week = "週一";
        }else if(DateTime.Now.DayOfWeek.ToString() == "Tuesday"){
            week = "週二";
        }else if(DateTime.Now.DayOfWeek.ToString() == "Wednesday"){
            week = "週三";
        }else if(DateTime.Now.DayOfWeek.ToString() == "Thursday"){
            week = "週四";
        }else if(DateTime.Now.DayOfWeek.ToString() == "Friday"){
            week = "週五";
        }else if(DateTime.Now.DayOfWeek.ToString() == "Saturday"){
            week = "週六";
        }else{
            week = "週日";
        }
        date.text = DateTime.Now.Year + " / " + DateTime.Now.Month + " / " + DateTime.Now.Day + "  " + week;
    }
    
    IEnumerator GetHealthGroups()
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
            Membertxt[0].text = "無資料";
            Membertxt[1].text = "無資料";
            Membertxt[2].text = "無資料";
            Membertxt[3].text = "無資料";
            Membertxt[4].text = "無資料";
            Debug.Log(www.text);
            progressCircle.GetComponent<ProgressBar>().GetCurrentFillValueCircle(5000, 0);
        }
        else{
            Debug.Log(www.text);
            Debug.Log(LoadScenes.healthNum);
            if(LoadScenes.healthNum == 0){//步數
                Membertxt[0].text = received_data[0];
                progressCircle.GetComponent<ProgressBar>().GetCurrentFillValueCircle(5000, Int32.Parse(received_data[0]));

            }else if(LoadScenes.healthNum == 1){//心率
                Membertxt[1].text = received_data[1];
                Membertxt[2].text = received_data[2];//最大
                Membertxt[3].text = received_data[3];//最小

            }else if(LoadScenes.healthNum == 2){//壓力指數
                Membertxt[4].text = received_data[4];
            }
            
        }
        //顯示哪個視窗Panel
        if(LoadScenes.healthNum == 0){//步數
            Titletxt.text = "今日步數";
            scrollRect.content = content[0].GetComponent<RectTransform>();
            content[0].SetActive(true);
            content[1].SetActive(false);
            content[2].SetActive(false);
        }else if(LoadScenes.healthNum == 1){//心率
            Titletxt.text = "心率監測";
            scrollRect.content = content[1].GetComponent<RectTransform>();
            content[0].SetActive(false);
            content[1].SetActive(true);
            content[2].SetActive(false);

        }else if(LoadScenes.healthNum == 2){//壓力指數
            Titletxt.text = "壓力指數";
            scrollRect.content = content[2].GetComponent<RectTransform>();
            content[0].SetActive(false);
            content[1].SetActive(false);
            content[2].SetActive(true);
        }

    }
}