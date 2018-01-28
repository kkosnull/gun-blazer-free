//This is free to use and no attribution is required
//No warranty is implied or given
using UnityEngine;
using System.Collections;

[RequireComponent (typeof(LineRenderer))]
[RequireComponent(typeof(AudioSource))]
public class LaserBeam_green : MonoBehaviour {


	public float laserWidth = 1.0f;
	public float noise = 1.0f;
	public float maxLength = 50.0f;
	public Color color = Color.red;
	private GameController gameController;

	LineRenderer lineRenderer;
	int length;
	Vector3[] position;
	//Cache any transforms here
	Transform myTransform;
	Transform endEffectTransform;
	//The particle system, in this case sparks which will be created by the Laser
	public ParticleSystem endEffect;
	Vector3 offset;
	
	
	// Use this for initialization
	void Start () {


		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");


		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}



		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.SetWidth(laserWidth, laserWidth);
		myTransform = transform;
		offset = new Vector3(0,0,0);
		endEffect = GetComponentInChildren<ParticleSystem>();

		if(endEffect)
			endEffectTransform = endEffect.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameController.beam_flag_green==1 )
		{
		lineRenderer.enabled = true;
		
		RenderLaser();
		}
		else if (gameController.beam_flag_green==0)
		{
			lineRenderer.enabled = false;
			//RenderLaser();
		}
	}

	
	void RenderLaser(){

		GetComponent<AudioSource> ().Play ();
		//Shoot our laserbeam forwards!
		UpdateLength();
		
		lineRenderer.SetColors(color,color);
		//Move through the Array
		for(int i = 0; i<length; i++){
			//Set the position here to the current location and project it in the forward direction of the object it is attached to
			offset.x =myTransform.position.x+i*myTransform.forward.x+Random.Range(-noise,noise);
			offset.z =i*myTransform.forward.z+Random.Range(-noise,noise)+myTransform.position.z;
			position[i] = offset;
			position[0] = myTransform.position;
			
			lineRenderer.SetPosition(i, position[i]);
			
		}
		
		
		
	}
	
	void UpdateLength(){
		//Raycast from the location of the cube forwards
		RaycastHit[] hit;
		hit = Physics.RaycastAll(myTransform.position, myTransform.forward, maxLength);
		int i = 0;
		while(i < hit.Length){
			//Check to make sure we aren't hitting triggers but colliders
			//if(!hit[i].collider.isTrigger )
			//hit[i].transform.tag=="Boundary_for_beam"
		
			if (hit[i].transform.tag=="Enemy_pool" )
			{

				length = (int)Mathf.Round(hit[i].distance);

				position = new Vector3[length];
				lineRenderer.SetVertexCount(length);

				if (hit[i].transform.position.z<17)
				{
					if (hit[i].transform.GetComponent <DestroyByContact_pooled>())
					{
						hit[i].transform.GetComponent <DestroyByContact_pooled>().hit_by_beam();
						gameController.explode_end_effect_green(hit[i].transform.position, this.transform.rotation);
					}
					if (hit[i].transform.GetComponent <DestroyByContact_meteor>())
					{
						hit[i].transform.GetComponent <DestroyByContact_meteor>().hit_by_beam();
						gameController.explode_end_effect_green(hit[i].transform.position, this.transform.rotation);
					}

				}

				return;

			}
			else if (hit[i].transform.tag=="Enemy_turret" )
			{
				
				length = (int)Mathf.Round(hit[i].distance);

				position = new Vector3[length];
				lineRenderer.SetVertexCount(length);
				
				if (hit[i].transform.position.z<17)
				{
					 if (hit[i].transform.GetComponent <DestroyByContact_turret>())
					{
						Vector3 brickPosition = new Vector3( 0, 5, -2.4f);
						hit[i].transform.GetComponent <DestroyByContact_turret>().hit_by_beam();
						gameController.explode_end_effect_green(hit[i].transform.position+brickPosition, this.transform.rotation);
					}
					
				}
				
				return;
				
			}
			else if (hit[i].transform.tag=="bolt_rocket" )
				
			{
				
				length = (int)Mathf.Round(hit[i].distance);
				position = new Vector3[length];
				lineRenderer.SetVertexCount(length);

				if (hit[i].transform.position.z<17)
				{
					hit[i].transform.GetComponent <DestroyByContact_enemy_rocket>().hit_by_beam();
					gameController.explode_end_effect_green(hit[i].transform.position, this.transform.rotation);
				}

				return;
			}
			else if (hit[i].transform.tag=="torus" )
				
			{
				
				length = (int)Mathf.Round(hit[i].distance);
				position = new Vector3[length];
				lineRenderer.SetVertexCount(length);
				
				if (hit[i].transform.position.z<17)
				{
					Vector3 brickPosition = new Vector3( 0, 1, -2.5f);
					hit[i].transform.GetComponent <DestroyByContact_torus>().hit_by_beam();
					gameController.explode_end_effect_green(hit[i].transform.position+brickPosition, this.transform.rotation);
				}
				
				return;
			}
			else if (hit[i].transform.tag=="final_boss" )
				
			{
				
				length = (int)Mathf.Round(hit[i].distance);
				position = new Vector3[length];
				lineRenderer.SetVertexCount(length);
				
				if (hit[i].transform.position.z<17)
				{
					hit[i].transform.GetComponent <Destroy_final_boss>().hit_by_beam();
					gameController.explode_end_effect_green(hit[i].transform.position, this.transform.rotation);
				}
				
				return;
			}
			i++;
		}
		//If we're not hitting anything, don't play the particle effects


		length = (int)maxLength;
		position = new Vector3[length];
		lineRenderer.SetVertexCount(length);
		//Debug.Log (myTransform.position);


		
	}

}