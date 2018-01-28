using UnityEngine;
using System.Collections;


public class Mover1 : MonoBehaviour
{
	public float speed;

	void Start ()
	{

	GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}



}
