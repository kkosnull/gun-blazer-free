using UnityEngine;
using System.Collections;


public class Mover_rocket1 : MonoBehaviour
{
	
	
	private GameObject enemy_target;
	private Transform target;
	public float speed_bolt;
	private GameController gameController;
	
	void Start ()
	{
		
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
	}
	
	void Update()
	{
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
		if (target) {
			
			if (!enemy_target.activeSelf) 
			{
				StartCoroutine(destroy_me_now());
			}
			transform.rotation = Quaternion.LookRotation (target.transform.position - transform.position);
		} else 
		{
			StartCoroutine(destroy_me());
		}
		
		
	}
	
	private IEnumerator destroy_me()
	{
		yield return new WaitForSeconds (0.5f);
		gameObject.SetActive(false);
		gameController.explode_rocket(this.transform.position, this.transform.rotation);
		
	}
	private IEnumerator destroy_me_now()
	{
		yield return new WaitForSeconds (0.0f);
		gameObject.SetActive(false);
		gameController.explode_rocket(this.transform.position, this.transform.rotation);
		
	}
	
}
