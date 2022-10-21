using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace EI_ID
{
    public class EI_ID_changImg : MonoBehaviour
    {

        [SerializeField] Image img;

        [SerializeField] Image img2=null;
        [SerializeField] List<Sprite> spriter2=null;
        [SerializeField] GameObject BGTimer;
        [SerializeField] GameObject counter;
        [SerializeField] List<string> sprites;
        [SerializeField] Sprite red;
        [SerializeField] Sprite green;
        private EI_ID_BGTimer BGT;
        private EI_ID_countScore EVS;
        [SerializeField] string colorString;
        [SerializeField] List<Sprite> spriter;
        private bool cORm;
        private int i=0;
        public int scoreflag = 0;
        private void Start()
        {

            BGT = BGTimer.GetComponent<EI_ID_BGTimer>();
            EVS = counter.GetComponent<EI_ID_countScore>();
            string value = sprites[Random.Range(0, 2)];
            List<string> spriteList=value.Split(' ').ToListPooled();
            for(int index = 0; index < 10; index++)
            {
                string e = spriteList[index];
                Debug.Log(e + colorString);
                if (e.Equals(colorString))
                {
                    spriter.Add(red);
                    if (img2 != null) { spriter2.Add(green); }
                }
                else
                {
                    spriter.Add(green);
                    if (img2 != null) { spriter2.Add(red); }
                }
            }

            img.sprite = spriter[i];
        }
        public void change(Sprite s,bool side=false)
        {
            if (side) { img2.sprite = s; }
            else
            {
                img.sprite = s;
            }
        }
        public void timeStop(bool side)
        {
            if (side) { 
                if (spriter2[i] == red) { cORm = true; } else { cORm = false; }
            } else
            {
                if (spriter[i] == red) { cORm = true; } else { cORm = false;}
            }
            

            BGT.timeSet(cORm);
            CountScore(side);
        }
        public void CountScore(bool side)
        {
            Debug.Log(scoreflag);
            if (side)
            {
                if (spriter2[i] == red)
                {
                    
                        scoreflag = 0;
                }
                else
                {
                        scoreflag = 1;
                }
            }
            else
            {
                if (spriter[i] == red)
                {
                    if (scoreflag != 2)
                    {
                        scoreflag = 0;
                    }
                }
                else
                {
                    if (scoreflag == 2)
                    {
                        scoreflag = 0;

                    }
                    else
                    {
                        scoreflag = 1;
                    }
                }
            }
            
            EVS.switchScore(scoreflag);
        }
            public void nextTest()
        {
            if (i<spriter.Count-1)
            {
                i++;
                if (img2 != null) {change(spriter2[i],true); }
                
                change(spriter[i]);
                BGT.startTimer();
            }
            else
            {
                Debug.Log("Nexr");
                gameFinal();
            }
        }
        private void gameFinal()
        {
            if (EVS.totle >= 80)
            {
                SceneManager.LoadScene("0-AllMap");
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
        }
       
        /*
         * 
        if(start){
            BGTimer.startTimer
            if(!TimeLimit)
            if(Img click){
            BGTimer.getTimer

            changeimg
            } }
                    else 
                    changeimg
        waittimer(0.75f)
           BGTimer.startTimer
            if (!TimeLimit)
    if (click)
    {
        BGTimer.getTimer

        changeimg
            } }
}*/
    }

}
