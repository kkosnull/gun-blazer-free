using UnityEngine;
using System.Collections;


public class DestroyByBoundary1 : MonoBehaviour
{
	private GameController gameController;
	void Start ()
	{
		
	
		
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
	}

	void OnTriggerExit (Collider other) 
	{

		 if (other.gameObject.tag=="torus") {
			other.gameObject.SetActive (false);
			gameController.spawn_flag=1;
			gameController.shoot_flag=1;
			//Destroy (other.gameObject);
		}



	}
}