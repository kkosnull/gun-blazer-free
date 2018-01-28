using UnityEngine;
using System.Collections;


public class laser_beam_resize_smaller : MonoBehaviour
{

	public Renderer rend;
	public AudioSource sound;
	public BoxCollider collider;
	private Light[] lights;

	void Start() {

		rend = GetComponent<Renderer>();
		sound= GetComponent<AudioSource>();
		collider= GetComponent<BoxCollider>();
		rend.enabled = false;
		lights = GetComponentsInChildren<Light> (true);
	}
	void Update()
	{

		//bool oddeven = Mathf.FloorToInt(Time.time) % 2 == 0;
		bool oddeven = Mathf.FloorToInt(Time.time) % 2 == 0;
		StartCoroutine(pulse());
		//if (oddeven){StartCoroutine(firebeam());}

		rend.enabled = oddeven;
		sound.enabled = oddeven;
		collider.enabled = oddeven;
		lights [0].enabled = oddeven;

	}
	IEnumerator firebeam()
	{

		shootbeam ();
		yield return new WaitForSeconds(0.3f);
		ceasebeam ();
		yield return new WaitForSeconds(0.1f);
		shootbeam ();
		yield return new WaitForSeconds(0.1f);
		ceasebeam ();
	}


	IEnumerator pulse()
	{
		scaleup();
		yield return new WaitForSeconds(0.1f);
		scaledown();


	}

	void shootbeam()
	{
		rend.enabled = true;
		sound.enabled = true;
		collider.enabled = true;
	}

	void ceasebeam()
	{
		rend.enabled = false;
		sound.enabled = false;
		collider.enabled = false;
	}

	void scaleup(){
		transform.localScale += new Vector3 (0.01f, 0, 0);
	}
	void scaledown(){
		transform.localScale -= new Vector3 (0.01f, 0, 0);
	}



// power up and down laser







}
