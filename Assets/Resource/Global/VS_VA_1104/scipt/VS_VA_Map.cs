using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace VS_VA
{
public class VS_VA_Map : MonoBehaviour
{
    [SerializeField] private Transform parent;
        [SerializeField] private GameObject item;
        [SerializeField] private string value;
        [SerializeField] private List<Sprite> ts ;
        // Start is called before the first frame update
        void Start()
    {
            List<string> spriteList = value.Split(' ').ToListPooled();
            for (int index = 0; index < spriteList.Count-1; index++)
            {
                int e = Convert.ToInt32(spriteList[index]);
                Debug.Log(spriteList[index]);
                StartCoroutine(reaw(e-1,index));
            }
        }
    IEnumerator reaw(int e ,int index) {
            GameObject g= parent.GetChild(index).gameObject;
            g.GetComponent<Image>().sprite = ts[e];
            g.GetComponent<VS_VA_Drug>().state = e;

            //GridLayoutGroup group = g.transform.parent.GetComponent<GridLayoutGroup>();
            /*float x = (g.transform.parent.position.x) + (g.transform.parent.GetComponent<RectTransform>().rect.width * ((index/(int)(g.transform.parent.GetComponent<RectTransform>().rect.width / group.cellSize.x) - 1)) + group.spacing.x);
            float y = (g.transform.parent.position.x) + (g.transform.parent.GetComponent<RectTransform>().rect.height * ((index / (int)(g.transform.parent.GetComponent<RectTransform>().rect.height / group.cellSize.y) - 1)) + group.spacing.y);
            */
            //float x = (g.transform.parent.position.x) + g.transform.parent.GetComponent<RectTransform>().rect.width *(3 %(index-1)) + group.spacing.x;
            //float y = (g.transform.parent.position.x) + (g.transform.parent.GetComponent<RectTransform>().rect.height * ((index / (int)(g.transform.parent.GetComponent<RectTransform>().rect.height / group.cellSize.y) - 1)) + group.spacing.y);

            //Vector2 v2 = new Vector2(x, y);

            Transform t = g.transform;
            Debug.Log(t.position+g.name);
            g.GetComponent<VS_VA_Drug>().defaultPlace = t.position;// new Vector3(x, g.GetComponent<RectTransform>().rect.yMin, 3);
            yield return new WaitForSeconds(0.7f);
        }
}
}

