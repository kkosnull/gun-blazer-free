using UnityEngine;
using System.Collections;


public class Mover_rail : MonoBehaviour
{
	public float speed_bolt;
	
	void FixedUpdate ()
	{
		GetComponent<Rigidbody> ().velocity = transform.forward * speed_bolt;
	}



}
