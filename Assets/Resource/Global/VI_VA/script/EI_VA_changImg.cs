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
        [SerializeField] List<string> sprites;
        [SerializeField] Sprite red;
        [SerializeField] Sprite green;
        private EI_VA_BGTimer BGT;
        [SerializeField] string colorString;
        [SerializeField] List<Sprite> spriter;
        private int i=0;
        private void Start()
        {
            BGT = BGTimer.AddComponent<EI_VA_BGTimer>();
            string value = sprites[Random.Range(0, 2)];
            List<string> spriteList=value.Split(' ').ToListPooled();
            
            foreach (string e in spriteList) {
                
                Debug.Log(e+ colorString);
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

            BGT.timeSet(true);
            new WaitForSeconds(0.75f);
            i++;
            change(spriter[i]);
            BGT.startTimer();
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
