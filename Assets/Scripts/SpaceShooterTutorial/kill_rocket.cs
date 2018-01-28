using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class kill_rocket : MonoBehaviour
{
	public GameObject main_player;
	private GameController gameController;


	void Start(){
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") 
		{

			gameController.explode(other.transform.position, other.transform.rotation);
			gameObject.SetActive(false);

		}

	}

	
	
}
