using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class DailyLast : MonoBehaviour
{
    public GameObject[] Progressbar = new GameObject[5];
    public TMP_Text[] Valuetxt = new TMP_Text[5];
    public TMP_Text[] Ranktxt = new TMP_Text[5];
    string url = "http://ring.nutc.edu.tw/garmin/Joyce/get_Daily.php";
    private string account;
    private string password;

    // Start is called before the first frame update
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
        //查資料  userid 
        WWWForm form = new WWWForm();
        form.AddField("action", "GetDaily");
        form.AddField("account", "jimmy880316@gmail.com");
        form.AddField("password", "jimmy1999");
        WWW www = new WWW(url, form);

        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
            Valuetxt[0].text = "運動 : 無資料";
            Valuetxt[1].text = "睡眠 : 無資料";
            Valuetxt[2].text = "生活探測器 : 無資料";
            Valuetxt[3].text = "社交小達人 : 無資料";
            Valuetxt[4].text = "闖關遊戲 : 無資料";
            Debug.Log(www.text);
        }
        else{
            Debug.Log(www.text);
            var received_data = Regex.Split(www.text, "</next>");
            
            Valuetxt[0].text = received_data[0];
            //Valuetxt[1].text = received_data[1];
            //Valuetxt[2].text = "壓力指數 : " + received_data[2];
            /* Debug.Log(int.Parse(received_data[1]));
            Valuetxt[3].text = "差" + (6000-int.Parse(received_data[1])) + "步";
            if (Int32.Parse(received_data[2])<26){
                Valuetxt[4].text = "低度壓力";
            }else if (Int32.Parse(received_data[2])<51){
                Valuetxt[4].text = "中度壓力";
            }else{
                Valuetxt[4].text = "高度壓力";
            }*/
        }
    }
}
