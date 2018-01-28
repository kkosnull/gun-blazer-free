using UnityEngine;
using System.Collections;


public class laser_beam_resize_torus_core : MonoBehaviour
{
	public Renderer rend;
	public AudioSource sound;
	public BoxCollider collider;

	void Start() {
		rend = GetComponent<Renderer>();
	//	sound= GetComponent<AudioSource>();
	//	collider= GetComponent<BoxCollider>();
		rend.enabled = true;

	}
	void FixedUpdate()
	{

		StartCoroutine(pulse());
	
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
		transform.localScale += new Vector3 (0.0002f, 0, 0.0002f);
	}
	void scaledown(){
		transform.localScale -= new Vector3 (0.0002f, 0, 0.0002f);
	}

	void scaleInit(){
		transform.localScale = new Vector3 (0.00274f, 0, 0.01122f);
	}

// power up and down laser




}
