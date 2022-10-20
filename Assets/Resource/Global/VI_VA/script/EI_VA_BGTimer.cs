using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EI_VA
{
public class EI_VA_BGTimer : MonoBehaviour
{
        // Start is called before the first frame update
        
        public List<float> currectTime;
        public List<float> mistakeTime;
        private bool stop = false;
        private float timer;
        private Coroutine c1, c2;
        void startBGTime() { 
              
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flag">true=currect;false=mistake</param>
        public void timeSet(bool flag)
        {
            if (flag)
            {
                currectTime.Add(getTime());
            }
            else
            {
                mistakeTime.Add(getTime());
            }
        }
        public void startTimer()
        {
            timer = 0;
            c1 = StartCoroutine(Timer());
        }
        public float getTime()
        {
            stop = true;
            StopCoroutine(c1);
            c1 = null;
            return timer;
        }
        public IEnumerator Timer()
        {
            while (!stop)
            {
                timer += Time.deltaTime;
                if (timer <= 1) {
                    stop = true;
                    
                    break;
                }
                Debug.Log(timer);
                yield return null;
            }
            yield return null;

        }
    }

}
