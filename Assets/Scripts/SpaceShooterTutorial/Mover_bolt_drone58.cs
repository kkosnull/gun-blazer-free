using UnityEngine;
using System.Collections;


public class Mover_bolt_drone58 : MonoBehaviour
{
	public float speed;

	void Start ()
	{

	GetComponent<Rigidbody>().velocity = transform.forward * speed;
	
	}



}
