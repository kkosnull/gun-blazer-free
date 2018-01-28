using UnityEngine;
using System.Collections;


public class Mover_rocket : MonoBehaviour
{
	
	public float speed_bolt;
	
	//sine wave motion
	
	float amplitudeX = 3.0f;
	float omegaX = 15.0f;
	float index;
	
	
	void FixedUpdate  ()
	{
		
		index += Time.deltaTime;
		float x = amplitudeX*Mathf.Cos (omegaX*index);
		
		
		//	GetComponent<Rigidbody> ().velocity = transform.forward * speed_bolt;
		//	transform.localPosition= new Vector3(x,0,7);
		GetComponent<Rigidbody> ().velocity = new Vector3(x, 0, 19);
		transform.LookAt(new Vector3(x, 0, 30));
	}
	
	
	
	
}
