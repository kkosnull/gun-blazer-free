using UnityEngine;
using System.Collections;


public class laser_beam_resize_boss : MonoBehaviour
{
	public Renderer rend;
	public AudioSource sound;
	public BoxCollider collider;

	void Start() {
		rend = GetComponent<Renderer>();
		sound= GetComponent<AudioSource>();
		collider= GetComponent<BoxCollider>();
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
		scaleup();
		yield return new WaitForSeconds(0.1f);
		scaledown();


	}

	void scaleup(){
		transform.localScale += new Vector3 (0.000003f, 0, 0);
	}
	void scaledown(){
		transform.localScale -= new Vector3 (0.000003f, 0, 0);
	}



// power up and down laser





}
