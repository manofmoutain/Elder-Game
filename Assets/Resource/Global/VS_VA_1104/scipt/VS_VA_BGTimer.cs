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
        // �O���U�ƹ�
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
                    // ��e�ؼ���o�ƹ���U����m
                    currentTrans.position = Input.mousePosition;
                    // ��ƹ�����
                    if (Input.GetMouseButtonUp(0))
                    {
                        // ���
                        isDown = false;
                        PointerEventData pointer = new PointerEventData(EventSystem.current);
                        pointer.position = Input.mousePosition;
                        // �g�u�쪺�ؼ�
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
                    // ��ƹ����U
                    if (Input.GetMouseButtonDown(0))
                    {
                        PointerEventData pointer = new PointerEventData(EventSystem.current);
                        pointer.position = Input.mousePosition;
                        // �g�u�쪺�ؼ�
                        List<RaycastResult> raycastResults = new List<RaycastResult>();
                        EventSystem.current.RaycastAll(pointer, raycastResults);
                        // �ؼмƶq
                        if (raycastResults.Count > 0&& raycastResults[0].gameObject.transform.parent.Equals(parent))
                        {
                            isDown = true;
                            // ���o�Ĥ@�ӥؼ�
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
