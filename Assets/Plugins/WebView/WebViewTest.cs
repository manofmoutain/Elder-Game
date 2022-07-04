using UnityEngine;
using System.Collections;

class WebViewCallbackTest : Kogarasi.WebView.IWebViewCallback
{
	public void onLoadStart( string url )
	{
		Debug.Log( "call onLoadStart : " + url );
	}
	public void onLoadFinish( string url )
	{
		Debug.Log( "call onLoadFinish : " + url );
	}
	public void onLoadFail( string url )
	{
		Debug.Log( "call onLoadFail : " + url );
	}
}

public class WebViewTest : MonoBehaviour
{

	WebViewCallbackTest m_callback;

	// Use this for initialization
	void Start () {

		
		
	}
	public void signup () {

		Debug.Log( "signup Start : ");
		m_callback = new WebViewCallbackTest();

		WebViewBehavior webview = GetComponent<WebViewBehavior>();
	
		if( webview != null )
		{
			//webview.LoadURL( "http://snoopy.nutc.edu.tw/" );
			//http://snoopy.nutc.edu.tw/
			webview.SetMargins(0,160,0,0);
			webview.SetVisibility( true );
			webview.setCallback( m_callback );
			webview.gameObject.layer = 5;
		}else{
			Debug.Log("webview == null");
		}
		
	}
	
	
}
