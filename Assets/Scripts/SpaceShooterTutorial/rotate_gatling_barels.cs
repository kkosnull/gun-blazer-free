using UnityEngine;
using System.Collections;

public class rotate_gatling_barels : MonoBehaviour 
{

	
	void FixedUpdate  ()
	{
		GetComponent<Rigidbody>().transform.Rotate(0, 0, (float)7);
		//GetComponent<Rigidbody>().transform.Rotate(Vector3.right * Time.deltaTime);
	}
}