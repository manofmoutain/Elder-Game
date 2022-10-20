using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EI_VA
{
    public class EI_VA_countScore : MonoBehaviour
    {
        // Start is called before the first frame update
        public float totle;
        public float currect;
        public float mistake;
        public float miss;
        public float oneTestScore;
        private GameObject UI;
        [SerializeField] GameObject ChangImager;
        [SerializeField] private GameObject currectUI;
        [SerializeField] private GameObject mistakeUI;
        private EI_VA_changImg EVC;
        private void Start()
        {

            EVC = ChangImager.GetComponent<EI_VA_changImg>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"> 0=currect;1=dismistake;2=miss</param>
        public void switchScore(int i)
        {
            if (i == 0)
            {
                UI=currectUI;
                totle += oneTestScore;
                currect++;
            }
            else if (i == 1)
            {
                UI=mistakeUI;
                mistake++;
            }
            else if (i == 2)
            {
                UI = mistakeUI;
                miss++;
            }
            UIAppend();
        }
        private void UIAppend()
        {

            UI.SetActive(true);
            Debug.Log("OPEN");
            Invoke("goDown", 0.75f);
            Debug.Log("close");
        }
        public void goDown()
        {
            UI.SetActive(false);
            EVC.nextTest();
        }
    }
}
