using UnityEngine;
using System.Collections;


public class DestroyByBoundary2 : MonoBehaviour
{



	void OnTriggerExit (Collider other) 
	{

		if (other.gameObject.tag=="BoltEnemy")  
		{

			other.gameObject.SetActive(false);
			//CancelInvoke();


		}


	}
}