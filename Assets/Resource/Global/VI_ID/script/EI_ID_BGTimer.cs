using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EI_ID
{
public class EI_ID_BGTimer : MonoBehaviour
{
        // Start is called before the first frame update

        [SerializeField] GameObject ChangImager;

        private EI_ID_changImg EVC;
        public List<float> currectTime;
        public List<float> mistakeTime;
        private bool stop = false;
        private float timer;
        private Coroutine c1, c2;
        private void Start()
        {

            EVC = ChangImager.GetComponent<EI_ID_changImg>();
        }
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
            Debug.Log(timer);
            stop = true;
            StopCoroutine(c1);
            c1 = null;
            return timer;
        }
        public IEnumerator Timer()
        {
            stop = false;

            while (!stop)
            {
                timer += Time.deltaTime;
                if (timer >=1) {
                    stop = true;
                   
                    EVC.scoreflag = 2;

                    EVC.CountScore(false);
                    break;
                }
                yield return null;
            }
            


            yield return null;

        }
    }

}
