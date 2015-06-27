using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GuiObj : MonoBehaviour {
	public Text msgText;
	public InputField field;
	public GUIStyle buttonStyle;
	private float nextTime;
	public float interval = 0.5f;	// 点滅周期
	// Use this for initialization
	void Start () {
		nextTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if ( Time.time > nextTime ) {
			msgText.enabled = !msgText.enabled;	
			nextTime += interval;
		}
	}
	void OnGUI(){
		if (GUI.Button (new Rect (Screen.width / 4
		                          , Screen.height / 2 + 60
		                          , Screen.width / 2
		                          , Screen.height / 16), "OK", buttonStyle)) {

			if(field.text.Length>0){
				PlayerPrefs.SetString("playerName",field.text);
				PlayerPrefs.Save();
				string xplayerName=PlayerPrefs.GetString("playerName");
				Debug.Log ("player:"+xplayerName);
				Application.LoadLevel ("title");
			}
		}
	}
}
