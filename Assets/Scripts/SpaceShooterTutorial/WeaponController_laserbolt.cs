using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponController_laserbolt : MonoBehaviour
{
	public GameObject rocket;
	public Transform shotSpawn;
	private List<GameObject> rockets; 
	private int index;
	private int can_fire;

	void Start ()
	{

		this.can_fire = 0;
		this.rockets = new List<GameObject> ();
		for (int i=0; i<=1; i++)
		{
			
			GameObject obj=(GameObject)Instantiate(rocket);
			obj.SetActive(false);
			this.rockets.Add(obj);
		}

	}

	public void rocket_away()
	{
		//Debug.Log ("Rocket can fire "+this.can_fire);
			if (!this.rockets [0].activeInHierarchy && this.can_fire==1) 
		{ 	
			this.rockets [0].transform.position = shotSpawn.position;
			this.rockets [0].transform.rotation = shotSpawn.rotation;
			this.rockets [0].SetActive (true);
		
		}


	
	}

	void FixedUpdate  ()
	{
		if (this.gameObject.transform.position.z<14 && this.gameObject.transform.position.z>12.5)
		{
			this.can_fire=1;
			rocket_away();
			this.can_fire=0;
		}

	}

}
