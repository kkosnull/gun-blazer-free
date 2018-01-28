using UnityEngine;
using System.Collections;


public class bullet_shoot_at_player : MonoBehaviour
{
	public Transform target;
	public float speed;
	
	void Start ()
	{
		//transform.LookAt(target);
		//GetComponent<Rigidbody> ().transform.LookAt(target.position);
		GetComponent<Rigidbody>().velocity = transform.forward * speed;

	}


}
