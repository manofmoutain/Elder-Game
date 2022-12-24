using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class disdatebtn : MonoBehaviour
{
    public datebtnnum data = new datebtnnum();
    // Start is called before the first frame update
    void Start()
    {
        Text datetext = this.transform.GetChild(0).GetComponent<Text>();
        datetext.text = data.date + ""; //轉換型態，從int轉換成字串

        CanvasGroup canvas = this.GetComponent<CanvasGroup>();
        canvas.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
