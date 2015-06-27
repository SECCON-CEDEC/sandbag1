using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class titleCS : MonoBehaviour {
	public GUIStyle buttonStyle;
	public GUIStyle buttonStyle2;
	static string uuid;
	static string playerName;

	private float nextTime;
	public float interval = 0.5f;	// 点滅周期
	public Text titleText;

	private float titleScale;


	// Use this for initialization
	void Start () {
		uuid=PlayerPrefs.GetString("uuid");
		if(uuid.Length <36){ 
			System.Guid guid=System.Guid.NewGuid();
			string new_uuid=guid.ToString();
			PlayerPrefs.SetString("uuid",new_uuid);
			PlayerPrefs.Save();
		}
		nextTime = Time.time;
		titleScale = 200.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (titleScale > 44.0) {
						titleScale -= 2.4f;
						titleText.fontSize = (int)titleScale;
		} else {
			if ( Time.time > nextTime ) {
				titleText.enabled = !titleText.enabled;	
				nextTime += interval;
			}
		}
	}
	void OnGUI () {
		playerName=PlayerPrefs.GetString("playerName");
		if (playerName.Length > 0) {
			if (GUI.Button (new Rect (Screen.width / 4
	                       , Screen.height / 2 - 30
	                       , Screen.width / 2
			               , Screen.height / 16), "START", buttonStyle)) {
						Application.LoadLevel ("main");
				}
				if (GUI.Button (new Rect (Screen.width / 4
	                       , Screen.height / 2 + 100
	                       , Screen.width / 2
	                       , Screen.height / 16), "RANKING", buttonStyle)) {
						Application.LoadLevel ("ranking");
				}
				if (GUI.Button (new Rect (Screen.width *3/ 8
			                          , Screen.height / 2 + 210
			                          , Screen.width / 4
			                          , Screen.height / 32), "Change Name", buttonStyle2)) {
					Application.LoadLevel ("entry");
				}
		} else {
			Application.LoadLevel ("entry");
		}
	}

}
