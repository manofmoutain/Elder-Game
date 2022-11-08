using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Text.RegularExpressions;

using System;

public class GetFormClassName : MonoBehaviour
{
    string url = "http://ring.nutc.edu.tw/garmin/Joyce/get_FormClassName.php";
    private string account;
    private string password;
    public TMP_Text Nametxt;
    //public TMP_Text debugtxt;
    public GameObject[] panelBody;
    public Image[] image; //bg
    public Sprite[] bg; // 標題底圖 0:健康促進 1:情緒調節 2:腦力提升
    public Sprite[] buttonbg; // 小知識底圖 0:default 1:select
    public Sprite[] tipsbg; // 小知識底圖 0:default 1:select
    public Sprite[] doitbg; // 動手做底圖 0:健康促進 1:情緒調節 2:select

    private float height; // newButton Height
    private string formbg; // 健康促進/情緒調節/腦力提升、小知識/動手做 -> 底圖
    private string[] className = new string[10]; 
    private string[] num= new string[10]; // 去完成 已完成

    // Start is called before the first frame update
    void Start() // 健康促進(0小知識、1動手做) 情緒調節(2小知識、3動手做) 腦力提升(4小知識)
    {
        StartCoroutine(GetFormNames());
        string[] name = { "小知識", "動手做"};
        Debug.Log(LoadScenes.group5Num);
        Nametxt.text = name[LoadScenes.group5Num%2]; // 小知識 動手做
        image[0].sprite = bg[LoadScenes.group5Num/2]; // 健康促進 情緒調節 腦力提升
        
    }

    IEnumerator GetFormNames()
    {
        account=SignIn.account;
        password=SignIn.password;
        
        //查資料  userid 
        WWWForm form = new WWWForm();
        form.AddField("action", "GetFormClassName");
        form.AddField("groupId", LoadScenes.group5Num+1); //資料庫 的 健康促進(1小知識、2動手做) 情緒調節(3小知識、4動手做) 腦力提升(5小知識)
        form.AddField("account", account);
        form.AddField("password", password);
        WWW www = new WWW(url, form);

        yield return www;

        var received_data = Regex.Split(www.text, "</next>");
        var Length = (received_data.Length) / 2;
        //var received_data = Regex.Split("預防疾病</next>0</next>飲食調整</next>0</next>要活要動</next>1</next>睡眠調整</next>1","</next>");
        if(www.error == "Null" || string.IsNullOrEmpty(www.text) || string.IsNullOrWhiteSpace(www.text)){
            Debug.Log(www.error);
			//debugtxt.text=www.error;

        }else
        {

            Debug.Log(www.text);
            //debugtxt.text=www.text;

            for (int i = 0; i < Length; i ++)
            {
                className[i] = received_data[i];
                num[i] = received_data[i+Length];
                if (LoadScenes.group5Num % 2 == 0)
                {
                    formbg = "Prefabs/textForm"; // 小知識
                    panelBody[0].SetActive(true);
                    panelBody[2].SetActive(false);
                }
                else
                {
                    formbg = "Prefabs/videoForm"; // 動手做
                    panelBody[0].SetActive(false);
                    panelBody[2].SetActive(true);
                }
            
                //Create set parent
                GameObject newButton = Instantiate(Resources.Load<GameObject>(formbg));
                newButton.transform.SetParent(panelBody[LoadScenes.group5Num % 2].GetComponent<Transform>());
                newButton.transform.localScale = new Vector3(1, 1, 1);
                newButton.name = className[i];

                //set class name
                TMP_Text name = newButton.GetComponentInChildren<TMP_Text>();
                Debug.Log("Name " + i + " : " + received_data[i]);
                name.text = received_data[i];

                //set bg button sprite
                Image[] image = newButton.GetComponentsInChildren<Image>();
                Debug.Log("Button  " + i + " : " + received_data[i + Length]);

                if (received_data[i + Length] == "0")
                { //去完成
                    //bg
                    if (LoadScenes.group5Num % 2 == 0)
                    { // 小知識
                        image[0].sprite = tipsbg[0];
                    }
                    else if (LoadScenes.group5Num == 1)
                    { // 動手做(健康促進)
                        image[0].sprite = doitbg[0];
                    }
                    else
                    {
                        image[0].sprite = doitbg[1]; // 動手做(情緒調節)
                    }
                    //btn
                    image[1].sprite = buttonbg[0];

                }
                else
                { //已完成
                    //bg
                    if (LoadScenes.group5Num % 2 == 0)
                    { // 小知識
                        image[0].sprite = tipsbg[0];
                    }
                    else
                    {
                        image[0].sprite = doitbg[2]; // 動手做
                    }
                    //btn
                    image[1].sprite = buttonbg[1];
                }

                //set url
                newButton.GetComponentInChildren<Button>().onClick.AddListener(delegate ()
                {
                    image[1].sprite = buttonbg[1];
                    panelBody[3].SetActive(true);
                    GetComponent<WebViewForm>().geturl(newButton.name,LoadScenes.group5Num+1); // class name  received_data[i] !!!!!!!!
                });

                height = newButton.GetComponent<RectTransform>().rect.height;
            }
        }

        panelBody[LoadScenes.group5Num % 2].GetComponent<RectTransform>().sizeDelta = new Vector2(0, (height*(received_data.Length/2)+120));


    }
}
