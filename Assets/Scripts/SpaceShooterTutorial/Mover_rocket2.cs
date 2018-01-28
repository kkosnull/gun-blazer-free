using UnityEngine;
using System.Collections;


public class Mover_rocket2 : MonoBehaviour
{
	
	public float speed_bolt;
	
	//sine wave motion
	
	float amplitudeX = 3.0f;
	float omegaX = 15.0f;
	float index;

	//target
	private GameObject enemy_target;
	private Transform target;
	private GameController gameController;

	void Start ()
	{
		
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
	}
	void FixedUpdate  ()
	{
	
		StartCoroutine(destroy_me());

		GetComponent<Rigidbody> ().velocity = transform.forward * speed_bolt;
		if (GameObject.FindGameObjectWithTag ("Enemy_pool")) 
		{
			enemy_target = GameObject.FindGameObjectWithTag ("Enemy_pool");
			target = enemy_target.transform;
			
		} else if (GameObject.FindGameObjectWithTag ("torus")) 
		{
			enemy_target = GameObject.FindGameObjectWithTag ("torus");
			target = enemy_target.transform;
			
		} 
		if (target) 
		{
			
			if (!enemy_target.activeSelf) 
			{
				index += Time.deltaTime;
				float x = amplitudeX*Mathf.Cos (omegaX*index);
				
				GetComponent<Rigidbody> ().velocity = new Vector3(x, 0, 19);
				transform.LookAt(new Vector3(x, 0, 30));
			}
			else 
			{
			transform.rotation = Quaternion.LookRotation (target.transform.position - transform.position);
			}
		} 
		else // if target is null
		{
			index += Time.deltaTime;
			float x = amplitudeX*Mathf.Cos (omegaX*index);
			
			GetComponent<Rigidbody> ().velocity = new Vector3(x, 0, 19);
			transform.LookAt(new Vector3(x, 0, 30));
		}

	}
	
	private IEnumerator destroy_me()
	{
		yield return new WaitForSeconds (1.5f);
		gameObject.SetActive(false);
		gameController.explode_rocket(this.transform.position, this.transform.rotation);
		
	}
	
	
}
