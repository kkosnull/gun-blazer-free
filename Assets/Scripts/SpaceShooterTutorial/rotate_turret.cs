using UnityEngine;
using System.Collections;

public class rotate_turret : MonoBehaviour 
{

	
	void FixedUpdate  ()
	{
		GetComponent<Rigidbody>().transform.Rotate((float)1, 0, 0);
		//GetComponent<Rigidbody>().transform.Rotate(Vector3.right * Time.deltaTime);
	}
}