using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace VS_VA
{
public class VS_VA_BGTimer : MonoBehaviour
{
        // Start is called before the first frame update
        Transform currentTrans;
        // 是按下滑鼠
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
        void Paste() { 
              
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

            return timer;
        }
        public IEnumerator Timer()
        {
            stop = false;

            while (!stop)
            {
               
                timer += Time.deltaTime;
                if (timer >=60||(parent.childCount==0)) {
                    stop = true;
                    gameFinal();
                    break;
                }
                //EI_VA_Drug
                if (isDown)
                {
                    // 當前目標獲得滑鼠當下的位置
                    currentTrans.position = Input.mousePosition;
                    // 當滑鼠放手時
                    if (Input.GetMouseButtonUp(0))
                    {
                        // 放手
                        isDown = false;
                        PointerEventData pointer = new PointerEventData(EventSystem.current);
                        pointer.position = Input.mousePosition;
                        // 射線到的目標
                        List<RaycastResult> raycastResults = new List<RaycastResult>();
                        EventSystem.current.RaycastAll(pointer, raycastResults);
                        if (raycastResults.Count >= 2) {

                            if (currentTrans.GetComponent<VS_VA.VS_VA_Drug>().state == Convert.ToInt32(raycastResults[1].gameObject.name) - 1)
                            {
                                timeSet(true);
                                currentTrans.position = raycastResults[1].gameObject.transform.position;
                                currentTrans.parent = atantion;
                                Destroy(raycastResults[1].gameObject);
                            }
                            else {
                                timeSet(false);
                                currentTrans.GetComponent<RectTransform>().position = currentTrans.GetComponent<VS_VA.VS_VA_Drug>().defaultPlace;
                            }
                        }
                    }
                }
                else
                {
                    // 當滑鼠按下
                    if (Input.GetMouseButtonDown(0))
                    {
                        PointerEventData pointer = new PointerEventData(EventSystem.current);
                        pointer.position = Input.mousePosition;
                        // 射線到的目標
                        List<RaycastResult> raycastResults = new List<RaycastResult>();
                        EventSystem.current.RaycastAll(pointer, raycastResults);
                        // 目標數量
                        if (raycastResults.Count > 0&& raycastResults[0].gameObject.transform.parent.Equals(parent))
                        {
                            isDown = true;
                            // 取得第一個目標
                            currentTrans = raycastResults[0].gameObject.transform;
                            Debug.Log(currentTrans.position);
                        }
                    }
                }
                yield return null;
            }
            


            yield return null;

        }
        private void gameFinal()
        {
            /*if (EVS.totle >= 80)
            {
               */ SceneManager.LoadScene("0-AllMap");/*
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }*/

        }
    }

}
