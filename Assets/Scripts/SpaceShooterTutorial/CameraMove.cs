using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour 
{
	public Transform camtarget;
	public float smoothTime = 0.3f;
	private Transform thisTransform;
	private Vector2 velocity;
	
	private void Start()
	{
		thisTransform = transform;
	}
	
	private void Update() 
	{
		Vector3 vec = thisTransform.position;
		vec.x = Mathf.SmoothDamp( thisTransform.position.x, camtarget.position.x, ref velocity.x, smoothTime);

		thisTransform.localPosition = vec;
	}
}
