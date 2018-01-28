using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class power_up_contact_nuke : MonoBehaviour
{

	public GameObject explosion;
	public GameObject explosion_nuke;
	public GameObject[] gameobjects;
	public GameObject[] gameobjects_old;
	private GameController gameController;

	// nuke boom sound
	public AudioClip impact;
	AudioSource audio;


	void Start() {
		audio = GetComponent<AudioSource>();
	}

	void OnTriggerEnter (Collider other)
	{

		
		if (other.tag == "Player")
		{

			Instantiate(explosion, other.transform.position, other.transform.rotation);
			this.gameObject.SetActive (false);
			gameobjects = GameObject.FindGameObjectsWithTag ("Enemy_pool");
			audio.PlayOneShot(impact, 0.7F);
			if (gameobjects.Length>0){


				GameObject g = GameObject.Find("Main Camera");
				CameraShake shakeDuration = g.GetComponent<CameraShake>();
				shakeDuration.shakeDuration = (float)0.6;

				for(var i = 0 ; i < gameobjects.Length ; i ++)
				{
					
					//Destroy(gameobjects[i]);
					
					if (gameobjects[i].GetComponent<WeaponController_droid_brain>()!= null)
					{
						
						gameobjects[i].GetComponent<WeaponController_droid_brain>().CancelInvoke("Shoot");
						
					}
					
					if (gameobjects[i].GetComponent<WeaponController>()!= null)
					{
						
						gameobjects[i].GetComponent<WeaponController>().CancelInvoke("Shoot");
						
					}
					if (gameobjects[i].GetComponent<WeaponController_raven>()!= null)
					{
						
						gameobjects[i].GetComponent<WeaponController_raven>().CancelInvoke("Shoot");
						
					}
					if (gameobjects[i].GetComponent<WeaponController_d66>()!= null)
					{
						
						gameobjects[i].GetComponent<WeaponController_d66>().CancelInvoke("Shoot");
						//gameObject.GetComponent<WeaponController_d66>().StopCoroutine("rapid");
						
					}
					if (gameobjects[i].GetComponent<WeaponController_d58>()!= null)
					{
						
						gameobjects[i].GetComponent<WeaponController_d58>().CancelInvoke("Shoot");
						//gameObject.GetComponent<WeaponController_d58>().StopCoroutine("rapid");
					}
				
					if (gameObject.GetComponent<WeaponController_big_brain>()!= null)
					{
						
						gameobjects[i].GetComponent<WeaponController_big_brain>().CancelInvoke("Shoot");
						
						//gameObject.GetComponent<WeaponController_d58>().StopCoroutine("rapid");
					}


					gameobjects[i].SetActive(false);
					Instantiate(explosion_nuke, gameobjects[i].transform.position, gameobjects[i].transform.rotation);
					
				}


			}


		
	}
	
}
}