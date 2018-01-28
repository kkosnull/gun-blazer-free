using UnityEngine;
using System.Collections;

public class Player_zapped : MonoBehaviour
{

	public GameObject explosion;
	public GameObject playerExplosion;
	private GameController gameController;



	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}

}




	void OnTriggerEnter (Collider other)
	{



		if (other.tag == "Enemy_pool" || other.tag == "Powerup1" || other.tag == "Powerup2" )
		{
			return;
		}


		if (other.tag == "Player" )
		{

			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			Instantiate(explosion, other.transform.position, other.transform.rotation);
			gameController.player_zapped();



		}



		}

}


