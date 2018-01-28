using UnityEngine;
using System.Collections;

// Applies an explosion force to all nearby rigidbodies
public class explosion_force_plasma : MonoBehaviour {
	public float radius = 1.0F;
	private GameController gameController;
	public GameObject explosion;

	void Start() {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}


	}

	void OnTriggerEnter (Collider other)
	
	{
		if (other.tag=="Enemy_pool"){

			Vector3 explosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
			foreach (Collider hit in colliders) {
				if (hit.GetComponent<Rigidbody>()){
				Rigidbody rb = hit.GetComponent<Rigidbody>();
				
				if (rb.GetComponent<DestroyByContact_pooled>()!=null){


						gameController.explode(rb.transform.position, rb.transform.rotation);
						rb.GetComponent<DestroyByContact_pooled>().enemy_life-=50;

						if (rb.GetComponent<DestroyByContact_pooled>().enemy_life <= 0) {

							if (rb.GetComponent<WeaponController_droid_brain>()!= null)
							{
								
								rb.GetComponent<WeaponController_droid_brain>().CancelInvoke("Shoot");
								
							}
							
							if (rb.GetComponent<WeaponController>()!= null)
							{
								
								rb.GetComponent<WeaponController>().CancelInvoke("Shoot");
								
							}
							if (rb.GetComponent<WeaponController_raven>()!= null)
							{
								
								rb.GetComponent<WeaponController_raven>().CancelInvoke("Shoot");
								
							}
							if (rb.GetComponent<WeaponController_d66>()!= null)
							{
								
								rb.GetComponent<WeaponController_d66>().CancelInvoke("Shoot");
								//gameObject.GetComponent<WeaponController_d66>().StopCoroutine("rapid");
								
							}
							if (rb.GetComponent<WeaponController_d58>()!= null)
							{
								
								rb.GetComponent<WeaponController_d58>().CancelInvoke("Shoot");
								//gameObject.GetComponent<WeaponController_d58>().StopCoroutine("rapid");
							}

							if (rb.GetComponent<WeaponController_big_brain>()!= null)
							{
								
								rb.GetComponent<WeaponController_big_brain>().CancelInvoke("Shoot");
								//gameObject.GetComponent<WeaponController_d58>().StopCoroutine("rapid");
							}
							
							rb.gameObject.SetActive(false);
						}

				}
					else if (rb.GetComponent<DestroyByContact>()!=null){
						
						
						Instantiate(explosion, rb.transform.position, rb.transform.rotation);
						rb.GetComponent<DestroyByContact>().enemy_life_droid-=50;
						
						if (rb.GetComponent<DestroyByContact>().enemy_life_droid <= 0) {
							
							if (rb.GetComponent<WeaponController>()!= null)
							{
								
								rb.GetComponent<WeaponController>().CancelInvoke("Shoot");
								
							}
							if (rb.GetComponent<WeaponController_raven>()!= null)
							{
								
								rb.GetComponent<WeaponController_raven>().CancelInvoke("Shoot");
								
							}
							
							rb.gameObject.SetActive(false);
						}
						
					}
				}
					//rb.AddExplosionForce(power, explosionPos, radius, 0.0F, ForceMode.Impulse);

					
				
			}
		}

	}
}