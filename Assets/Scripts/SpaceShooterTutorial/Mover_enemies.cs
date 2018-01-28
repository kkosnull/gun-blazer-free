using UnityEngine;
using System.Collections;


public class Mover_enemies : MonoBehaviour
{
	public float speed_enemy;

	void Start ()
	{


		speed_enemy = UnityEngine.Random.Range (-7, -9);

		GetComponent<Rigidbody>().velocity = transform.forward * speed_enemy;
	}



}
