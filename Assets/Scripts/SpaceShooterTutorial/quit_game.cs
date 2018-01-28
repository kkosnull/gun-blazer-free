using UnityEngine;
using System.Collections;


public class quit_game : MonoBehaviour
{
	private Touch touch;

	void Update () 
	{
		if (Input.touchCount > 0 ) {
			
			this.touch = Input.GetTouch (0);
			switch (this.touch.phase) {
				
		
			case TouchPhase.Ended:
				Application.Quit();
				break;
			}
			
			
		} 

	}




}
