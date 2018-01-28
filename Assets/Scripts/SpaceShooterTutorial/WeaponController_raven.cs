using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponController_raven : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn;
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
		

		if (!this.shots[1].activeInHierarchy){
			this.shots[1].transform.position=shotSpawn.position;
			this.shots[1].transform.rotation=shotSpawn.rotation;
			this.shots[1].SetActive(true);
			
			//	break;
		}
		
		
		//Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		
		//GetComponent<AudioSource>().Play();
	}

	  private void Fire (int i)
	{
		
		//yield return new WaitForSeconds (0.5f);


		if (!this.shots[i].activeInHierarchy){
			this.shots[i].transform.position=shotSpawn.position;
			this.shots[i].transform.rotation=shotSpawn.rotation;
			this.shots[i].SetActive(true);
				
			//	break;
			}
			
		
		//Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		
		//GetComponent<AudioSource>().Play();
	}
	public IEnumerator FireShots () {

		//Debug.Log ("LIFE : "+this.life);
		if(stopped==false){

			yield return new WaitForSeconds(1.4f);
			Fire(0);

		}
			


	}


}
