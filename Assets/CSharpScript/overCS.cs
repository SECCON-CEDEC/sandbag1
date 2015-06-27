using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Common;
using LitJson;


public class overCS : MonoBehaviour {
	public int  result_pts;
	public float display_pts;
	public GUIStyle buttonStyle;
	public string playerName;
	public int rank;

	// Use this for initialization
	void Start () {
		result_pts=PlayerPrefs.GetInt("scorePoint");
		display_pts=0.0F;
		playerName=PlayerPrefs.GetString("playerName");
		Text msg = GameObject.Find ("Canvas/rank").GetComponent<Text> ();
		msg.text = "";
		StartCoroutine(UploadScore());
	}
	
	// Update is called once per frame
	void Update () {

		if(display_pts < result_pts*10){
			display_pts+=0.7F;
		}
		Text msg = GameObject.Find ("Canvas/score").GetComponent<Text> ();
		msg.text = Mathf.Floor(display_pts)+" pts";
	}

	void OnGUI () {
		if(display_pts >= result_pts){
			//Retry Button
			Text msg = GameObject.Find ("Canvas/rank").GetComponent<Text> ();
			msg.text = "Your ranking is "+ rank;
			if(GUI.Button(new Rect( Screen.width/4
		                       ,Screen.height/2+30
		                       ,Screen.width/2
		                       ,Screen.height/16),"Retry",buttonStyle))
			
			{
				Application.LoadLevel("title");
			}

		}
	}
	IEnumerator UploadScore() {
		//		Hashtable header = new Hashtable ();
		Dictionary<string, string> header = new Dictionary<string, string>();
		// jsonでリクエストを送るのへッダ例
		header.Add ("Content-Type", "application/json; charset=UTF-8");
		
		// LitJsonを使いJSONデータを生成
		JsonData data = new JsonData();
		string uuid = PlayerPrefs.GetString("uuid");
		
		data ["uuid"] = uuid;
		data ["name"] =playerName;
		data ["point"]=result_pts*10;
		Debug.Log("UUID"+uuid);
		
		// シリアライズする(LitJson.JsonData→JSONテキスト)
		string postJsonStr = data.ToJson();
		byte[] postBytes = Encoding.Default.GetBytes (postJsonStr);
		
		// 送信開始
		WWW www = new WWW (Define.ServerUrl, postBytes, header);
		yield return www;
		
		// 成功
		if (www.error == null) {
			Debug.Log("Upload Success");          
			RankingResponse response2 = JsonMapper.ToObject<RankingResponse> (www.text);
			rank=int.Parse (response2.rank)+1;
			Debug.Log("Current rank"+rank);
		}
		// 失敗
		else{
			Debug.Log("Post Failure");          
		}
	}	

}
class RankingResponse {
	public string rank;
}
