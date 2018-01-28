using UnityEngine;
using System.Collections;




public class minigun_seeker : MonoBehaviour
{
	

	private GameObject enemy_target;
	private Transform target;




	void Update()
	{

		if (GameObject.FindGameObjectWithTag("Enemy_pool"))
		{
			enemy_target = GameObject.FindGameObjectWithTag("Enemy_pool");
			target = enemy_target.transform;

		}
		else if (GameObject.FindGameObjectWithTag("torus"))
		{
			enemy_target = GameObject.FindGameObjectWithTag("torus");
			target = enemy_target.transform;
			
		}

		if (target) {
		//	transform.rotation = Quaternion.LookRotation(transform.position - target.transform.position);
			transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position);
		} 

	}
	

	
	
	
}
