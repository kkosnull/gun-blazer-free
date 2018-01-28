using UnityEngine;
using System.Collections;

public class DestroyByContact_enemy_shot : MonoBehaviour
{
	public GameObject[] gameobjects;
	public GameObject explosion;
	public GameObject rocket_explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	public float enemy_life;

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

		if (other.tag == "Boundary" || other.tag == "Bolt" || other.tag == "Bolt_double" || other.tag == "bolt_plasma" || other.tag == "Bolt_laser"|| other.tag == "bolt_rocket" || other.tag == "gatling_bolt" || other.tag == "bolt_laser_rapid" || other.tag == "bolt_mega_shot" || other.tag == "core_minion_boss_trigger")
		{
			return;
		}

		if (explosion != null && other.tag != "Player")
		{

			gameController.explode(this.transform.position, this.transform.rotation);
		}

		//gameController.AddScore(scoreValue);

		if (other.tag == "Player")
		{

			gameController.explode_player(this.transform.position, this.transform.rotation);
			gameController.player_shot();
			enemy_life-=20;


		}

//
//		if (gameController.life<=0){
//			Destroy (other.gameObject);
//		}
//	


	}

}