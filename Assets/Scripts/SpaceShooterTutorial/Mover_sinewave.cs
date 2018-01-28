using UnityEngine;
using System.Collections;


public class Mover_sinewave : MonoBehaviour
{
	float amplitudeX = 3.0f;
	float omegaX = 1.0f;
	float index;
	public float speed;
	
	void Start ()
	{
		
		//GetComponent<Rigidbody>().velocity = transform.forward * speed;
		
	}

	public void FixedUpdate(){
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
		index += Time.deltaTime;
		float x = amplitudeX*Mathf.Cos (omegaX*index);
		transform.localPosition= new Vector3(x,20,0);

	}



}
