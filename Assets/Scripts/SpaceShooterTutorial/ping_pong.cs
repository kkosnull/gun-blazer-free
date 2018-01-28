using UnityEngine;
using System.Collections;

public class ping_pong : MonoBehaviour {

	public float delta = 3f;  // Amount to move left and right from the start point
	public float speed = 10.0f; 
	private Vector3 startPos;
	
	void Start () {

		startPos = transform.position;
		//GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
	
	void Update () {
		Vector3 v = startPos;
		v.x += delta * Mathf.Sin (Time.time * speed);
		v.z +=  (Time.time * speed*2);
		transform.localPosition = v;

	}
}
