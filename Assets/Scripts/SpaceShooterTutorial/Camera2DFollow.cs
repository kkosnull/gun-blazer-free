using System;
using UnityEngine;


    public class Camera2DFollow : MonoBehaviour
{
	public Transform target;
	public float smoothTime = 1f;
	private Transform thisTransform;
	private Vector2 velocity;
	
	private void Start()
	{
		thisTransform = transform;
	}
	
	private void Update() 
	{
		Vector3 vec = thisTransform.position;
		vec.x = Mathf.SmoothDamp( thisTransform.position.x, 
		                         target.position.x, ref velocity.x, smoothTime);
		//vec.y = Mathf.SmoothDamp( thisTransform.position.y, 
		//                         target.position.y, ref velocity.y, smoothTime);
		thisTransform.position = vec;
	}
}

