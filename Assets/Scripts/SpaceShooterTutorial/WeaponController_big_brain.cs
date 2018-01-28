using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponController_big_brain : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn;
	public Transform shotSpawn2;
	public float fireRate;
	public float delay;
	private List<GameObject> shots; 
	public int ammount;
	public bool stopped;


	void Start ()
	{

		stopped = false;
		this.shots = new List<GameObject> ();
		for (int i=0; i<ammount; i++){
			
			GameObject obj=(GameObject)Instantiate(shot);
			obj.SetActive(false);
			this.shots.Add(obj);
		}

		InvokeRepeating ("Shoot", delay, fireRate);
	}
	public void Shoot ()
	{
		
		//yield return new WaitForSeconds (0.5f);
		
		
		if (!this.shots[1].activeInHierarchy)
		{
			this.shots[1].transform.position=shotSpawn.position;
			this.shots[1].transform.rotation=shotSpawn.rotation;
			this.shots[1].SetActive(true);
			
			//	break;
		}
		StartCoroutine(wait());
			
		
		
		//Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		
		//GetComponent<AudioSource>().Play();
	}

	 
	public IEnumerator wait () 
	{
	yield return new WaitForSeconds(0.0f);
		if (!this.shots[2].activeInHierarchy)
		{
			this.shots[2].transform.position=shotSpawn.position;
			this.shots[2].transform.Rotate(0, 160, 0);
			//this.shots[2].transform.rotation=shotSpawn.rotation;
			this.shots[2].SetActive(true);
			
			
			
		}

		if (!this.shots[3].activeInHierarchy)
		{
			this.shots[3].transform.position=shotSpawn.position;
			this.shots[3].transform.Rotate(0, -160, 0);
			//this.shots[2].transform.rotation=shotSpawn.rotation;
			this.shots[3].SetActive(true);
			
			
			
		}

	}
			


}
