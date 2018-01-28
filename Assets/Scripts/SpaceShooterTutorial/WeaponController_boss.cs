using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponController_boss : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn1;
	public Transform shotSpawn2;
	public float fireRate;
	public float delay;
	private List<GameObject> shots_left; 
	private List<GameObject> shots_right;
	void Start ()
	{
		this.shots_left = new List<GameObject> ();
		this.shots_right = new List<GameObject> ();
		for (int i=0; i<20; i++){
			
			GameObject obj=(GameObject)Instantiate(shot);
			obj.SetActive(false);
			this.shots_left.Add(obj);
			this.shots_right.Add(obj);
		}
		InvokeRepeating ("Shoot", delay, fireRate);
	}


	public void Shoot ()
	{
		
		//yield return new WaitForSeconds (0.5f);
		
		
		if (!this.shots_left[1].activeInHierarchy){
			this.shots_left[1].transform.position=shotSpawn1.position;
			this.shots_left[1].transform.rotation=shotSpawn1.rotation;
			this.shots_left[1].SetActive(true);
			
			//	break;
		}
		if (shotSpawn2!=null)
		{
			if (!this.shots_right[2].activeInHierarchy){
				this.shots_right[2].transform.position=shotSpawn2.position;
				this.shots_right[2].transform.rotation=shotSpawn2.rotation;
				this.shots_right[2].SetActive(true);
				
				//	break;
			}
		}
		
	}
	void Fire ()
	{
		Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
		Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
		GetComponent<AudioSource>().Play();
	}
}
