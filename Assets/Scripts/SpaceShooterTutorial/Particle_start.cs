using UnityEngine;
using System.Collections;

public class Particle_start : MonoBehaviour
{
	public ParticleSystem rocket_trail;

	void Start()
	{
	 rocket_trail= GetComponent<ParticleSystem>();
		StartCoroutine (play_trail_particles());
	}


	private IEnumerator play_trail_particles()
	{
		yield return new WaitForSeconds(0.2f);
		rocket_trail.Play ();
	}



}