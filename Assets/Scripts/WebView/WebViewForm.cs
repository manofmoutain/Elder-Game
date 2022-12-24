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
	public TMP_Text errortxt;
	private string account;
	private string password;
    private string userid;
	private string username;

	private string cnt;
	private string url;
	private string idKey;
	private string nameKey;

	//public TMP_Text debugtxt;

	WebViewCallbackTest m_callback;

	// Use this for initialization
	void Start () {

		
		account=SignIn.account;
		password=SignIn.password;
		//account="jimmy880316@gmail.com";
        //password="jimmy1999";
        
	}

	public void geturl (string name,int groupId) { // int isvalid,
		
		account=SignIn.account;
		password=SignIn.password;
		
		StartCoroutine(getformurl(name,groupId));
	}
	

	IEnumerator getformurl(string name,int groupId) //int isvalid
    {
		Debug.Log("getformurl"+ name + groupId);
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
		formurl = "http://ring.nutc.edu.tw/garmin/Joyce/get_FormURL_new.php";
		form.AddField("action", "GetFormURL");
		form.AddField("className", name);
        form.AddField("groupId", groupId); //資料庫 的 健康促進(1小知識、2動手做) 情緒調節(3小知識、4動手做) 腦力提升(5小知識)
		form.AddField("account", account);
        form.AddField("password", password);
		
		Debug.Log(name);
		

        WWW www = new WWW(formurl, form);

        yield return www;

        if(www.error == "Null" || string.IsNullOrEmpty(www.text) || string.IsNullOrWhiteSpace(www.text))
        {
			Debug.Log(www.error);
			errortxt.text=www.error;
        }else{

        	/*0</next>
        	https://docs.google.com/forms/d/e/1FAIpQLSd8NNfzzHtIARXn8SWgz1IdOsDTIGheZAAVHqxT64UYW7dEow/viewform?usp=pp_url</next>
        	79679861</next>
        	1915601404</next>
        	*/
			Debug.Log(www.text);
			//debugtxt.text=www.text;
        	var received_data = Regex.Split(www.text, "</next>"); 

        	url = received_data[0];
        	
        	Debug.Log(url);
			
			showform();
        }

		
 
    }
	public void showform () {

		Debug.Log("showform start:");
		
		m_callback = new WebViewCallbackTest();

		WebViewBehavior webview = GetComponent<WebViewBehavior>();
	
		if( webview != null )
		{
			webview.LoadURL( url);
			Debug.Log(url);

			webview.SetMargins(0,(int)(Screen.height*0.1),0,0);
			webview.SetVisibility( true );
			webview.setCallback( m_callback );
			webview.gameObject.layer = 5;
		}else{
			Debug.Log("webview == null");
		}
		
	}


	
}