using UnityEngine;
using System.Collections;


public class checkpoint_core_pulse : MonoBehaviour
{



	void Update()
	{

		StartCoroutine(pulse());

	}
	IEnumerator pulse()
	{
		scaleup();
		yield return new WaitForSeconds(0.1f);
		scaledown();


	}

	void scaleup(){
		transform.localScale += new Vector3 (0.4f, 0, 0.4f);
	}
	void scaledown(){
		transform.localScale -= new Vector3 (0.4f, 0, 0.4f);
	}



// power up and down laser







}
