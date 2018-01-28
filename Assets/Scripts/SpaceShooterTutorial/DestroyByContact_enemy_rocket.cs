using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyByContact_enemy_rocket : MonoBehaviour
{

	public GameObject explosion;
	public GameObject rocket_explosion;
	public GameObject playerExplosion;

	public GameObject[] gameobjects;

	public int scoreValue;
	private float enemy_life;
	/*
	private int damage_bolt=60;
	private int damage_rapid=60;
	private int damage_double=70;
	private int damage_plasma=100;
	private int damage_rocket=400;
	private int damage_bolt_laser=800;
*/
	private GameController gameController;



	void Start ()
	{

		this.enemy_life = 10;
	
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
	
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}

	
}



		void OnTriggerEnter (Collider other)
	{

		string playerbolt = other.tag;
		if (gameController.boltsArray.Length>0)
		{
			foreach (string bolt in gameController.boltsArray)
			{
				if (bolt.Equals (playerbolt))
				{
					if (playerbolt=="bolt_rocket")
					{
						other.gameObject.SetActive(false);
						gameController.explode_rocket(this.transform.position, this.transform.rotation);
						this.enemy_life-=gameController.damage_rocket;
					}
					else 
					{
						gameController.explode(this.transform.position, this.transform.rotation);
						this.enemy_life-=gameController.damage;
					}
				}
			}

		}
	

		/*

		if (other.tag == "Bolt"){

			this.enemy_life-=this.damage_bolt;

		}
		if (other.tag == "bolt_laser_rapid"){
			this.enemy_life-=this.damage_rapid;
		}
		if (other.tag == "Bolt_double"){
			enemy_life-=this.damage_double;
		}
		if (other.tag == "bolt_plasma"){
			this.enemy_life-=this.damage_plasma;
		}
		if (other.tag == "Bolt_laser"){
			this.enemy_life-=this.damage_bolt_laser;
		}
		if (other.tag == "gatling_bolt"){
			this.enemy_life-=this.damage_bolt;
		}
		if (other.tag == "bolt_mega_shot"){
			this.enemy_life-=500;
		}
		if (other.tag == "bolt_rocket"){

			//Destroy (other.gameObject);
			other.gameObject.SetActive(false);
			//Instantiate (rocket_explosion, other.transform.position, other.transform.rotation);
			gameController.explode_rocket(this.transform.position, this.transform.rotation);

			this.enemy_life-=this.damage_rocket;
		}

*/

		if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "Powerup1" || other.tag == "Powerup2" || other.tag == "beam_laser" || other.tag == "beam_laser1" || other.tag == "core_minion_boss_trigger")
		{
			return;
		}

		if (other.tag == "Player") 
		{
			gameController.explode(other.transform.position, other.transform.rotation);
			gameController.player_shot();
			if (gameObject.GetComponent<Mover_rocket_enemy>()!= null)
			{
				
				gameObject.GetComponent<Mover_rocket_enemy>().StopCoroutine("start_follow");
			}
			gameObject.SetActive(false);
			
		}

		//Destroy (other.gameObject);
		if(this.enemy_life<=0){
			gameController.AddScore(scoreValue);
			gameController.explode(this.transform.position, this.transform.rotation);
			if (gameObject.GetComponent<Mover_rocket_enemy>()!= null)
			{
				
				gameObject.GetComponent<Mover_rocket_enemy>().StopCoroutine("start_follow");
			}
			gameObject.SetActive(false);

			//gameObject.SetActiveRecursively(false);
		}

	}
	public void hit_by_beam()
	{
		enemy_life -= 100;
		if (enemy_life <= 0) {
			gameController.explode_rocket(this.transform.position, this.transform.rotation);
			gameController.AddScore (scoreValue);
			gameObject.SetActive(false);
			this.enemy_life=10;
		}
	}

}