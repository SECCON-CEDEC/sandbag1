using UnityEngine;
using System.Collections;


public class ScoreCS : MonoBehaviour {
	public static int scorePoint;
	// Use this for initialization
	void Start () {
		scorePoint = 0;
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "SCORE "+(scorePoint*10).ToString();
	
	}
}
