using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GroupScence : MonoBehaviour
{
    public TMP_Text Nametxt;
    
    public Image image;
    public GameObject[] button;
    public Sprite[] bg;
    public Sprite[] tips;
    public Sprite[] doit;
    // Start is called before the first frame update
    void Start()
    {
        var group = LoadScenes.groupNum;
        string[] name = { "健康促進", "情緒認知", "腦力提升" };
        Nametxt.text = name[group];
        image.sprite = bg[group];
        button[0].GetComponent<Image>().sprite = tips[group];
        button[1].GetComponent<Image>().sprite = doit[group];
        Debug.Log(group);
        //button[0] = GetComponent<Button>();
        
        button[0].GetComponent<Button>().onClick.AddListener(delegate () { GetComponent<LoadScenes>().LoadGroup5(LoadScenes.groupNum*2); });
        button[1].GetComponent<Button>().onClick.AddListener(delegate () { 
            if(LoadScenes.groupNum!=2){
                GetComponent<LoadScenes>().LoadGroup5(LoadScenes.groupNum*2+1); 
            }else{
                GetComponent<LoadScenes>().Load("game"); // 請陳老師 轉跳遊戲畫面 輸入場景名稱 並加上Panel Head 表頭
            }
            
            });
        Debug.Log(LoadScenes.groupNum*2);
    }

}
