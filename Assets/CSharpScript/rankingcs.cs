using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine.UI;
using Common;

public class rankingcs : MonoBehaviour {
	private RankData[] rankdata;
	public GUIStyle buttonStyle;
	private float nextTime;
	private int rank_count,display_count;
	public float interval = 0.5f;	// 表示間隔
	// Use this for initialization
	IEnumerator  Start () {
//		RankData[] rankdata;
		WWW www = new WWW (Define.ServerUrl);
		yield return www;
		Text ms;
		if (www.error == null) {
			rankdata = JsonMapper.ToObject<RankData[]> (www.text);
			Debug.Log(rankdata.Length);
			ms = GameObject.Find ("Canvas/status").GetComponent<Text> ();
			ms.enabled=false;
			nextTime = Time.time;
			rank_count=rankdata.Length;
			display_count=rank_count;
		}
		// 失敗
		else{
			ms = GameObject.Find ("Canvas/status").GetComponent<Text> ();
			ms.text ="Network error or Server error.\n";
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (rank_count > 0 &&  display_count>0) {
			if (Time.time > nextTime) {
				nextTime += interval;
				display_count--;
				Text ms, pts;
				ms = GameObject.Find ("Canvas/rank" + (display_count + 1)).GetComponent<Text> ();
				ms.text = string.Format ("{0,2} {1,-20:000} ", display_count + 1, rankdata [display_count].name);
				pts = GameObject.Find ("Canvas/point" + (display_count + 1)).GetComponent<Text> ();
				pts.text = rankdata [display_count].point;
			}
		}
	}
	void OnGUI () {
		if(GUI.Button(new Rect( Screen.width/4
		                       ,Screen.height/2+240
		                       ,Screen.width/2
		                       ,Screen.height/16),"BACK",buttonStyle))
			
		{
			Application.LoadLevel("title");
		}

	}
}
class RankData {
	public string name;
	public string point;
}
