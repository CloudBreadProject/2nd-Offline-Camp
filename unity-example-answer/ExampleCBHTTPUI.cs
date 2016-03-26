using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class ExampleCBHTTPUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		_contentAreaRect = new Rect (Screen.width/2 - _contentWidth / 2, 10, _contentWidth, _contentHeight);
	}

	private string ServerAddress = "https://dw-cloudbread2.azurewebsites.net/";
	private string PathString = "api/ping";

	private string ResponseData = "";
	private string RequestData = "";

	/*
	 * 	// Headers
	/*
		Accept:application/json
		X-ZUMO-VERSION:ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)
		X-ZUMO-FEATURES:AJ
		ZUMO-API-VERSION:2.0.0
		Content-Type:application/json
	 *
	 */
	// @TODO
	private void HTTPRequestSend (){
		var ServerEndPoint = ServerAddress + PathString;

		Dictionary <string, string> Header = new Dictionary<string, string> ();
		Header.Add ("Accept", "application/json");
		Header.Add ("X-ZUMO-VERSION", "ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)");
		Header.Add ("X-ZUMO-FEATURES", "AJ");
		Header.Add ("ZUMO-API-VERSION", "2.0.0");
		Header.Add ("Content-Type", "application/json");

		WWW www = new WWW (ServerEndPoint, null, Header);
		StartCoroutine (WaitForRequest (www));
	}
		
	private void HTTPRequestAuthSend(){

//		eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdGFibGVfc2lkIjoic2lkOmFkN2RiMTIxYmZhNjRjNmU4NmUxYTg1MzVkOTJhNWNkIiwic3ViIjoic2lkOjgzMTZhZWU5NzY4ODk3NDg1Y2M3OGI5ZjY3NjYxZDJjIiwiaWRwIjoiZmFjZWJvb2siLCJ2ZXIiOiIzIiwiaXNzIjoiaHR0cHM6Ly9jYjItYXV0aC1kZW1vLmF6dXJld2Vic2l0ZXMubmV0LyIsImF1ZCI6Imh0dHBzOi8vY2IyLWF1dGgtZGVtby5henVyZXdlYnNpdGVzLm5ldC8iLCJleHAiOjE0NjQxMTQ2OTYsIm5iZiI6MTQ1ODkzMDY5OH0.XvhGw8mocPm0ORPxdIG04dE0CB4xgpwTHBS_P_BGZ1E

		var ServerEndPoint = "https://cb2-auth-demo.azurewebsites.net/api/ping";

		Dictionary <string, string> Header = new Dictionary<string, string> ();
		Header.Add ("Accept", "application/json");
		Header.Add ("X-ZUMO-VERSION", "ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)");
		Header.Add ("X-ZUMO-FEATURES", "AJ");
		Header.Add ("ZUMO-API-VERSION", "2.0.0");
		Header.Add ("Content-Type", "application/json");
		Header.Add ("x-zumo-auth", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdGFibGVfc2lkIjoic2lkOmFkN2RiMTIxYmZhNjRjNmU4NmUxYTg1MzVkOTJhNWNkIiwic3ViIjoic2lkOjgzMTZhZWU5NzY4ODk3NDg1Y2M3OGI5ZjY3NjYxZDJjIiwiaWRwIjoiZmFjZWJvb2siLCJ2ZXIiOiIzIiwiaXNzIjoiaHR0cHM6Ly9jYjItYXV0aC1kZW1vLmF6dXJld2Vic2l0ZXMubmV0LyIsImF1ZCI6Imh0dHBzOi8vY2IyLWF1dGgtZGVtby5henVyZXdlYnNpdGVzLm5ldC8iLCJleHAiOjE0NjQxMTQ2OTYsIm5iZiI6MTQ1ODkzMDY5OH0.XvhGw8mocPm0ORPxdIG04dE0CB4xgpwTHBS_P_BGZ1E");


		WWW www = new WWW (ServerEndPoint, null, Header);
		StartCoroutine (WaitForRequest (www));
	}

	private IEnumerator  WaitForRequest(WWW www) {

		yield return www;

		if (www.error != null) {
			
			ResponseData = "[Error] " + www.error;

		} else {
			
			ResponseData = www.text;

		}

		www.Dispose();
	}

	private Rect _contentAreaRect;
	private float _contentWidth = 600;
	private float _contentHeight = 800;

	public void OnGUI(){
		GUILayout.BeginArea(_contentAreaRect);
			GUILayout.BeginVertical ();
				GUILayout.BeginHorizontal ("box");
					GUILayout.Label("Server Address : ", GUILayout.Width(100));
					ServerAddress = GUILayout.TextField(ServerAddress, GUILayout.Width(_contentWidth - 125));
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ("box");
					GUILayout.Label("Path : ", GUILayout.Width(100));
					PathString = GUILayout.TextField(PathString, GUILayout.Width(_contentWidth-125));
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ();
					if (GUILayout.Button ("Send", GUILayout.Width (80))) {
						HTTPRequestSend ();
					}
					if (GUILayout.Button ("Auth Send ", GUILayout.Width (80))) {
						HTTPRequestAuthSend ();
					}
				GUILayout.EndHorizontal ();
				GUILayout.Label ("");
				GUILayout.Label ("Request Data : ");
				RequestData = GUILayout.TextArea (RequestData, GUILayout.Width(_contentWidth), GUILayout.Height(50));

				GUILayout.Label ("");
				GUILayout.Label ("Response Data : ");
				ResponseData = GUILayout.TextArea (ResponseData, GUILayout.Width(_contentWidth), GUILayout.Height(300));
			GUILayout.EndVertical ();
		GUILayout.EndArea ();
	}
}
