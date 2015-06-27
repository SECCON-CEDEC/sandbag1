using UnityEngine;
using System.Collections;



public class CanonCS : MonoBehaviour {
	public   GameObject prefab;
	public   float power=200;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			GameObject bullet = LoadBullet();
			//
			Ray ray= 
				Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 dir = ray.direction.normalized;
			
			bullet.rigidbody.velocity = dir * power;
		}	
	}
	GameObject LoadBullet() {
		GameObject bullet = (GameObject)Instantiate(prefab);
		bullet.transform.parent = transform;
		bullet.transform.localPosition=Vector3.zero;
		return bullet;
	} 
}
