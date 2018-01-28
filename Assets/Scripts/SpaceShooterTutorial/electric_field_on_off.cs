using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class electric_field_on_off : MonoBehaviour
{
	private Renderer rend;
	private AudioSource sound;
	private BoxCollider collider;
	private Light[] lights;


	void Start() {
		rend = GetComponent<Renderer>();
		sound= GetComponent<AudioSource>();
		collider= GetComponent<BoxCollider>();
		rend.enabled = false;
		//StartCoroutine(pulse());
		//flash_off ();

	}

	void Update()
	{
		bool oddeven = Mathf.FloorToInt(Time.time) % 4 == 0;
		if (oddeven==true){StartCoroutine(pulse());}

	}
	IEnumerator pulse()
	{
		field_on();
		yield return new WaitForSeconds(1.5f);
		field_off();


	}

	void field_on(){

		rend.enabled = true;
		rend.enabled = true;
		sound.enabled = true;
		collider.enabled = true;

	}
	void field_off(){

		rend.enabled = false;
		rend.enabled = false;
		sound.enabled = false;
		collider.enabled = false;
	}



// power up and down laser







}
