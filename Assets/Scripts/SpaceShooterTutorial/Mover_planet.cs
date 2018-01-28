using UnityEngine;
using System.Collections;


public class Mover_planet : MonoBehaviour
{
	public float speed;

	void Start ()
	{
	
	GetComponent<Rigidbody>().velocity = transform.forward * speed;

	}




}
