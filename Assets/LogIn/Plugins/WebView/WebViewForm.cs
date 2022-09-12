using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;



public class WebViewForm : MonoBehaviour
{

	// public int isvalid = 0; // 1:循序 2:亂數
	// public string classname = 0; // 1:GDS 2:HADS 3:PASE-C 4: IPAQ 5:運動習慣 6:安適幸福感量表
    string formurl = "";
	private string account;
	private string password;
    private string userid;
	private string username;

	private string cnt;
	private string url;
	private string idKey;
	private string nameKey;

	WebViewCallbackTest m_callback;

	// Use this for initialization
	void Start () {

		userid=GetUserID.userid;
		//userid="1444824498=%E5%A5%B3%E7%94%9F";

		username=GetUserID.username;
		//username="1663182525=20";
		account=GetUserID.account;
		password=GetUserID.password;
        Debug.Log("WebViewForm userid " + userid);
	}

	public void geturl (string name) { // int isvalid,

		StartCoroutine(getformurl(name));
	}
	public void showform () {

		Debug.Log("showform start:");
		
		m_callback = new WebViewCallbackTest();

		WebViewBehavior webview = GetComponent<WebViewBehavior>();
	
		if( webview != null )
		{
			webview.LoadURL( url+"&entry."+idKey+"="+userid+"&entry."+nameKey+"="+username );
			Debug.Log(url+"&entry."+idKey+"="+userid+"&entry."+nameKey+"="+username);

			webview.SetMargins(0,190,0,0);
			webview.SetVisibility( true );
			webview.setCallback( m_callback );
			webview.gameObject.layer = 5;
		}else{
			Debug.Log("webview == null");
		}
		
	}

	IEnumerator getformurl(string name) //int isvalid
    {
		Debug.Log("getformurl"+ name);
        //查資料  userid 
        WWWForm form = new WWWForm(); // 1:循序 2:亂數 //get_orderQuizzes.php get_randomQuizzes.php // GetorderQuizzes GetrandomQuizzes 
		/*if(isvalid==1){
			formurl = "http://ring.nutc.edu.tw/garmin/Joyce/get_orderQuizzes.php";
			form.AddField("action", "GetorderQuizzes");
			form.AddField("userId", userid);
			form.AddField("name", name);
		}else if(isvalid==2){
			formurl = "http://ring.nutc.edu.tw/garmin/Joyce/get_randomQuizzes.php";
			form.AddField("action", "GetrandomQuizzes");
			form.AddField("name", name);
		}*/
		formurl = "http://ring.nutc.edu.tw/garmin/Joyce/upload_DailyTask.php";
		form.AddField("action", name);
		form.AddField("account", account);
        form.AddField("password", password);
		
		Debug.Log(name);
		

        WWW www = new WWW(formurl, form);

        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
        }
        Debug.Log(www.text);

        if(www.text!=null){
			/*0</next>
			https://docs.google.com/forms/d/e/1FAIpQLSd8NNfzzHtIARXn8SWgz1IdOsDTIGheZAAVHqxT64UYW7dEow/viewform?usp=pp_url</next>
			79679861</next>
			1915601404</next>
			*/
        	var received_data = Regex.Split(www.text, "</next>"); 
        	
			
            url = received_data[0];
            idKey = received_data[1];
			nameKey = received_data[2];

        	Debug.Log(url);
        }

		showform();
 
    }


	
}