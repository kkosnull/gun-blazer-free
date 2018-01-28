using UnityEngine;
using System.Collections;

public class rotate_player : MonoBehaviour 
{

	
	void FixedUpdate  ()
	{
		GetComponent<Rigidbody>().transform.Rotate(0, 0, (float)1.5);
		//GetComponent<Rigidbody>().transform.Rotate(Vector3.right * Time.deltaTime);
	}
}