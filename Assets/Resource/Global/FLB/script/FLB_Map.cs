
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace FLB{
    public class FLB_Map : MonoBehaviour
    {
        // Start is called before the first frame update
        bool timeset = false;
        int getQus=0;

        float timer = 0;
        public List<float> currectTime;
        public List<float> mistakeTime;
        int score = 0;
        List<string> listRang;
        List<string> SelectedImage = new List<string>();
       [SerializeField] TextAsset FileName;
        [SerializeField] AudioSource HintAudio;
        [SerializeField] List<Sprite> hintImg;
        [SerializeField] GameObject imagePanel,hintPanel, imageItem;
        [SerializeField] int passScore;
        int[] GridSize = { 250, 120 };
        int[] imgCount = { 6, 6, 8 };
        void clearPanel()
        {
            if (imagePanel.transform.childCount > 0)//space
            {
                for (int index = 0; index < imagePanel.transform.childCount; index++)
                {
                    GameObject childItem = imagePanel.transform.GetChild(index).gameObject;
                    Destroy(childItem);
                }
            }
            
        }
        string ere()
        {
                PointerEventData pointer = new PointerEventData(EventSystem.current);
                pointer.position = Input.mousePosition;
                List<RaycastResult> raycastResults = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pointer, raycastResults);

            return raycastResults[0].gameObject.GetComponent<Image>().sprite.name;
            
        }
        void timeSet(string react)
        {
            if (SelectedImage.Contains(react))
            {
                mistakeTime.Add(timer);
            }
            else
            {
                score++;
                currectTime.Add(timer);
                SelectedImage.Add(react);
            }

            timeset = true;
        }
        public void startGame() {
             getQus=UnityEngine.Random.Range(0, 2);
            readData();
            
            triggerChange();
        }
        void triggerChange() {
            StartCoroutine(Roll());
        }
        void readData()
        {
            List<string> spriteList = FileName.text.Split("\n").ToListPooled();
            int sum=0;
            foreach (int i in imgCount) sum += i;
            listRang = spriteList.GetRange(getQus*sum,sum);
        }
        List<string> spliteWord(int sentence)
        {
            return listRang[sentence].Split("\t").ToListPooled();

        }
        // Update is called once per frame
        IEnumerator Roll()
        {
            int Bcount = 0;
            for (int basicRoll = 0; basicRoll < imgCount.Length; basicRoll++) {
                clearPanel();
                HintAudio.Play(); 
                hintPanel.GetComponent<Image>().sprite = hintImg[basicRoll];
                hintPanel.SetActive(true);
                
                yield return new WaitForSeconds(1.5f);
                if (basicRoll == imgCount.Length - 1)
                {
                    reSize(1);
                }
               
                for (int i = 0; i < imgCount[basicRoll]; i++)//get now roll count
                {
                    maps(spliteWord(i+ Bcount), basicRoll);
                    while (timer < 0.5f&& !timeset) { //timer
                    if (Input.GetMouseButtonUp(0))
                    {

                        string react=ere();
                            if(react.Split(' ')[0] == "Target") {
                            Debug.Log(react);
                            if (react != null) timeSet(react);
                            }
                        }
                        timer += Time.deltaTime;
                        yield return null;
                    }
                    timer = 0;
                    timeset = false;
                }
                Bcount += imgCount[basicRoll];
            }
            gameFinal();
        }
        


        void maps(List<string> list,int i)
        {
            clearPanel();
            for (int index = 0; index < imgCount[i]; index++) {
                Debug.Log(list[index]);
                GameObject item=Instantiate(imageItem);
                item.transform.parent = imagePanel.transform;
                item.transform.localScale=new Vector3(1,1,1);

                string AssetPath = AssetDatabase.FindAssets(list[index])[0];
                
                item.GetComponent<Image>().sprite= (Sprite)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(AssetPath),typeof(Sprite));
                item.SetActive(true);
            }
        }
        //0=3X2,1=4X2
        public void reSize(int i) {

            imagePanel.GetComponent<GridLayoutGroup>().padding.left = GridSize[i];
            imagePanel.GetComponent<GridLayoutGroup>().padding.right = GridSize[i];
            
            
        }
        private void gameFinal()
        {
            
            score = score * 5;
            Debug.Log(score);
            if (score >= passScore)
            {
            SceneManager.LoadScene("0-AllMap");
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        }
    }


}

