using UnityEngine;
using System.Collections;

public class Seeker : MonoBehaviour {
	
	private GameObject target;

	public float movementSpeed = 5f;
	public float rotationSpeed = 100f;


	// Use this for initialization
	void Start () {
		this.target= GameObject.Find("Player");
		transform.LookAt(target.transform);
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += transform.forward * movementSpeed * Time.deltaTime;
		//transform.position = new Vector3(Mathf.PingPong(Time.time, 3), transform.position.y, transform.position.z);
		if (this.target)
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(this.target.transform.position - transform.position), rotationSpeed * Time.deltaTime);
		}

	}
}