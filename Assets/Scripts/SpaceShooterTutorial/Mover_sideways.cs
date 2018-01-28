using UnityEngine;
using System.Collections;


public class Mover_sideways
	: MonoBehaviour
{
	public float speed;

	void Start ()
	{

		GetComponent<Rigidbody>().velocity = transform.right * speed;
	}



}
