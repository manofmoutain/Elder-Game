using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class toggleDayWeek : MonoBehaviour
{
    public GameObject PanelDay;
    public GameObject PanelWeek;
    public Toggle Toggleday;
    public Toggle Toggleweek;


    public void dayValueChange(){
        if(Toggleday.GetComponent<Toggle>().isOn){
            PanelDay.SetActive(true);
            PanelWeek.SetActive(false);
            GetComponent<GetDaily>().gostart(DateTime.Now.ToString());
        }else{
            PanelDay.SetActive(false);
            PanelWeek.SetActive(true);
            GetComponent<GetWeekRecord>().gostart();
        }
    }
}
