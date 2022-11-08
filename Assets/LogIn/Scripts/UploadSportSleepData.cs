using System.Collections;
using UnityEngine;

public class UploadSportSleepData : MonoBehaviour
{
    string url = "http://ring.nutc.edu.tw/garmin/Joyce/upload_SportSleepData.php";
    private string account;
    private string password;

    void Start()
    {
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
        
    }
}


