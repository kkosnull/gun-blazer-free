using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponController_d66 : MonoBehaviour
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
		if (gameObject.active)
		{

			StartCoroutine (rapid66 ());
		}

		
		
	}
	

	public IEnumerator rapid66 () 
	{

		for (int i=0; i<=3; i++)
		{

			this.shots[i].SetActive(false);
			yield return new WaitForSeconds(0.09f);


				this.shots[i].transform.position=shotSpawn.position;
				this.shots[i].transform.rotation=shotSpawn.rotation;

				this.shots[i].SetActive(true);

				
				
			

		}

}


}
