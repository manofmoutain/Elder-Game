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
    public TMP_Text debugtxt;
    public TMP_Text datetxt;
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
        //�d���  userid 
        WWWForm form = new WWWForm();
        form.AddField("action", "GetDaily");
        form.AddField("account", account);
        form.AddField("password", password);
        datetxt.text = DateTime.Now.Date.ToString("yyyy-MM-dd");
        form.AddField("date", DateTime.Now.Date.ToString("yyyy-MM-dd"));
        WWW www = new WWW(url, form);

        yield return www;

        var received_data = Regex.Split(www.text, "</next>");
        if (!string.IsNullOrEmpty(www.error)){
            Debug.Log(www.error);
            debugtxt.text = www.error;
        }else{
            Debug.Log(www.text);
            debugtxt.text = www.text;
            //�B�� >=30min �F��
            
            if(int.Parse(received_data[1])==0){
                Membertxt[0].text = "�L���";
            }else if (int.Parse(received_data[1])>=30){
                Membertxt[0].text = received_data[0] + "����";
                Membertxt[0].color = new Color32(45,166,0,255);
            }else{
                Membertxt[0].text = received_data[0] + "����";
                Membertxt[0].color = new Color32(73,72,67,255);
            }
            //�ίv >6hr �F��
            if (received_data[1]=="0" & received_data[2]=="00"){ //�L�^��
                Membertxt[1].text = "�L���";
                Membertxt[0].color = new Color32(73,72,67,255);
            }else if (received_data[1]=="0"){ //60�����H��
                Membertxt[1].text = received_data[2] + "����";
                Membertxt[0].color = new Color32(73,72,67,255);
            }else if(received_data[2]=="00"){ //��n�p�� �S������
                Membertxt[1].text = received_data[1] + "�p��";
                if (int.Parse(received_data[1])>=6){
                    Membertxt[1].color = new Color32(45,166,0,255);
                }else{
                    Membertxt[1].color = new Color32(73,72,67,255);
                }
            }else{
                Membertxt[1].text = received_data[1] + "�p��" + received_data[2]+"����";
                if (int.Parse(received_data[1])>=6){
                    Membertxt[1].color = new Color32(45,166,0,255);
                }else{
                    Membertxt[1].color = new Color32(73,72,67,255);
                }
            }
            //�ͬ������� ���d�p�ǰ� ����p�F�H �ʸ��ɶ� 1���F��
            for(int i = 2; i<6 ; i++){
                if (int.Parse(received_data[i])>0){
                    Membertxt[i].color = new Color32(45,166,0,255);
                    Membertxt[i].text = "�w����";
                }else{
                    Membertxt[i].color = new Color32(73,72,67,255);
                    Membertxt[i].text = "������";
                }
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
    /*public void matchHeight()
    {
        //var height = Dailytxt.GetComponent<RectTransform>().rect.height+100;
        //content.sizeDelta=new Vector2(0, height);
    }*/
    }
}
