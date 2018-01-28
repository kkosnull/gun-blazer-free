using UnityEngine;
using System.Collections;


public class turret_lookat : MonoBehaviour
{
	public Transform target;
	private Transform myTransform;
	


	void Update () 
	{

		GetComponent<Rigidbody> ().transform.LookAt(target.position);
	}




}
