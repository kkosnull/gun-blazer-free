using UnityEngine;
using System.Collections;

public class rotate_planet : MonoBehaviour 
{

	
	void FixedUpdate  ()
	{
		GetComponent<Rigidbody>().transform.Rotate(0, (float)0.2, 0);
		//GetComponent<Rigidbody>().transform.Rotate(Vector3.right * Time.deltaTime);
	}
}