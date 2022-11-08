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
    public TMP_Text[] Membertxt = new TMP_Text[5]; // �B�� �߲v �̤j �̤p ���O
    public GameObject progressCircle;
    private string account;
    private string password;


    void Start()
    {
        StartCoroutine(GetHealthGroups());
        string week = "";
        if(DateTime.Now.DayOfWeek.ToString() == "Monday"){
            week = "�g�@";
        }else if(DateTime.Now.DayOfWeek.ToString() == "Tuesday"){
            week = "�g�G";
        }else if(DateTime.Now.DayOfWeek.ToString() == "Wednesday"){
            week = "�g�T";
        }else if(DateTime.Now.DayOfWeek.ToString() == "Thursday"){
            week = "�g�|";
        }else if(DateTime.Now.DayOfWeek.ToString() == "Friday"){
            week = "�g��";
        }else if(DateTime.Now.DayOfWeek.ToString() == "Saturday"){
            week = "�g��";
        }else{
            week = "�g��";
        }
        date.text = DateTime.Now.Year + " / " + DateTime.Now.Month + " / " + DateTime.Now.Day + "  " + week;
    }
    
    IEnumerator GetHealthGroups()
    {
        account=SignIn.account;
        password=SignIn.password;
        
        //�d���  userid 
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
            Membertxt[0].text = "�L���";
            Membertxt[1].text = "�L���";
            Membertxt[2].text = "�L���";
            Membertxt[3].text = "�L���";
            Membertxt[4].text = "�L���";
            Debug.Log(www.text);
            progressCircle.GetComponent<ProgressBar>().GetCurrentFillValueCircle(5000, 0);
        }
        else{
            Debug.Log(www.text);
            Debug.Log(LoadScenes.healthNum);
            if(LoadScenes.healthNum == 0){//�B��
                Membertxt[0].text = received_data[0];
                progressCircle.GetComponent<ProgressBar>().GetCurrentFillValueCircle(5000, Int32.Parse(received_data[0]));

            }else if(LoadScenes.healthNum == 1){//�߲v
                Membertxt[1].text = received_data[1];
                Membertxt[2].text = received_data[2];//�̤j
                Membertxt[3].text = received_data[3];//�̤p

            }else if(LoadScenes.healthNum == 2){//���O����
                Membertxt[4].text = received_data[4];
            }
            
        }
        //��ܭ��ӵ���Panel
        if(LoadScenes.healthNum == 0){//�B��
            Titletxt.text = "����B��";
            scrollRect.content = content[0].GetComponent<RectTransform>();
            content[0].SetActive(true);
            content[1].SetActive(false);
            content[2].SetActive(false);
        }else if(LoadScenes.healthNum == 1){//�߲v
            Titletxt.text = "�߲v�ʴ�";
            scrollRect.content = content[1].GetComponent<RectTransform>();
            content[0].SetActive(false);
            content[1].SetActive(true);
            content[2].SetActive(false);

        }else if(LoadScenes.healthNum == 2){//���O����
            Titletxt.text = "���O����";
            scrollRect.content = content[2].GetComponent<RectTransform>();
            content[0].SetActive(false);
            content[1].SetActive(false);
            content[2].SetActive(true);
        }

    }
}