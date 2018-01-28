using UnityEngine;
using System.Collections;

public class Disable_electric_field : MonoBehaviour
{
	private GameController gameController;


	void Start ()
	{

		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		gameController = gameControllerObject.GetComponent <GameController>();

	}

	void FixedUpdate ()
	{
		if (transform.position.z < -13) 
		{

			gameObject.SetActive(false);
			gameController.spawn_flag=1;


		}
	}



}