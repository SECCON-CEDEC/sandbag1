using UnityEngine;
using System.Collections;

public class TimeCS : MonoBehaviour {
	public static float time;
	// Use this for initialization
	void Start () {
		time = 10;
		GetComponent<GUIText>().text = "TIME";
	}
	
	// Update is called once per frame
	void Update () {
		int now = (int)time;
		time -= Time.deltaTime;
		GetComponent<GUIText>().text = now.ToString();
		if(now <=0 ){
			PlayerPrefs.SetInt("scorePoint",ScoreCS.scorePoint);
			Application.LoadLevel("timeup");
		}	
	}
}
