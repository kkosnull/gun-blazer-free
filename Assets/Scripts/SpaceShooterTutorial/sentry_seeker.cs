using UnityEngine;
using System.Collections;




public class sentry_seeker : MonoBehaviour
{
	

	private GameObject enemy_target;
	private Transform target;
	private string target_tag;

	void Start()
	{
		target_tag="Enemy";
	}


	void Update()
	{


		if (GameObject.FindGameObjectWithTag (target_tag)) 
			{
			enemy_target = GameObject.FindGameObjectWithTag (target_tag);
				target = enemy_target.transform;
				transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position);
			}
			else 
			{
				return;
			}
		


	}
	

	
	
	
}
