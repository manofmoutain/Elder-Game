using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FLB
{
    public class VS_FLB_BGTimer : MonoBehaviour
    {
        // Start is called before the first frame update
        Transform currentTrans;
        bool isDown = false;

        [SerializeField] private Transform atantion;
        [SerializeField] private Transform parent;
        public List<float> currectTime;
        public List<float> mistakeTime;
        private bool stop = false;
        private float timer;
        private Coroutine c1, c2;
        private void Start()
        {

        }
        void TimePause()
        {

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
            stop = true;
        }
        public void startTimer()
        {
            timer = 0;

            c1 = StartCoroutine(Timer());
        }
        public float getTime()
        {
            Debug.Log(timer);

            return timer;
        }
        public IEnumerator Timer()
        {
            stop = false;

            while (!stop)
            {

                timer += Time.deltaTime;
                //EI_VA_Drug
                if (isDown)
                {

                    currentTrans.position = Input.mousePosition;

                    if (Input.GetMouseButtonUp(0))
                    {
                        isDown = false;
                        PointerEventData pointer = new PointerEventData(EventSystem.current);
                        pointer.position = Input.mousePosition;
                        List<RaycastResult> raycastResults = new List<RaycastResult>();
                        EventSystem.current.RaycastAll(pointer, raycastResults);
                        if (raycastResults.Count >= 2)
                        {


                            timeSet(true);
                            currentTrans.position = raycastResults[1].gameObject.transform.position;
                            currentTrans.parent = atantion;
                            Destroy(raycastResults[1].gameObject);
                        }
                    }
                }
                /*else
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        PointerEventData pointer = new PointerEventData(EventSystem.current);
                        pointer.position = Input.mousePosition;
                        List<RaycastResult> raycastResults = new List<RaycastResult>();
                        EventSystem.current.RaycastAll(pointer, raycastResults);
                        if (raycastResults.Count > 0 && raycastResults[0].gameObject.transform.parent.Equals(parent))
                        {
                            isDown = true;

                            currentTrans = raycastResults[0].gameObject.transform;
                            Debug.Log(currentTrans.position);
                        }
                    }
                }*/
                yield return null;
            }



            yield return null;

        }
        private void gameFinal()
        {
            /*if (EVS.totle >= 80)
            {
               */
            SceneManager.LoadScene("0-AllMap");/*
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }*/

        }
    }
}

