using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class GetRank : MonoBehaviour
{
    string url = "http://ring.nutc.edu.tw/garmin/Joyce/get_Rank.php";

    public TMP_Text[] Ranktxt;
    public TMP_Text Totaltxt;
    private string account;
    private string password;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRanks());
    }

    IEnumerator GetRanks()
    {
        account=SignIn.account;
        password=SignIn.password;
        
        //�d���  userid 
        WWWForm form = new WWWForm();
        form.AddField("action", "GetRank");
        form.AddField("account", account);
        form.AddField("password", password);
        WWW www = new WWW(url, form);

        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
        }
        Debug.Log(www.text);
        // �B�� �ίv ���d�P�i �����ո` ���O���� �`�H��
        var received_data = Regex.Split(www.text, "</next>");

        for (int i = 0; i < 5;i++){
            Ranktxt[0].text = "��" + received_data[i] + "�W";
        }
        Totaltxt.text = "�`�H�ơG" + received_data[5] + "�H";

    }
}
