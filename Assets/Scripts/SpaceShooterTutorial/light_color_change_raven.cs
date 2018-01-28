using UnityEngine;
using System.Collections;

public class light_color_change_raven : MonoBehaviour {
	public Light lt;
	void Start() {
		lt = GetComponent<Light>();
	}
	void Update() {
		//lt.color += Color.white / 2.0F * Time.deltaTime*0.5f;
		lt.color = Color.Lerp(Color.magenta, Color.red, Mathf.PingPong(Time.time, 1));
	}
}