using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyByContact : MonoBehaviour
{
	public int explosion1_drone_index;
	public int explosion2_drone_index;
	public int explosion3_drone_index;
	List<GameObject> explosions_drone1;
	List<GameObject> explosions_drone2;
	List<GameObject> explosions_drone3;

	public GameObject[] gameobjects;
	public GameObject explosion;
	public GameObject rocket_explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	public float enemy_life_droid;
	private int damage_bolt=60;
	private int damage_rapid=60;
	private int damage_double=70;
	private int damage_plasma=100;
	private int damage_rocket=400;
	private int damage_bolt_laser=800;

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
			enemy_life_droid=100;
		}
		else if (gameController.skill_level==1)
		{
			enemy_life_droid=300;
		}
		else if (gameController.skill_level==2)
		{
			enemy_life_droid=550;
		}

		if (Time.time>180 && Time.time<480){
			enemy_life_droid = enemy_life_droid + (float)15;
		}
		if (Time.time>480 && Time.time<720){
			enemy_life_droid = enemy_life_droid + (float)15;
		}
		if (Time.time>480 && Time.time<600){
			enemy_life_droid = enemy_life_droid + (float)15;
		}
		if (Time.time>600 ){
			enemy_life_droid = enemy_life_droid + (float)30;
		}


}




	void OnTriggerEnter (Collider other)
	{

		//Debug.Log ("DestroyByContact.OnTriggerEnter() this.tag:" + this.tag + " other.tag:" + other.tag);
		if (other.tag == "Bolt"){
			enemy_life_droid-=this.damage_bolt;
		}
		if (other.tag == "bolt_laser_rapid"){
			enemy_life_droid-=this.damage_rapid;
		}
		if (other.tag == "Bolt_double"){
			enemy_life_droid-=this.damage_double;
		}
		if (other.tag == "bolt_plasma"){
			enemy_life_droid-=this.damage_plasma;
		}
		if (other.tag == "Bolt_laser"){
			enemy_life_droid-=this.damage_bolt_laser;
		}
		if (other.tag == "gatling_bolt"){
			enemy_life_droid-=this.damage_bolt;
		}
		if (other.tag == "bolt_mega_shot"){
			enemy_life_droid-=500;
		}
		if (other.tag == "bolt_rocket"){

			//Destroy (other.gameObject);
			other.gameObject.SetActive(false);
			//Instantiate (rocket_explosion, other.transform.position, other.transform.rotation);
			gameController.explode_rocket(this.transform.position, this.transform.rotation);
			//Spawn_explosion2();
			enemy_life_droid-=this.damage_rocket;
		}

		if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "Powerup1" || other.tag == "Powerup2" || other.tag == "beam_laser" || other.tag == "beam_laser1" )
		{
			return;
		}

		if (explosion != null && other.tag != "Player")
		{

			gameController.explode(this.transform.position, this.transform.rotation);

		}



		if (other.tag == "Player")
		{
			//Debug.Log ("TEST!!");
			gameController.explode_player(other.transform.position, other.transform.rotation);
		
			gameController.player_shot();


		}




		if(enemy_life_droid<=0){
		
			gameController.explode(this.transform.position, this.transform.rotation);
			gameController.AddScore(scoreValue);


			if (gameObject.GetComponent<WeaponController_d66>()!= null)
			{
				
				gameObject.GetComponent<WeaponController_d66>().CancelInvoke("rapid");
				
			}
			if (gameObject.GetComponent<WeaponController_d58>()!= null)
			{
				
				gameObject.GetComponent<WeaponController_d58>().CancelInvoke("rapid");
				
			}
			gameObject.SetActive(false);
		}

	}




}