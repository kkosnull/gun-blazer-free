using UnityEngine;
using System.Collections;

public class light_flicker : MonoBehaviour {
	public float duration = 1.0F;
	public Light lt;
	void Start() {
		lt = GetComponent<Light>();
	}
	void Update() {
		float phi = Time.time / duration * 2 * Mathf.PI;
		float amplitude = Mathf.Cos(phi) * 0.9F + 0.5F;
		lt.intensity = amplitude;
	}
}