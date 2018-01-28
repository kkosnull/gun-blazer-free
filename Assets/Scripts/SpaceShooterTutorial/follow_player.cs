using UnityEngine;
using System.Collections;


public class follow_player : MonoBehaviour
{
	public Transform target;
	public float ProjectileSpeed = 20;
	
	private Transform myTransform;
	
	void Awake() 
	{
		myTransform = transform; 
	}
	
	void Start () 
	{
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		target = go.transform;
		// rotate the projectile to aim the target:
		myTransform.LookAt(target);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{

		// distance moved since last frame:
		float amtToMove = ProjectileSpeed * Time.deltaTime;
		// translate projectile in its forward direction:

		myTransform.Translate(Vector3.forward * amtToMove);

	}


}
