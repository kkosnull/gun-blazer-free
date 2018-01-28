using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Destroy_final_boss : MonoBehaviour
{
	public int explosion1_boss_index;
	public int explosion3_boss_index;
	List<GameObject> explosions_boss1;
	List<GameObject> explosions_boss2;
	List<GameObject> explosions_boss3;
	public GameObject[] gameobjects;
	public GameObject explosion;
	public GameObject big_explosion;
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


//	void Awake(){
//		explosions_boss1 = new List<GameObject> ();
//		for (int i=0; i<=30; i++) {
//			GameObject obj_explosions1 = (GameObject)Instantiate(explosion, transform.position, transform.rotation);
//			obj_explosions1.SetActive (false);
//			explosions_boss1.Add (obj_explosions1);
//			
//		}
//		
//		explosions_boss3 = new List<GameObject> ();
//		for (int i=0; i<=30; i++) {
//			GameObject obj_explosions3 = (GameObject)Instantiate(playerExplosion, transform.position, transform.rotation);
//			obj_explosions3.SetActive (false);
//			explosions_boss3.Add (obj_explosions3);
//			
//		}
//	}

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

		if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "Powerup1" || other.tag == "Powerup2" || other.tag == "beam_laser" || other.tag == "beam_laser1" )
		{
			return;
		}

		if (explosion != null && other.tag != "Player")
		{
		//	Instantiate(explosion, transform.position, transform.rotation);
			//gameController.explode(this.transform.position, this.transform.rotation);
			gameController.explode(new Vector3(this.transform.position.x , this.transform.position.y ,this.transform.position.z -2), this.transform.rotation);
			//gameController.explode(new Vector3(this.transform.position.x-2 , this.transform.position.y ,this.transform.position.z -2), this.transform.rotation);
			//gameController.explode(new Vector3(this.transform.position.x+2 , this.transform.position.y ,this.transform.position.z -2), this.transform.rotation);

		}

		//gameController.AddScore(scoreValue);

		if (other.tag == "Player")
		{

			//Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.explode_player(this.transform.position, this.transform.rotation);
			gameController.player_shot();


		}



//		if (this.gameController.life<=0){
//			Destroy (other.gameObject);
//		}
		//Destroy (other.gameObject);
		if(enemy_life<=0){
			gameController.AddScore(scoreValue);
			Instantiate(big_explosion, transform.position, transform.rotation);

			MeshRenderer[] render = gameObject.GetComponentsInChildren<MeshRenderer>();
			render[0].enabled = false;
			render[1].enabled = false;
			render[2].enabled = false;
			render[3].enabled = false;
			render[4].enabled = false;
			GetComponentInChildren<laser_beam_resize_boss>().enabled=false;

			GetComponent<WeaponController_boss>().CancelInvoke("Fire");
			Destroy (other.gameObject);
			StartCoroutine(goto_start());

			//Destroy (gameObject);

		}

	}

	public IEnumerator goto_start() {
		

		yield return new WaitForSeconds(1.5f);
		Application.LoadLevel("End");
		
		
	}

	
	public void hit_by_beam()
	{
		
		enemy_life -= 100;
		if(enemy_life<=0){
			gameController.AddScore(scoreValue);
			Instantiate(big_explosion, transform.position, transform.rotation);
			
			MeshRenderer[] render = gameObject.GetComponentsInChildren<MeshRenderer>();
			render[0].enabled = false;
			render[1].enabled = false;
			render[2].enabled = false;
			render[3].enabled = false;
			render[4].enabled = false;
			GetComponentInChildren<laser_beam_resize_boss>().enabled=false;
			
			GetComponent<WeaponController_boss>().CancelInvoke("Fire");
			StartCoroutine(goto_start());
			
			//Destroy (gameObject);
			
		}
	}

}