using UnityEngine;
using System.Collections;

public class WeaponController_beam : MonoBehaviour
{
	public GameObject shot;
	public GameObject shot_secondary;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;


	void Start ()
	{

		InvokeRepeating ("Fire", delay, fireRate);
	}

	void Fire ()
	{
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		StartCoroutine(secondary());
		GetComponent<AudioSource>().Play();
	}

	IEnumerator secondary()
	{
		yield return new WaitForSeconds (1);
		Instantiate(shot_secondary, shotSpawn.position, shotSpawn.rotation);
		
		
	}

}
