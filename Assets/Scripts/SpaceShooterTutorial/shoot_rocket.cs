using UnityEngine;
using System.Collections;



public class shoot_rocket : MonoBehaviour
{
	public GameObject rocketshot;
	public Transform rocketSpawn;
	public GameObject rocket_shoot;


	void Awake () {

		GetComponent<MeshRenderer>().enabled = false;

	}

	void Start(){
		rocket_shoot = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update(){
		if (Input.touchCount >= 1) 
		{
			// The pos of the touch on the screen
			Vector2 vTouchPos = Input.GetTouch(0).position;
			
			// The ray to the touched object in the world
			Ray ray = Camera.main.ScreenPointToRay(vTouchPos);
			
			// Your raycast handling
			RaycastHit vHit;
			if(Physics.Raycast(ray.origin,ray.direction, out vHit))
			{
				if(vHit.transform.tag == "rocket_trigger") 
				{
					rocket_shoot.GetComponent<PlayerController>().shoot_homming();
				}
			}
		}

	}

}
