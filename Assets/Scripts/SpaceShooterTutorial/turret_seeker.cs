using UnityEngine;
using System.Collections;




public class turret_seeker : MonoBehaviour
{
	

	private GameObject enemy_target;
	private Transform target;
	private Vector3 targetPoint;
	private Quaternion targetRotation;



	void Update()
	{

		if (GameObject.FindGameObjectWithTag("Player"))
		{
			enemy_target = GameObject.FindGameObjectWithTag("Player");
			target = enemy_target.transform;

		}


		if (target) {
		//	transform.rotation = Quaternion.LookRotation(transform.position - target.transform.position);
		//	transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position);
			transform.LookAt(target);
		} 

	}
	

	
	
	
}
