using UnityEngine;
using System.Collections;


public class DestroyByBoundary : MonoBehaviour
{



	void OnTriggerExit (Collider other) 
	{

		if (other.gameObject.tag=="Powerup_double" 
		    || other.gameObject.tag=="Powerup2"
		    || other.gameObject.tag=="power_up_plasma"
		    || other.gameObject.tag=="power_up_rocket"
		    || other.gameObject.tag=="Powerup1"
		    || other.gameObject.tag=="power_up_tripple"
		    || other.gameObject.tag=="power_up_nuke"
		    || other.gameObject.name.StartsWith ("Bolt")
		    || other.gameObject.name.StartsWith ("gatling")
		    || other.gameObject.tag=="Enemy_pool" 
		    || other.gameObject.tag=="powerup_laser"
		    || other.gameObject.tag=="powerup_minigun")  
		{

			if (other.gameObject.GetComponent<EvasiveManeuver>()!= null)
			{
				
				other.gameObject.GetComponent<EvasiveManeuver>().StopCoroutine("Evade");
				
			}
			if (other.gameObject.GetComponent<EvasiveManeuver_laserbot>()!= null)
			{
				
				other.gameObject.GetComponent<EvasiveManeuver_laserbot>().StopCoroutine("Evade");
				
			}

			if (other.gameObject.GetComponent<WeaponController_droid_brain>()!= null)
			{
				
				other.gameObject.GetComponent<WeaponController_droid_brain>().CancelInvoke("Shoot");
				
			}
			if (other.gameObject.GetComponent<WeaponController>()!= null)
			{
				
				other.gameObject.GetComponent<WeaponController>().CancelInvoke("Shoot");
				
			}
			if (other.gameObject.GetComponent<WeaponController_raven>()!= null)
			{
				
				other.gameObject.GetComponent<WeaponController_raven>().CancelInvoke("Shoot");
				
			}
			if (other.gameObject.GetComponent<WeaponController_d66>()!= null)
			{

				other.gameObject.GetComponent<WeaponController_d66>().CancelInvoke("Shoot");

			}
			if (other.gameObject.GetComponent<WeaponController_d58>()!= null)
			{
				
				other.gameObject.GetComponent<WeaponController_d58>().CancelInvoke("Shoot");
			
			}
			other.gameObject.SetActive(false);
			//CancelInvoke();


		}

		 if (other.gameObject.name.StartsWith ("Bolt")) {
			other.gameObject.SetActive (false);
		}
		 if (other.gameObject.name.StartsWith ("gatling")) {
			other.gameObject.SetActive (false);
		}
		 


	}
}