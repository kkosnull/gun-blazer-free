using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponController_turret : MonoBehaviour
{
	public GameObject rocket;
	public Transform shotSpawn;
	private List<GameObject> rockets; 
	private int index;
	private int can_fire;

	void Start ()
	{


		this.rockets = new List<GameObject> ();
		for (int i=0; i<=4; i++)
		{
			
			GameObject obj=(GameObject)Instantiate(rocket);
			obj.SetActive(false);
			this.rockets.Add(obj);
		}


	}

	public void rocket_away()
	{

			if (!this.rockets [0].activeInHierarchy) 
		{ 	
			this.rockets [0].transform.position = shotSpawn.position;
			this.rockets [0].transform.rotation = shotSpawn.rotation;
			this.rockets [0].SetActive (true);

		}
		 else if (!this.rockets [1].activeInHierarchy) 
		{ 	
			this.rockets [1].transform.position = shotSpawn.position;
			this.rockets [1].transform.rotation = shotSpawn.rotation;
			this.rockets [1].SetActive (true);
			
		}
	

	
	}

	void OnTriggerEnter (Collider other)
	{
		

		
		if (other.tag == "Boundary") 
			{
			InvokeRepeating ("rocket_away", 1, 1);
			}

	}
	void OnTriggerExit (Collider other)
	{
		
		//Debug.Log ("DestroyByContact.OnTriggerEnter() this.tag:" + this.tag + " other.tag:" + other.tag);
		
		if (other.tag == "Boundary") 
		{
			CancelInvoke("rocket_away");
		}
		
	}

}
