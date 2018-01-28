using UnityEngine;
using System.Collections;

public class DestroyByContact_player_rocket : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	private float speed;
	private GameController gameController;
	public Rigidbody rb;

	public void Start(){

		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}

	}
	void OnTriggerEnter (Collider other)
	{

		if (other.tag=="BoltEnemy" || !other.gameObject.name.StartsWith ("Bolt") || other.tag == "beam_laser" || other.tag == "beam_laser1" || other.tag=="Player")
		{
			return;
		}
		else if (other.tag=="Enemy_pool")
		{
			gameObject.SetActive(false);
		}
			
}



}