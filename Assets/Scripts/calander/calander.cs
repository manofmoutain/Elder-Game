using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class calander : MonoBehaviour
{
    string url = "http://ring.nutc.edu.tw/garmin/Joyce/get_Daily.php";
    public DateTime rightnow = DateTime.Now; //今天
    public DateTime clickDateTime = DateTime.Now; //今天
    public GameObject CalPanel;
    public GameObject arrow;
    public string dateString;
    public static int clickyear; //選擇的日期
    public static int clickmonth; //選擇的日期
    public static int clickdate; //選擇的日期
    // Start is called before the first frame update
    void Start()
    {
        clickyear = int.Parse(rightnow.Date.ToString("yyyy"));
        clickmonth = int.Parse(rightnow.Date.ToString("MM"));
        clickdate = int.Parse(rightnow.Date.ToString("dd"));

        appealdate();
        
        TMP_Text datetxt = GameObject.Find("selDate").GetComponent<TMP_Text>(); //通過名字，找到畫面中的相應物件
        datetxt.text = DateTime.Now.Year + "年" + DateTime.Now.Month + "月" + DateTime.Now.Day + "日 " + weekENtoZW(DateTime.Now.DayOfWeek.ToString());

        /*Button reservbtn = GameObject.Find("預約btn").GetComponent<Button>();
        reservbtn.GetComponent<Button>().onClick.AddListener(delegate {
            Text hinttext = GameObject.Find("預約完成提示文字").GetComponent<Text>(); //通過名字，找到畫面中的相應物件
            hinttext.text = rightnow.Year+ "/" + rightnow.Month + "/" + clickdate + "  已預約參觀";

            clickyear = rightnow.Year;
            clickmonth = rightnow.Month;
            gostart();
            //Image okimg = GameObject.Find("OkImg").GetComponent<Image>(); //通過名字，找到畫面中的相應物件
            
        });*/
        
    }
    public void onclicklastmonth() {
        rightnow = rightnow.AddMonths(-1);
        appealdate();
    }
    public void onclicknextmonth()
    {
        rightnow = rightnow.AddMonths(1);
        appealdate();
    }
    public void onclicklastyear() {
        rightnow = rightnow.AddYears(-1);
        appealdate();
    }
    public void onclicknextyear()
    {
        rightnow = rightnow.AddYears(1);
        appealdate();
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
    public void appealdate() {  //顯示日期
        Debug.Log("private void appealdate()");

        //arrow.GetComponent<Transform>().Rotate(0, 0, 180);

        // 把所有已經存在的按鈕刪除
        int all = this.transform.childCount; //所有日期按鈕數
        for (int i = all-1; i >-1; i--) {
            Transform del = this.transform.GetChild(i); //一個帶刪除的按鈕
            Destroy(del.gameObject);
        }

        TMP_Text yeartext = GameObject.Find("Text (TMP) year").GetComponent<TMP_Text>(); //通過名字，找到畫面中的相應物件
        TMP_Text monthtext = GameObject.Find("Text (TMP) month").GetComponent<TMP_Text>(); //通過名字，找到畫面中的相應物件
        yeartext.text = rightnow.Year+"年 ";
        monthtext.text = rightnow.Month+"月";

        GameObject datebtn = Resources.Load<GameObject>("Prefabs/日期");
        GameObject disdatebtn = Resources.Load<GameObject>("Prefabs/dis日期");

        DateTime first = rightnow.AddDays(1 - rightnow.Day); //first此變數為本月第一天
        DayOfWeek week = first.DayOfWeek; //本月第一天的星期
        for (int i = 0; i < (int)week; i++)
        {
            GameObject newdate = Instantiate(disdatebtn);
            newdate.transform.parent = this.transform;
            newdate.transform.localScale= new Vector3(1,1,1);
        }
        DateTime nextmonth = rightnow.AddMonths(1); //下個月的今天
        DateTime nextfirst = nextmonth.AddDays(1 - nextmonth.Day); //下個月一號日期
        DateTime last = nextfirst.AddDays(-1); //本月最後一天
        
        for (int i = 0; i < last.Day; i++)
        {
            GameObject newdate = Instantiate(datebtn);
            datebtn com = newdate.GetComponent<datebtn>();
            com.data = new datebtnnum(i + 1);
            newdate.transform.parent = this.transform;
            newdate.transform.localScale= new Vector3(1,1,1);
            
            
            newdate.GetComponent<Button>().onClick.AddListener(delegate {
                clickyear = rightnow.Year;
                clickmonth = rightnow.Month;
                clickdate = com.data.date;
                Debug.Log("按下按鈕取 年 月 日");
                Debug.Log(clickyear);
                Debug.Log(clickmonth);
                Debug.Log(clickdate);
                Debug.Log(com.data.date);
                Debug.Log(rightnow.Day);
                dateString = rightnow.Date.ToString("yyyy-MM-")+clickdate;
                Debug.Log(rightnow.Day);

                newdate.transform.GetChild(0).GetComponent<Text>().color = new Color(255, 255, 255, 255);//選中的改文字顏色
                
                TMP_Text datetxt = GameObject.Find("selDate").GetComponent<TMP_Text>(); //通過名字，找到畫面中的相應物件
                DateTime weekName = new DateTime(clickyear, clickmonth, clickdate);
                datetxt.text = clickyear+ "年" + clickmonth + "月" +clickdate + "日 " + weekENtoZW(weekName.DayOfWeek.ToString());
                Debug.Log(clickyear + "年" + clickmonth + "月" + clickdate + "日 " + weekENtoZW(weekName.DayOfWeek.ToString()));
                Debug.Log(datetxt.text);

                CalPanel.SetActive(false);

                //呼叫另一個腳本
                GameObject.Find("Script Object").GetComponent<GetDaily>().gostart(clickyear+ "-" + clickmonth + "-" +clickdate);
                GameObject.Find("Script Object").GetComponent<arrowFlip>().click();


            });

            // 已經選取 預設今天
            if( i == clickdate-1 && clickmonth == rightnow.Month && clickyear == rightnow.Year){
                newdate.transform.GetChild(0).GetComponent<Text>().color = new Color(255, 255, 255, 255); //改文字顏色
                newdate.GetComponent<Button>().interactable = false; //改色
            }
        }
        
    }
    
    public void todayclick(){
        clickyear = int.Parse(rightnow.Date.ToString("yyyy"));
        clickmonth = int.Parse(rightnow.Date.ToString("MM"));
        clickdate = int.Parse(rightnow.Date.ToString("dd"));
        appealdate();
        TMP_Text datetxt = GameObject.Find("selDate").GetComponent<TMP_Text>(); //通過名字，找到畫面中的相應物件
        datetxt.text = DateTime.Now.Year + "年" + DateTime.Now.Month + "月" + DateTime.Now.Day + "日 " + weekENtoZW(DateTime.Now.DayOfWeek.ToString());
        CalPanel.SetActive(false);
        GameObject.Find("Script Object").GetComponent<GetDaily>().gostart(DateTime.Now.Date.ToString("yyyy-MM-dd"));
    }
}
