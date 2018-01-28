using UnityEngine;
using System.Collections;


public class rocket_go_action : MonoBehaviour
{
	public Renderer rend;



	void Start() {
		rend = GetComponent<Renderer>();
		rend.enabled = false;
	}
	void Update()
	{

		//rend.enabled = oddeven;
	
	}





}
