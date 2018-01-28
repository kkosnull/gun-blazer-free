using UnityEngine;
using System.Collections;


public class exit_game : MonoBehaviour
{

	void Update()
	{
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
				if(vHit.transform.tag == "exit_game") 
				{
					Application.Quit();
				}
			}
		}
	}



				
	






}
