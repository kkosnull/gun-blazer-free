using UnityEngine;
using System.Collections;


public class mover_circular : MonoBehaviour
{
	
	public float speed;
	public Transform target;



	void Start ()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	
	}

	void FixedUpdate ()
	{
		GetComponent<Rigidbody>().transform.LookAt(target);

		
	}


	
	
}