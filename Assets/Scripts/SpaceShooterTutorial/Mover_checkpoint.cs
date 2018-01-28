using UnityEngine;
using System.Collections;


public class Mover_checkpoint : MonoBehaviour
{
	public float speed;

	void Start ()
	{

	GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}



}
