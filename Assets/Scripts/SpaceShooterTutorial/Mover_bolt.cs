using UnityEngine;
using System.Collections;


public class Mover_bolt : MonoBehaviour
{

	public float speed_bolt;

	void Start ()
	{
		GetComponent<Rigidbody> ().velocity = transform.forward * speed_bolt;
	}



}
