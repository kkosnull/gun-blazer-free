using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DestroyByContact_torus : MonoBehaviour
{
	public int explosion1_torus_index;
	public int explosion3_torus_index;
	List<GameObject> explosions_torus1;
	List<GameObject> explosions_torus2;
	List<GameObject> explosions_torus3;

	public GameObject[] gameobjects;
	public GameObject explosion;
	public GameObject big_explosion;
	public GameObject rocket_explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	public float enemy_life;
	private int damage_bolt=60;
	private int damage_rapid=60;
	private int damage_double=70;
	private int damage_plasma=100;
	private int damage_rocket=400;
	private int damage_bolt_laser=800;
	private GameController gameController;
	private MeshRenderer renderer;
	public Vector3 offset = new Vector3( 0, 0, 1 );



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
		
		//Debug.Log ("DestroyByContact.OnTriggerEnter() this.tag:" + this.tag + " other.tag:" + other.tag);
		if (other.tag == "Bolt"){
			gameController.explode(this.transform.position, this.transform.rotation);
			enemy_life-=this.damage_bolt;
		}
		if (other.tag == "bolt_laser_rapid"){
			gameController.explode(this.transform.position, this.transform.rotation);
			enemy_life-=this.damage_rapid;
		}

		if (other.tag == "Bolt_double"){
			gameController.explode(this.transform.position, this.transform.rotation);
			enemy_life-=this.damage_double;
		}
		if (other.tag == "bolt_plasma"){
			gameController.explode(this.transform.position, this.transform.rotation);
			enemy_life-=this.damage_plasma;
		}
		if (other.tag == "Bolt_laser"){
			gameController.explode(this.transform.position, this.transform.rotation);
			enemy_life-=this.damage_bolt_laser;
		}
		if (other.tag == "gatling_bolt"){
			gameController.explode(this.transform.position, this.transform.rotation);
			enemy_life-=this.damage_bolt;
		}
		if (other.tag == "bolt_mega_shot"){
			gameController.explode(this.transform.position, this.transform.rotation);
			enemy_life-=200;
		}
		
		if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "Powerup1" || other.tag == "Powerup2" || other.tag == "beam_laser" || other.tag == "beam_laser1" )
		{
			return;
		}
		if (other.tag == "bolt_rocket"){
			
			//Destroy (other.gameObject);
			other.gameObject.SetActive(false);
			gameController.explode_rocket(this.transform.position, this.transform.rotation);
			
			enemy_life-=this.damage_rocket;
		}
		if (explosion != null && other.tag != "Player")
		{
			//Instantiate(explosion, transform.position-offset, transform.rotation);
			//gameController.explode(this.transform.position, this.transform.rotation);
			gameController.explode(new Vector3(this.transform.position.x , this.transform.position.y ,this.transform.position.z -2), this.transform.rotation);
			//gameController.explode(new Vector3(this.transform.position.x-1 , this.transform.position.y ,this.transform.position.z -1), this.transform.rotation);
			//gameController.explode(new Vector3(this.transform.position.x+1 , this.transform.position.y ,this.transform.position.z -1), this.transform.rotation);
			



		}
		
				
		
		if (other.tag == "Player" )
		{
			
			//Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.explode_player(other.transform.position, other.transform.rotation);
			gameController.player_shot();
			enemy_life-=20;
						
		}
//		if (this.gameController.life<=0){
//			Destroy (other.gameObject);
//		}
		
		//Destroy (other.gameObject);
		if(enemy_life<=0 ){
			gameController.play_music(1);
			gameController.AddScore(scoreValue);

			Instantiate(big_explosion, transform.position, transform.rotation);
			gameController.spawn_flag=0;
			gameController.shoot_flag=0;
			gameController.arc_flag=0;
			gameController.torus_flag=0;
			gameController.torus_is_dead=1;
			//Destroy (this.gameObject);
			gameController.EndGame();
		}
		
	}


	public void hit_by_beam()
	{
		enemy_life -= 100;
		if (enemy_life <= 0) 
		{
			gameController.play_music(1);
			gameController.AddScore(scoreValue);

			Instantiate(big_explosion, transform.position, transform.rotation);
			gameController.spawn_flag=0;
			gameController.shoot_flag=0;
			gameController.arc_flag=0;
			gameController.torus_flag=0;
			gameController.torus_is_dead=1;
			//Destroy (this.gameObject);
			gameController.EndGame();
		}
	}


	
}