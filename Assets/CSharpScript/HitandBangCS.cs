using UnityEngine;
using System.Collections;
//
public class HitandBangCS : MonoBehaviour {
	public   GameObject Splash;

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
			Vector3 pos=col.contacts[0].point;
			pos.z -=15;
			GameObject splash = (GameObject)Instantiate(Splash);
			splash.transform.localPosition=pos;
		}
	}

}
