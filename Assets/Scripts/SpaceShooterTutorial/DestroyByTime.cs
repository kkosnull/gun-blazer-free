using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour
{
	public float lifetime;
	public GameObject explosion_time;

	void Start ()
	{
		//Instantiate (explosion_time, transform.position, transform.rotation);
		Destroy (gameObject, lifetime);
	}
}
