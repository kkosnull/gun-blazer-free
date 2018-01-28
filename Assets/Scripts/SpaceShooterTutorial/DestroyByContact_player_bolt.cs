using UnityEngine;
using System.Collections;

public class DestroyByContact_player_bolt : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	private GameController gameController;
	private int hits=1;


	void Start ()
	{
		
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}

	}


	void OnTriggerEnter (Collider other)
	{
		//Debug.Log ("!DestroyByContact.OnTriggerEnter() this.tag:" + this.tag + " other.tag:" + other.tag);
		
		if ((other.tag == "Enemy" || other.tag == "Enemy_pool") && !other.gameObject.name.StartsWith ("Bolt")) {

			this.hits += 1;
			if (this.tag == "Bolt_laser" && this.hits > 4) {
				

				this.gameObject.SetActive (false);
				this.hits = 1;
				
			}
			if (this.tag == "bolt_plasma" && this.hits > 2) {
				

				this.gameObject.SetActive (false);
				this.hits = 1;
				
			}
			if (this.tag == "gatling_bolt" && this.tag == "bolt_rocket" && (other.tag == "Enemy_pool" || other.tag == "beam_laser" || other.tag == "beam_laser1")) {

				this.gameObject.SetActive (false);
				
				
			}

			if (this.tag == "Bolt") {
				
				//Destroy (this.gameObject);
				this.gameObject.SetActive (false);
			}
			if (this.tag == "bolt_laser_rapid") {
				
				//Destroy (this.gameObject);
				this.gameObject.SetActive (false);
			}
			if (this.tag == "gatling_bolt") {
				
				this.gameObject.SetActive (false);
			}
			if (this.tag == "bolt_mega_shot") {
				
				//Destroy (this.gameObject);
				this.gameObject.SetActive (false);
			}
			if (this.tag == "Bolt_DOUBLE") {
				
				//Destroy (this.gameObject);
				this.gameObject.SetActive (false);
			}
		} 
		
		
	}
}