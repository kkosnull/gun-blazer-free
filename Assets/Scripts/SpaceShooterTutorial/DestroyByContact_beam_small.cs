using UnityEngine;
using System.Collections;

public class DestroyByContact_beam_small : MonoBehaviour
{
	public GameObject[] gameobjects;
	public GameObject explosion;
	public GameObject rocket_explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	public float enemy_life;
	private LineRenderer objectLineRenderer;


	void OnTriggerEnter (Collider other)
	{



		if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "Powerup1" || other.tag == "Powerup2" || other.tag == "Player" )
		{
			return;
		}






	}

}