using UnityEngine;
using System.Collections;


public class laser_beam_resize_torus : MonoBehaviour
{
	private Renderer rend;
	private AudioSource sound;
	private BoxCollider collider;

	void Start() {
		rend = GetComponent<Renderer>();
		sound= GetComponent<AudioSource>();
		collider  = GetComponent<BoxCollider>();
		rend.enabled = true;

	}
	void Update()
	{
		bool oddeven = Mathf.FloorToInt(Time.time) % 4 == 0;
		StartCoroutine(pulse());
		rend.enabled = oddeven;
		sound.enabled = oddeven;
		collider.enabled = oddeven;
	}
	public IEnumerator pulse()
	{
		yield return new WaitForSeconds (0.1f);
		scaleup();
		yield return new WaitForSeconds(0.1f);
		scaledown();
		//yield return new WaitForSeconds(0.1f);
		//scaleInit ();
	}

	void scaleup(){
		transform.localScale += new Vector3 (0, 0, 0.0004f);
	}
	void scaledown(){
		transform.localScale -= new Vector3 (0, 0, 0.0004f);
	}

	void scaleInit(){
		transform.localScale = new Vector3 (0.00274f, 0, 0.01122f);
	}

// power up and down laser






}
