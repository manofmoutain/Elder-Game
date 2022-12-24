using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenGarminApp : MonoBehaviour
{
    public TMP_Text debugtxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenGarmin(){
       

        #if PLATFORM_ANDROID
            bool fail = false;
            string pkgName = "com.garmin.android.apps.connectmobile";//下載網址中id的後半段就是App 名稱 (package name)
            AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject ca = up.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject packageManager = ca.Call<AndroidJavaObject>("getPackageManager");
            AndroidJavaObject launchIntent = null;

            try{
                launchIntent = packageManager.Call<AndroidJavaObject>("getLaunchIntentForPackage",pkgName);
            }catch(System.Exception e){ //未安裝Garmin Connect App
                fail = true;
                Debug.LogError(e);
                //debugtxt.text = e.Message;
            }

            if(fail){//未安裝Garmin Connect App 跳轉至 Google play商店 下載
                Application.OpenURL("https://play.google.com/store/apps/details?id=com.garmin.android.apps.connectmobile");
                Debug.Log("go to google play store download garmin connect app.");
            }else{
                try{
                    ca.Call("startActivity",launchIntent);
                }catch(System.Exception e){
                    Debug.LogError(e);
                }
            }

            up.Dispose();
            ca.Dispose();
            packageManager.Dispose();
            launchIntent.Dispose();

        #else //ios 直接跳轉至APP store 下載
            Application.OpenURL("https://apps.apple.com/tw/app/garmin-connect/id583446403");
        #endif
    }

}
