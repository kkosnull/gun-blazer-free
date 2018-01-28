using UnityEngine;
using System.Collections;

public class DestroyByContact_mine : MonoBehaviour
{
	public GameObject[] gameobjects;
	public GameObject explosion;

	public GameObject rocket_explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	public float enemy_life;
	private int damage_bolt=60;
	private int damage_double=70;
	private int damage_plasma=100;
	private int damage_rocket=400;
	private GameController gameController;


	void Start ()
	{

		if (Time.time>180 && Time.time<480){
			enemy_life = enemy_life + (float)15;
		}
		if (Time.time>480 && Time.time<720){
			enemy_life = enemy_life + (float)15;
		}
		if (Time.time>480 && Time.time<600){
			enemy_life = enemy_life + (float)15;
		}
		if (Time.time>600 ){
			enemy_life = enemy_life + (float)30;
		}


		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
			}




	void OnTriggerEnter (Collider other)
	{

		//Debug.Log ("DestroyByContact.OnTriggerEnter() this.tag:" + this.tag + " other.tag:" + other.tag);
		if (other.tag == "Bolt") {
			enemy_life -= this.damage_bolt;
		}
		if (other.tag == "Bolt_double") {
			enemy_life -= this.damage_double;
		}
		if (other.tag == "bolt_plasma") {
			enemy_life -= this.damage_plasma;
		}
		if (other.tag == "gatling_bolt"){
			enemy_life-=this.damage_bolt;
		}
		if (other.tag == "bolt_rocket") {


	
			/*
			gameobjects = GameObject.FindGameObjectsWithTag ("Enemy");
			for(var i = 0 ; i < gameobjects.Length ; i ++)
			{

				Destroy(gameobjects[i]);
				Instantiate(rocket_explosion, gameobjects[i].transform.position, gameobjects[i].transform.rotation);
			}
*/
			enemy_life-=this.damage_rocket;
		}

		if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "Powerup1" || other.tag == "Powerup2" || other.tag == "beam_laser" || other.tag == "beam_laser1" )
		{
			return;
		}

		if (explosion != null && other.tag != "Player")
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}

//		gameController.AddScore(scoreValue);

		if (other.tag == "Player" )
		{

			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.player_hit_mine();
			enemy_life-=20;
			//gameObject.SetActive(false);
			//if(gameController.lives==0){gameController.GameOver();}

		}
//		if (gameController.life<=0){
//			Destroy (other.gameObject);
//		}

		//Destroy (other.gameObject);
		if(enemy_life<=0 ){
			Instantiate(explosion, transform.position, transform.rotation);
			if (GetComponent<WeaponController>()!= null)
			{

				GetComponent<WeaponController>().CancelInvoke("Shoot");

			}
			if (GetComponent<WeaponController_raven>()!= null)
			{
				
				GetComponent<WeaponController_raven>().CancelInvoke("Shoot");
				
			}

			gameObject.SetActive(false);

			//gameObject.SetActiveRecursively(false);
		}

	}

}