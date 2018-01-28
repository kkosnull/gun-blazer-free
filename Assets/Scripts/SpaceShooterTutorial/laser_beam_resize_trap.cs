using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class laser_beam_resize_trap : MonoBehaviour
{
	private Renderer rend;
	private AudioSource sound;
	private BoxCollider collider;
	private Light[] lights;
	private int start_zap;

	void Start() {
		rend = GetComponent<Renderer>();
		start_zap = 0;
		sound= GetComponent<AudioSource>();
		sound.enabled = false;
		collider= GetComponent<BoxCollider>();
		collider.enabled = false;
		rend.enabled = false;



	}

	void Update()
	{
		if (start_zap == 1)
		{
			bool oddeven = Mathf.FloorToInt(Time.time) % 3 == 0;
			//StartCoroutine(pulse());
			rend.enabled = oddeven;
			sound.enabled = oddeven;

			collider.enabled = oddeven;
		}



	}
	 public IEnumerator pulse()
	{
		scaleup();
		yield return new WaitForSeconds(0.1f);
		scaledown();


	}

	void scaleup(){

		transform.localScale += new Vector3 (0, 0, 0.03f);

	}
	void scaledown(){

		transform.localScale -= new Vector3 (0, 0, 0.03f);
	}



// power up and down laser

	void FixedUpdate ()
	{
		if (transform.position.z <14) 
		{
			this.start_zap=1;
			
			
		}
		else if (transform.position.z <0) 
		{
			this.start_zap=0;
			
			
		}
	}





}
