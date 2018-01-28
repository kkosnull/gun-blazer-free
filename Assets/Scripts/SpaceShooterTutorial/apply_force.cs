using UnityEngine;
using System.Collections;

// Add a thrust force to push an object in its current forward
// direction (to simulate a rocket motor, say).
public class apply_force : MonoBehaviour {
	public float thrust;
	public Rigidbody rb;

	void FixedUpdate() {
		rb.AddForce(Vector3.right * thrust, ForceMode.VelocityChange);
	}
}