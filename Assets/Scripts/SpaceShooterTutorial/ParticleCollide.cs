using UnityEngine;
using System.Collections;

public class ParticleCollide : MonoBehaviour
{
	public GameObject explosion;
	public Rigidbody rb;
	void OnParticleCollision(GameObject other) {
		Instantiate (explosion, other.transform.position, other.transform.rotation);
		rb = other.GetComponent<Rigidbody>();
		rb.AddForce(transform.forward * 15.0f);

	}

}