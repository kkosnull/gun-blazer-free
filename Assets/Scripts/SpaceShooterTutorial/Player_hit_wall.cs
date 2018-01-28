using UnityEngine;
using System.Collections;

public class Player_hit_wall : MonoBehaviour
{

	public GameObject explosion;
	public GameObject explosion_bolt;
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



		if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "Powerup1" || other.tag == "Powerup2" || other.tag == "beam_laser" || other.tag == "beam_laser1" )
		{
			return;
		}


		if (other.tag == "Bolt" || other.tag == "bolt_laser_rapid" || other.tag == "Bolt_double" || other.tag == "bolt_plasma"
		    || other.tag == "Bolt_laser" ||  other.tag == "gatling_bolt" || other.tag == "bolt_rocket"  )
		{
			return;
		}



		if (other.tag == "Player" )
		{

			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			Instantiate(explosion, other.transform.position, other.transform.rotation);
			gameController.player_killed();
			//other. gameObject.GetComponent<Rigidbody>().AddForce (-150, 0, -150);


		}


			if (gameController.life<=0){

			Destroy (other.gameObject);
			}



		}

}


