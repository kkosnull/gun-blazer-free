using UnityEngine;
using System.Collections;

public class power_up_contact : MonoBehaviour
{

	public GameObject explosion;

	private GameController gameController;

	void Start()
	{
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
	}

	
	void OnTriggerEnter (Collider other)
	{

		
		if (other.tag == "Player")
		{
			//Instantiate(explosion, other.transform.position, other.transform.rotation);
			gameController.shock(this.transform.position, this.transform.rotation);
			gameObject.SetActive (false);


		
		
	}

}
}