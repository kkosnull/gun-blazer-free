using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class avoid_others : MonoBehaviour
{

	public Collider coll;
	void Start() {
		coll = GetComponent<Collider>();
	}
	void Update() {

		Ray ray = Camera.main.ScreenPointToRay(transform.position);
		RaycastHit hit;
			if (coll.Raycast (ray, out hit, 100.0F))
//				transform.position = ray.GetPoint(100.0F);
			Debug.Log("Collision course");
			
		
	}


}