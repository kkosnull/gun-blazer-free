using UnityEngine;
using System.Collections;


public class Mover_rocket_enemy : MonoBehaviour
{

	public float speed_bolt;

	private GameObject enemy_target;
	private Transform target;
	private int follow_player=0;
	public Rigidbody rb;

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


			
			StartCoroutine (start_follow());
			if (GameObject.FindGameObjectWithTag("Player"))
			{
				enemy_target = GameObject.FindGameObjectWithTag("Player");
				target = enemy_target.transform;
				
			}
			
			if (target && this.follow_player==1) {
				
				transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position);
			} 
			
			GetComponent<Rigidbody> ().velocity = transform.forward * speed_bolt;
		


	}

	private IEnumerator start_follow()
	{
		yield return new WaitForSeconds(0.2f);
		this.follow_player = 1;
		StartCoroutine (destroy_me());
	}


	private IEnumerator destroy_me()
	{
		yield return new WaitForSeconds (1.8f);
		gameObject.SetActive(false);
		gameController.explode_rocket(this.transform.position, this.transform.rotation);

	}

}
