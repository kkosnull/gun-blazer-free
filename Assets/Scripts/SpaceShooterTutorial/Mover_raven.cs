using UnityEngine;
using System.Collections;


public class Mover_raven : MonoBehaviour
{
	public float speed_enemy;

	void Start ()
	{


		speed_enemy = UnityEngine.Random.Range (-3, -5);

		GetComponent<Rigidbody>().velocity = transform.forward * speed_enemy;
	}



}
