using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyByContact_seeker : MonoBehaviour
{

	public GameObject explosion;
	public GameObject rocket_explosion;
	public GameObject playerExplosion;

	public GameObject[] gameobjects;

	public int scoreValue;
	public float enemy_life;
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

		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
	
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController.skill_level==0)
			{
			enemy_life=50;
			}
		else if (gameController.skill_level==1)
		{
			enemy_life=100;
		}
		else if (gameController.skill_level==2)
		{
			enemy_life=160;
		}
		else if (gameController.skill_level==3)
		{
			enemy_life=250;
		}

	


	
}

		


		void OnTriggerEnter (Collider other)
	{

		string playerbolt = other.tag;
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
		/*
		if (other.tag == "Bolt"){

			enemy_life-=this.damage_bolt;

		}
		if (other.tag == "bolt_laser_rapid"){
			enemy_life-=this.damage_rapid;
		}
		if (other.tag == "Bolt_double"){
			enemy_life-=this.damage_double;
		}
		if (other.tag == "bolt_plasma"){
			enemy_life-=this.damage_plasma;
		}
		if (other.tag == "Bolt_laser"){
			enemy_life-=this.damage_bolt_laser;
		}
		if (other.tag == "gatling_bolt"){
			enemy_life-=this.damage_bolt;
		}
		if (other.tag == "bolt_mega_shot"){
			enemy_life-=500;
		}
		if (other.tag == "bolt_rocket"){


			other.gameObject.SetActive(false);
			gameController.explode_rocket(this.transform.position, this.transform.rotation);

			enemy_life-=this.damage_rocket;
		}
*/

		if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "Powerup1" || other.tag == "Powerup2" || other.tag == "beam_laser" || other.tag == "beam_laser1" )
		{
			return;
		}




		if (other.tag == "Player" )
		{

			//Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.explode_player(this.transform.position, this.transform.rotation);
			gameController.player_shot();
			enemy_life-=20;


		}



		if(enemy_life<=0 ){
			gameController.AddScore(scoreValue);
			gameController.explode(this.transform.position, this.transform.rotation);
			gameObject.SetActive(false);

			//gameObject.SetActiveRecursively(false);
		}

	}



}