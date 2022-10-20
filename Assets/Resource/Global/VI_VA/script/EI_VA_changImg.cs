using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace EI_VA
{
    public class EI_VA_changImg : MonoBehaviour
    {

        [SerializeField] Image img;
        [SerializeField] GameObject BGTimer;
        [SerializeField] GameObject counter;
        [SerializeField] List<string> sprites;
        [SerializeField] Sprite red;
        [SerializeField] Sprite green;
        private EI_VA_BGTimer BGT;
        private EI_VA_countScore EVS;
        [SerializeField] string colorString;
        [SerializeField] List<Sprite> spriter;
        private bool cORm;
        private int i=0;
        public int scoreflag = 0;
        private void Start()
        {

            BGT = BGTimer.GetComponent<EI_VA_BGTimer>();
            EVS = counter.GetComponent<EI_VA_countScore>();
            string value = sprites[Random.Range(0, 2)];
            List<string> spriteList=value.Split(' ').ToListPooled();
            for(int index = 0; index < 10; index++)
            {
                string e = spriteList[index];
                Debug.Log(e + colorString);
                if (e.Equals(colorString))
                {
                    spriter.Add(red);
                }
                else
                {
                    spriter.Add(green);
                }
            }
            
        }
        public void change(Sprite s)
        {
            
            img.sprite = s;
        }
        public void starter()
        {
            //BGT.startTimer();

            change(spriter[i]);
        }
        public void timeStop()
        {
            if (spriter[i] == red) { cORm = true; } else { cORm = false;}

            BGT.timeSet(cORm);
            CountScore();
        }
        public void CountScore()
        {
            Debug.Log(scoreflag);
            if (spriter[i] == red) { if (scoreflag != 2) { scoreflag = 0; } } else { if (scoreflag == 2) { scoreflag = 0; } else { scoreflag = 1; } }
            EVS.switchScore(scoreflag);
           
        }
            public void nextTest()
        {
            

            if (spriter[i + 1] != null)
            {
                i++;
                change(spriter[i]);
                BGT.startTimer();
            }
            else
            {
                gameFinal();
            }
        }
        private void gameFinal()
        {

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
