using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class laser_beam_resize : MonoBehaviour
{
	private Renderer rend;
	private AudioSource sound;
	private BoxCollider collider;
	private Light[] lights;


	void Start() {
		rend = GetComponent<Renderer>();

		sound= GetComponent<AudioSource>();
		collider= GetComponent<BoxCollider>();
		rend.enabled = true;

		lights = GetComponentsInChildren<Light> (true);
		//flash_off ();

	}

	void Update()
	{
		bool oddeven = Mathf.FloorToInt(Time.time) % 4 == 0;
		StartCoroutine(pulse());
		rend.enabled = oddeven;
		sound.enabled = oddeven;
		collider.enabled = oddeven;

				lights [0].enabled = oddeven;
			

	}
	IEnumerator pulse()
	{
		scaleup();
		yield return new WaitForSeconds(0.1f);
		scaledown();


	}

	void scaleup(){

		transform.localScale += new Vector3 (0.03f, 0, 0);

	}
	void scaledown(){

		transform.localScale -= new Vector3 (0.03f, 0, 0);
	}



// power up and down laser






}
