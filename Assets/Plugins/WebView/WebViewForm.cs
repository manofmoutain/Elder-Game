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

	public int isvalid = 0; // 1:循序 2:亂數

    string formurl = "";
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
		username=GetUserID.username;
        Debug.Log("WebViewForm userid " + userid);
	}

	public void geturl (int isvalid) {

		StartCoroutine(getformurl(isvalid));
	}
	public void showform () {

		Debug.Log("showform start:");
		
		m_callback = new WebViewCallbackTest();

		WebViewBehavior webview = GetComponent<WebViewBehavior>();
	
		if( webview != null )
		{
			webview.LoadURL( url+"&entry."+idKey+"="+userid+"&entry."+nameKey+"="+username );
			Debug.Log(url+"&entry."+idKey+"="+userid+"&entry."+nameKey+"="+username);

			webview.SetMargins(0,160,0,0);
			webview.SetVisibility( true );
			webview.setCallback( m_callback );
			webview.gameObject.layer = 5;
		}else{
			Debug.Log("webview == null");
		}
		
	}

	IEnumerator getformurl(int isvalid)
    {
        //查資料  userid 
        WWWForm form = new WWWForm(); // 1:循序 2:亂數 //get_orderQuizzes.php get_randomQuizzes.php // GetorderQuizzes GetrandomQuizzes 
		if(isvalid==1){
			formurl = "http://snoopy.nutc.edu.tw/garmin/Joyce/get_orderQuizzes.php";
			form.AddField("action", "GetorderQuizzes");
			form.AddField("userId", userid);
		}else if(isvalid==2){
			formurl = "http://snoopy.nutc.edu.tw/garmin/Joyce/get_randomQuizzes.php";
			form.AddField("action", "GetrandomQuizzes");
		}

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
        	
			cnt = received_data[0];
            url = received_data[1];
            idKey = received_data[2];
			nameKey = received_data[3];

        	Debug.Log(url);
        }

		showform();
 
    }


	
}