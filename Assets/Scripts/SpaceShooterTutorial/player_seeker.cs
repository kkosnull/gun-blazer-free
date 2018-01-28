using UnityEngine;
using System.Collections;

public class player_seeker : MonoBehaviour {
	
	private GameObject target;
	public float movementSpeed = 5f;
	public float rotationSpeed = 90f;
	
	// Use this for initialization
	void Start () {
		this.target= GameObject.Find("Player");
		transform.LookAt(target.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position += transform.forward * movementSpeed * Time.deltaTime;
		if (this.target)
		{
		//	transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(this.target.transform.position - transform.position), rotationSpeed * Time.deltaTime);
		}
		
	}
}