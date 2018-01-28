using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyByContact_pooled : MonoBehaviour
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
				if (this.name == "Enemy Ship") {
					this.enemy_life = 70;
				} 
				else if (this.name == "drone58_ray") {
					this.enemy_life = 70;
				} 
				else if (this.name == "Torus_boggiey_ray") {
					this.enemy_life = 80;
				} 
				else
				{
					this.enemy_life=50;
				}

			}
			else if (gameController.skill_level==1)
			{
				if (this.name == "Enemy Ship") 
				{
					this.enemy_life=120;
				} 
				else if (this.name == "Torus_boggiey_ray") {
					this.enemy_life = 140;
				} 
				else if (this.name == "drone58_ray") {
					this.enemy_life = 130;
				} 
				else
				{
					this.enemy_life=100;
				}
			
			}
			else if (gameController.skill_level==2)
			{
				if (this.name == "Enemy Ship") 
				{
					this.enemy_life=180;
				} 
				else if (this.name == "drone58_ray") {
					this.enemy_life = 190;
				} 
				else if (this.name == "Torus_boggiey_ray") {
					this.enemy_life = 190;
				} 
				else
				{
					this.enemy_life=160;
				}

			}
			else if (gameController.skill_level==3)
			{
				if (this.name == "Enemy Ship") 
				{
					this.enemy_life=220;
				} 
				else if (this.name == "drone58_ray") {
					this.enemy_life = 230;
				} 
				else if (this.name == "Torus_boggiey_ray") {
					this.enemy_life = 240;
				} 
				else
				{
					this.enemy_life=200;
				}

			}

		


}

		


		void OnTriggerEnter (Collider other)
	{
		string playerbolt = other.tag;
		Debug.Log (playerbolt);
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
			gameController.explode(this.transform.position, this.transform.rotation);
			this.enemy_life-=this.damage_bolt;

		}
		if (other.tag == "bolt_laser_rapid"){
			gameController.explode(this.transform.position, this.transform.rotation);
			this.enemy_life-=this.damage_rapid;
		}
		if (other.tag == "Bolt_double"){
			gameController.explode(this.transform.position, this.transform.rotation);
			this.enemy_life-=this.damage_double;
		}
		if (other.tag == "bolt_plasma"){
			gameController.explode(this.transform.position, this.transform.rotation);
			this.enemy_life-=this.damage_plasma;
		}
		if (other.tag == "Bolt_laser"){
			gameController.explode(this.transform.position, this.transform.rotation);
			this.enemy_life-=this.damage_bolt_laser;
		}
		if (other.tag == "gatling_bolt"){
			gameController.explode(this.transform.position, this.transform.rotation);
			this.enemy_life-=this.damage_bolt;
		}
		if (other.tag == "bolt_mega_shot"){
			gameController.explode(this.transform.position, this.transform.rotation);
			this.enemy_life-=200;
		}
		if (other.tag == "bolt_rocket"){


			other.gameObject.SetActive(false);
			gameController.explode_rocket(this.transform.position, this.transform.rotation);
			this.enemy_life-=this.damage_rocket;
		}
	*/

		if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "Powerup1" || other.tag == "Powerup2" || other.tag == "beam_laser" || other.tag == "beam_laser1" || other.tag == "boundary_turret" || other.tag == "core_minion_boss_trigger")
		{
			return;
		}





		if (other.tag == "Player" )
		{

			gameController.explode_player(this.transform.position, this.transform.rotation);
			gameController.player_shot();
			this.enemy_life-=20;


		}

		if(enemy_life<=0){
			gameController.AddScore(scoreValue);
			//Instantiate(explosion, transform.position, transform.rotation);
			//gameController.explode(this.transform.position, this.transform.rotation);

			if (gameObject.GetComponent<EvasiveManeuver>()!= null)
			{
				
				gameObject.GetComponent<EvasiveManeuver>().StopCoroutine("Evade");
				
			}
			if (gameObject.GetComponent<EvasiveManeuver_laserbot>()!= null)
			{
				
				gameObject.GetComponent<EvasiveManeuver_laserbot>().StopCoroutine("Evade");
				
			}

			if (gameObject.GetComponent<WeaponController_droid_brain>()!= null)
			{
				
				gameObject.GetComponent<WeaponController_droid_brain>().CancelInvoke("Shoot");
				
			}

			else if (gameObject.GetComponent<WeaponController>()!= null)
			{

				gameObject.GetComponent<WeaponController>().CancelInvoke("Shoot");

			}
			else if (gameObject.GetComponent<WeaponController_raven>()!= null)
			{
				
				gameObject.GetComponent<WeaponController_raven>().CancelInvoke("Shoot");
				
			}
			else if (gameObject.GetComponent<WeaponController_d66>()!= null)
			{
				
				gameObject.GetComponent<WeaponController_d66>().CancelInvoke("Shoot");
				//gameObject.GetComponent<WeaponController_d66>().StopCoroutine("rapid");
				
			}
			if (gameObject.GetComponent<WeaponController_d58>()!= null)
			{
				
				gameObject.GetComponent<WeaponController_d58>().CancelInvoke("Shoot");
				//gameObject.GetComponent<WeaponController_d58>().StopCoroutine("rapid");
			}

			if (gameController.skill_level==0)
			{
				if (this.name == "Enemy Ship") {
					this.enemy_life = 70;
				} 
				else if (this.name == "drone58_ray") {
					this.enemy_life = 70;
				} 
				else if (this.name == "Torus_boggiey_ray") {
					this.enemy_life = 80;
				} 
				else
				{
					this.enemy_life=50;
				}

			}
			else if (gameController.skill_level==1)
			{
				if (this.name == "Enemy Ship") 
				{
					this.enemy_life=120;
				} 
				else if (this.name == "Torus_boggiey_ray") {
					this.enemy_life = 140;
				} 
				else if (this.name == "drone58_ray") {
					this.enemy_life = 130;
				} 
				else
				{
					this.enemy_life=100;
				}

			}
			else if (gameController.skill_level==2)
			{
				if (this.name == "Enemy Ship") 
				{
					this.enemy_life=180;
				} 
				else if (this.name == "drone58_ray") {
					this.enemy_life = 190;
				} 
				else if (this.name == "Torus_boggiey_ray") {
					this.enemy_life = 190;
				} 
				else
				{
					this.enemy_life=160;
				}

			}
			else if (gameController.skill_level==3)
			{
				if (this.name == "Enemy Ship") 
				{
					this.enemy_life=220;
				} 
				else if (this.name == "drone58_ray") {
					this.enemy_life = 230;
				} 
				else if (this.name == "Torus_boggiey_ray") {
					this.enemy_life = 240;
				} 
				else
				{
					this.enemy_life=200;
				}

			}
			gameObject.SetActive(false);


			//gameObject.SetActiveRecursively(false);
		}

	}

	public void hit_by_beam()
	{
		if (Time.timeSinceLevelLoad<300)
		{
			this.enemy_life -= gameController.damage_beam1;
		}
		else 
		{
			this.enemy_life -= gameController.damage_beam2;
		}
		
		if (this.enemy_life <= 0) 
		{
			gameController.AddScore(scoreValue);

			if (gameObject.GetComponent<EvasiveManeuver>()!= null)
			{
				
				gameObject.GetComponent<EvasiveManeuver>().StopCoroutine("Evade");
				
			}
			if (gameObject.GetComponent<EvasiveManeuver_laserbot>()!= null)
			{
				
				gameObject.GetComponent<EvasiveManeuver_laserbot>().StopCoroutine("Evade");
				
			}
			if (gameObject.GetComponent<WeaponController_droid_brain>()!= null)
			{
				
				gameObject.GetComponent<WeaponController_droid_brain>().CancelInvoke("Shoot");
				
			}
			
			if (gameObject.GetComponent<WeaponController>()!= null)
			{
				
				gameObject.GetComponent<WeaponController>().CancelInvoke("Shoot");
				
			}
			if (gameObject.GetComponent<WeaponController_raven>()!= null)
			{
				
				gameObject.GetComponent<WeaponController_raven>().CancelInvoke("Shoot");
				
			}
			if (gameObject.GetComponent<WeaponController_d66>()!= null)
			{
				
				gameObject.GetComponent<WeaponController_d66>().CancelInvoke("Shoot");
				
				
			}
			if (gameObject.GetComponent<WeaponController_d58>()!= null)
			{
				
				gameObject.GetComponent<WeaponController_d58>().CancelInvoke("Shoot");
				//gameObject.GetComponent<WeaponController_d58>().StopCoroutine("rapid");
			}

			if (gameObject.GetComponent<WeaponController_big_brain>()!= null)
			{
				
				gameObject.GetComponent<WeaponController_big_brain>().CancelInvoke("Shoot");
				//gameObject.GetComponent<WeaponController_d58>().StopCoroutine("rapid");
			}
			
			if (gameController.skill_level==0)
			{
				if (this.name == "Enemy Ship") {
					this.enemy_life = 70;
				} 
				else if (this.name == "drone58_ray") {
					this.enemy_life = 70;
				} 
				else if (this.name == "Torus_boggiey_ray") {
					this.enemy_life = 80;
				} 
				else
				{
					this.enemy_life=50;
				}

			}
			else if (gameController.skill_level==1)
			{
				if (this.name == "Enemy Ship") 
				{
					this.enemy_life=120;
				} 
				else if (this.name == "Torus_boggiey_ray") {
					this.enemy_life = 140;
				} 
				else if (this.name == "drone58_ray") {
					this.enemy_life = 130;
				} 
				else
				{
					this.enemy_life=100;
				}

			}
			else if (gameController.skill_level==2)
			{
				if (this.name == "Enemy Ship") 
				{
					this.enemy_life=180;
				} 
				else if (this.name == "drone58_ray") {
					this.enemy_life = 190;
				} 
				else if (this.name == "Torus_boggiey_ray") {
					this.enemy_life = 190;
				} 
				else
				{
					this.enemy_life=160;
				}

			}
			else if (gameController.skill_level==3)
			{
				if (this.name == "Enemy Ship") 
				{
					this.enemy_life=220;
				} 
				else if (this.name == "drone58_ray") {
					this.enemy_life = 230;
				} 
				else if (this.name == "Torus_boggiey_ray") {
					this.enemy_life = 240;
				} 
				else
				{
					this.enemy_life=200;
				}

			}
			gameObject.SetActive(false);
		}
	}

}