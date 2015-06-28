using UnityEngine;
using System.Collections;


//
public class CanonCS : MonoBehaviour {
	public	 GameObject prefab;
	public	 float power;
	public   GameObject prefab_normal;
	public   GameObject prefab_bronze;
	public   GameObject prefab_silver;
	public   GameObject prefab_gold;
	public   float power_normal;
	public   float power_bronze;
	public   float power_silver;
	public   float power_gold;
	public	 int itemLevel;
	public	 static int addPoint;
	// Use this for initialization
	void Start () {
		itemLevel=PlayerPrefs.GetInt("item");
		switch (itemLevel) {
			case 0:
				prefab = prefab_normal;
				power = power_normal;
				addPoint=5;
				break;
			case 1:
				prefab = prefab_bronze;
				power = power_bronze;
				addPoint=10;
				break;
			case 2:
				prefab = prefab_silver;
				power = power_silver;
				addPoint=25;
				break;
			case 3:
				prefab = prefab_gold;
				power = power_gold;
				addPoint=50;
				break;
		}

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
