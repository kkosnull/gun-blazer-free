using UnityEngine;
using System.Collections;

public class rotate_checkpoint_core_negative : MonoBehaviour 
{

	
	void FixedUpdate  ()
	{
		GetComponent<Rigidbody>().transform.Rotate(0, -0.3f, 0);
		//GetComponent<Rigidbody>().transform.Rotate(Vector3.right * Time.deltaTime);
	}
}