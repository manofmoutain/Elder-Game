using System.Collections;
using UnityEngine;
using System.Text.RegularExpressions;

public class UploadSportSleepData : MonoBehaviour
{
    string url = "http://ring.nutc.edu.tw/garmin/Joyce/upload_SportSleepData.php";
    private string account;
    private string password;
    public bool upload;


    void Start()
    {
        if(upload){
            StartCoroutine(UploadSportSleepDatas());
        }
        
        Debug.Log("upload");
    }
    public void click(){
        StartCoroutine(UploadSportSleepDatas());
    }
    IEnumerator UploadSportSleepDatas()
    {
        account=SignIn.account;
        password=SignIn.password;
        
        //¬d¸ê®Æ  userid 
        WWWForm form = new WWWForm();
        form.AddField("action", "UploadSportSleepData");
        form.AddField("account", account);
        form.AddField("password", password);
        WWW www = new WWW(url, form);
        

        yield return www;
        if(string.IsNullOrEmpty(www.error)){
            Debug.Log(www.text);
            var received_data = Regex.Split(www.text, "</next>");
            Debug.Log(received_data[(received_data.Length)-1]);
            GetComponent<Toast>().showToast(received_data[(received_data.Length)-1], 5);
        }
        
    }

}


