using UnityEngine;
using System.Collections;
//
public class HitandBangCS : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter ( Collision col)
	{
		ScoreCS.scorePoint += CanonCS.addPoint;
		if (col.gameObject.tag == "Bullet") {
			Destroy (col.gameObject);
		}
	}
}
