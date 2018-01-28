using UnityEngine;
using System.Collections;

public class light_color_change : MonoBehaviour {
	public Light lt;
	void Start() {
		lt = GetComponent<Light>();
	}
	void Update() {
		//lt.color += Color.white / 2.0F * Time.deltaTime*0.5f;
		lt.color = Color.Lerp(Color.blue, Color.magenta, Mathf.PingPong(Time.time, 1));
	}
}