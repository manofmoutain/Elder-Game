using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arrowFlip : MonoBehaviour
{
    public GameObject calander;
    public Image arrow;
    public Sprite upSprite;
    public Sprite downSprite;
    public int flip;
    // Start is called before the first frame update
    void Start()
    {
        flip = 1;
        arrow.sprite = downSprite;
    }

    public void click(){
        flip *= -1;
        if(flip > 0){
            arrow.sprite = downSprite;
            calander.SetActive(false);
        }else{
            arrow.sprite = upSprite;
            calander.SetActive(true);
            GameObject.Find("日期 #").GetComponent<calander>().appealdate();
        }
        
    }
}
