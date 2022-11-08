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
        TMP_Text datetxt = GameObject.Find("selDate").GetComponent<TMP_Text>(); //�q�L�W�r�A���e��������������
        datetxt.text = DateTime.Now.Year + "�~" + DateTime.Now.Month + "��" + DateTime.Now.Day + "�� " + weekENtoZW(DateTime.Now.DayOfWeek.ToString());
        
    }
    public void gostart(string date)
    {
        Debug.Log("gostart");
        StartCoroutine(GetDailies(date));
        
        
    }
    private string weekENtoZW(string week){
        Debug.Log(week);
        if(week == "Monday"){
            return  "�P�@";
        }else if(week == "Tuesday"){
            return "�P�G";
        }else if(week == "Wednesday"){
            return "�P�T";
        }else if(week == "Thursday"){
            return "�P�|";
        }else if(week == "Friday"){
           return "�P��";
        }else if(week == "Saturday"){
            return "�P��";
        }else{
            return "�P��";
        }
    }
    void Update() {
      //matchHeight();
    }
    IEnumerator GetDailies(string targetdate)
    {
        account=SignIn.account;
        password=SignIn.password;
        
        //�d���  userid 
        WWWForm form = new WWWForm();
        form.AddField("action", "GetDaily");
        form.AddField("account", account);
        form.AddField("password", password);
        form.AddField("date", targetdate);

        WWW www = new WWW(url, form);

        yield return www;

        var received_data = Regex.Split(www.text, "</next>");
        if (!string.IsNullOrEmpty(www.error)){
            Debug.Log(www.error);//�L���
        }else{
            Debug.Log(www.text);
            //debugtxt.text = www.text;


            //�B�� >=30min �F��
            Color red = new Color32(207, 102, 101, 255);
            Color green = new Color32(109,193,81,255);
            if (int.Parse(received_data[0])>=30){
                Membertxt[0].text = received_data[0];
                progessCircle[0].GetComponent<ProgressBar>().GetCurrentFillCircle(30, 30, green);
            }else{
                Membertxt[0].text = received_data[0];
                progessCircle[0].GetComponent<ProgressBar>().GetCurrentFillCircle(30, int.Parse(received_data[0]), red);
            }

            //�ίv >6hr �F��
            if (float.Parse(received_data[1])>=6.0){
                Membertxt[1].text = received_data[1];
                progessCircle[1].GetComponent<ProgressBar>().GetCurrentFillCircle(6, 6, green);
            }else{
                Membertxt[1].text = received_data[1];
                progessCircle[1].GetComponent<ProgressBar>().GetCurrentFillCircle(6, float.Parse(received_data[1]), red);
            }    

            //�ͬ������� ���d�p�ǰ� ����p�F�H
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
