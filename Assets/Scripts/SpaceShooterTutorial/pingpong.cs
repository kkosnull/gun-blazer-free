using UnityEngine;
using System.Collections;

public class pingpong : MonoBehaviour
{
	public float maxValue = 2; // or whatever you want the max value to be
	public float minValue = -2; // or whatever you want the min value to be
	public float currentValue = 0; // or wherever you want to start
	public float direction = 1; 
	
	void Update() {
		currentValue += Time.deltaTime * direction; // or however you are incrementing the position
		if(currentValue >= maxValue) {
			direction *= -1;
			currentValue = maxValue;
		} else if (currentValue <= minValue){
			direction *= -1; 
			currentValue = minValue;
		}
		transform.position = new Vector3(currentValue, 0, 14);
	}
}
