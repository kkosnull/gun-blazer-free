using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
[RequireComponent(typeof(AudioSource))]
[System.Serializable]
public class Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	
	private float dist;
	public Texture2D barrel_red;
	
	public Texture2D barrel;
	public Light lt;
	public float speed;
	public float tilt;
	public Boundary boundary;
	public int selectshot = 1;
	public int rockettshot = 7;
	public GameObject shot;
	public GameObject rapid_shot;
	public GameObject rapid_shot2;
	public GameObject railgun_shot;
	public GameObject background;
	public GameObject background1;
	public GameObject bg_scroller1;
	public GameObject bg_scroller2;
	
	public Material background_space;
	public Material background_meteors;
	
	public Material raygun;
	public Material megagun;
	
	// triple shots
	public GameObject tripleshot_left;
	public GameObject tripleshot_center;
	public GameObject tripleshot_right;
	// quad shots
	
	
	public GameObject quadshot1;
	public GameObject quadshot2;
	public GameObject quadshot3;
	public GameObject quadshot4;
	
	public GameObject doubleshot;
	public GameObject plasmashot;
	public GameObject rocket_sting1;
	public GameObject rocket_sting2;
	public GameObject rocket_sting3;
	public GameObject rocket_sting4;
	public GameObject rocketshot;
	public GameObject rocketshot_double;
	public GameObject rocketshot_double2;
	public GameObject gatlingshot;
	public GameObject gatlingshot2;
	public GameObject lasershot;
	
	public GameObject megashot_left;
	public GameObject megashot_center;
	public GameObject megashot_right;
	
	public GameObject flash_laser;
	public GameObject flash_plasma;
	
	public AudioClip laser_sound;
	public AudioClip plasma_sound;
	public AudioClip rapid_sound;
	public Vector3 offset = new Vector3( 0, 0, 1 );
	
	// shots
	public Transform shotSpawn_rails;
	public Transform shotSpawn;
	public Transform shotSpawn_double;
	public Transform shotSpawn_double1;
	public Transform shotSpawn_plasma;
	public Transform shotSpawn_laser;
	public Transform rocketSpawn;
	public Transform rocketSpawn1;
	
	public Transform shotSpawn_tripple_center;
	public Transform shotSpawn_tripple_right;
	public Transform shotSpawn_tripple_left;
	
	public Transform shotSpawn_quad1;
	public Transform shotSpawn_quad2;
	public Transform shotSpawn_quad3;
	public Transform shotSpawn_quad4;
	
	public Transform shotSpawn_gatling;
	public Transform shotSpawn_gatling2;
	// shots
	
	public float fireRate;
	public float fireRate_gatling;
	public float fireRate_rail;
	public float fireRate_laser;
	public float fireRateRocket;
	public float count; 
	public float  adduprate;
	private float nextFire;
	private float nextFire_gatling;
	private float nextFire_rail;
	private float nextFireRocket;
	private int rocket_away=3;

	private GameController gameController;
	public MeshRenderer rocket_trigger;
	private Rigidbody m_rigidbody;
	List<GameObject> singleshots;
	List<GameObject> rapidshots;
	List<GameObject> rapidshots2;
	List<GameObject> railshots;
	List<GameObject> doubleshots;
	// <triple shots>
	List<GameObject> tripleshots_left;
	List<GameObject> tripleshots_center;
	List<GameObject> tripleshots_right;
	// </triple shots>
	
	// <quad shots>
	List<GameObject> quadshots1;
	List<GameObject> quadshots2;
	List<GameObject> quadshots3;
	List<GameObject> quadshots4;
	// </quad shots>
	
	
	List<GameObject> plasmashots;
	List<GameObject> gatlingshots;
	List<GameObject> gatlingshots2;
	List<GameObject> lasershots;
	
	// mega gun shots
	List<GameObject> megashots1;
	List<GameObject> megashots2;
	List<GameObject> megashots3;
	
	// --- mega gun shots
	// homing missile
	List<GameObject> missiles_homing;
	// rocket
	List<GameObject> rockets;
	// sting missiles
	// <quad shots>
	List<GameObject> missiles_sting1;
	List<GameObject> missiles_sting2;
	List<GameObject> missiles_sting3;
	List<GameObject> missiles_sting4;
	// </quad shots>




	private int poolIndex;
	private int poolIndex_rapid;
	private int poolIndex_rapid2;
	private int poolIndex_rail;
	private int poolIndex_double;
	private int poolIndex_triple;
	private int poolIndex_quad;
	private int poolIndex_plasma;
	private int poolIndex_gatling;
	private int poolIndex_gatling2;
	private int poolIndex_laser;
	private int poolIndex_missile_homing;
	private int poolIndex_rocket;
	private int poolIndex_missile_sting1;
	private int poolIndex_missile_sting2;
	private int poolIndex_missile_sting3;
	private int poolIndex_missile_sting4;
	private int minigun_flag;
	private int railgun_flag;
	private int megashot_flag;
	private int poolIndex_megashot;
	private int minigun_count;
	private int rapid_count;
	private int laser_flag;
	private Touch touch;
	AudioSource audio;
	public  ParticleSystem starfield_particle;
	
	private GameObject enemy_target;
	private Transform target;


	
	void Awake () {
		//DontDestroyOnLoad (this.transform.gameObject);
		MeshRenderer[] render = gameObject.GetComponentsInChildren<MeshRenderer>();

		render[1].enabled = false;
		render[2].enabled = false;
		render[3].enabled = false;
		render[4].enabled = false;
		render[5].enabled = false;
		render[6].enabled = false;
		render[7].enabled = false;
		render[8].enabled = false;
		render[9].enabled = false;
		//Vector3 position = GameObject.Find("SpawnPoint").transform.position;
		//If your player prefab doesn't exist in the scene, then instantiate it
		
	}
	
	
	void Start ()
	{
		GameObject nozzle = GameObject.Find("MegaGun_Ship_Extended");
		lt = GetComponent<Light>();
		audio = GetComponent<AudioSource>();
		this.minigun_flag = 0;
		this.railgun_flag = 0;
		this.laser_flag = 0;
		this.megashot_flag = 0;
		this.minigun_count = 0;
		this.rapid_count = 0;

		
		m_rigidbody = GetComponent<Rigidbody>();
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
		rocket_trigger = GameObject.FindGameObjectWithTag ("rocket_trigger").GetComponent<MeshRenderer>();
		rocket_trigger.enabled=false;
		
		// populate homing missiles
		missiles_homing = new List<GameObject> ();
		rockets = new List<GameObject> ();
		missiles_sting1 = new List<GameObject> ();
		missiles_sting2 = new List<GameObject> ();
		missiles_sting3 = new List<GameObject> ();
		missiles_sting4 = new List<GameObject> ();
		// populate single shots
		singleshots = new List<GameObject> ();
		rapidshots = new List<GameObject> ();
		rapidshots2 = new List<GameObject> ();
		railshots = new List<GameObject> ();
		doubleshots = new List<GameObject> ();
		// triple shots
		tripleshots_left = new List<GameObject> ();
		tripleshots_center = new List<GameObject> ();
		tripleshots_right = new List<GameObject> ();
		//----
		
		// quad shots
		quadshots1 = new List<GameObject> ();
		quadshots2 = new List<GameObject> ();
		quadshots3 = new List<GameObject> ();
		quadshots4 = new List<GameObject> ();
		
		//----
		
		// mega shots
		megashots1 = new List<GameObject> ();
		megashots2 = new List<GameObject> ();
		megashots3 = new List<GameObject> ();
		
		//----
		
		plasmashots = new List<GameObject> ();
		gatlingshots = new List<GameObject> ();
		gatlingshots2 = new List<GameObject> ();
		lasershots = new List<GameObject> ();
		
		
		for (int i=0; i<10; i++){
			
			GameObject obj=(GameObject)Instantiate(rocketshot_double2, new Vector3(-10, 0, 13), Quaternion.identity);
			obj.SetActive(false);
			rockets.Add(obj);
		}
		for (int i=0; i<10; i++){
			
			GameObject obj=(GameObject)Instantiate(rocket_sting1, new Vector3(-10, 0, 13), Quaternion.identity);
			obj.SetActive(false);
			missiles_sting1.Add(obj);
		}
		for (int i=0; i<10; i++){
			
			GameObject obj=(GameObject)Instantiate(rocket_sting2, new Vector3(-10, 0, 13), Quaternion.identity);
			obj.SetActive(false);
			missiles_sting2.Add(obj);
		}
		for (int i=0; i<10; i++){
			
			GameObject obj=(GameObject)Instantiate(rocket_sting3, new Vector3(-10, 0, 13), Quaternion.identity);
			obj.SetActive(false);
			missiles_sting3.Add(obj);
		}
		for (int i=0; i<10; i++){
			
			GameObject obj=(GameObject)Instantiate(rocket_sting4, new Vector3(-10, 0, 13), Quaternion.identity);
			obj.SetActive(false);
			missiles_sting4.Add(obj);
		}

		for (int i=0; i<1; i++){
			
			GameObject obj=(GameObject)Instantiate(rocketshot, new Vector3(-10, 0, 13), Quaternion.identity);
			obj.SetActive(false);
			missiles_homing.Add(obj);
		}
		
		for (int i=0; i<10; i++){
			
			GameObject obj=(GameObject)Instantiate(rapid_shot, new Vector3(-10, 0, 13), Quaternion.identity);
			obj.SetActive(false);
			rapidshots.Add(obj);
		}
		for (int i=0; i<10; i++){
			
			GameObject obj=(GameObject)Instantiate(rapid_shot2, new Vector3(-10, 0, 13), Quaternion.identity);
			obj.SetActive(false);
			rapidshots2.Add(obj);
		}
		for (int i=0; i<10; i++){
			//Debug.Log ("start player");
			GameObject obj=(GameObject)Instantiate(shot, new Vector3(-10, 0, 13), Quaternion.identity);
			obj.SetActive(false);
			singleshots.Add(obj);
		}
		
		for (int i=0; i<10; i++){
			
			GameObject obj=(GameObject)Instantiate(shot, new Vector3(-10, 0, 13), Quaternion.identity);
			obj.SetActive(false);
			doubleshots.Add(obj);
		}
		
		// triple shots
		for (int i=0; i<10; i++){
			
			GameObject obj=(GameObject)Instantiate(tripleshot_left, new Vector3(-10, 0, 13), Quaternion.identity);
			obj.SetActive(false);
			tripleshots_left.Add(obj);
		}
		
		for (int i=0; i<10; i++){
			
			GameObject obj=(GameObject)Instantiate(tripleshot_center, new Vector3(-10, 0, 13), Quaternion.identity);
			obj.SetActive(false);
			tripleshots_center.Add(obj);
		}
		
		for (int i=0; i<10; i++){
			
			GameObject obj=(GameObject)Instantiate(tripleshot_right, new Vector3(-10, 0, 13), Quaternion.identity);
			obj.SetActive(false);
			tripleshots_right.Add(obj);
		}
		
		//--
		
		// mega shots
		
		for (int i=0; i<10; i++){
			
			GameObject obj=(GameObject)Instantiate(megashot_left, new Vector3(-10, 0, 13), Quaternion.identity);
			obj.SetActive(false);
			megashots1.Add(obj);
		}
		
		for (int i=0; i<10; i++){
			
			GameObject obj=(GameObject)Instantiate(megashot_center, new Vector3(-10, 0, 13), Quaternion.identity);
			obj.SetActive(false);
			megashots2.Add(obj);
		}
		
		for (int i=0; i<10; i++){
			
			GameObject obj=(GameObject)Instantiate(megashot_right, new Vector3(-10, 0, 13), Quaternion.identity);
			obj.SetActive(false);
			megashots3.Add(obj);
		}
		//--
		
		// quad shots
		for (int i=0; i<10; i++){
			
			GameObject obj=(GameObject)Instantiate(quadshot1, new Vector3(-10, 0, 13), Quaternion.identity);
			obj.SetActive(false);
			quadshots1.Add(obj);
		}
		
		
		for (int i=0; i<10; i++){
			
			GameObject obj=(GameObject)Instantiate(quadshot2, new Vector3(-10, 0, 13), Quaternion.identity);
			obj.SetActive(false);
			quadshots2.Add(obj);
		}
		
		for (int i=0; i<10; i++){
			
			GameObject obj=(GameObject)Instantiate(quadshot3, new Vector3(-10, 0, 13), Quaternion.identity);
			obj.SetActive(false);
			quadshots3.Add(obj);
		}
		
		for (int i=0; i<10; i++){
			
			GameObject obj=(GameObject)Instantiate(quadshot4, new Vector3(-10, 0, 13), Quaternion.identity);
			obj.SetActive(false);
			quadshots4.Add(obj);
		}
		// --
		
		for (int i=0; i<7; i++){
			GameObject objplasma=(GameObject)Instantiate(plasmashot, new Vector3(-10, 0, 13), Quaternion.identity);
			objplasma.SetActive(false);
			plasmashots.Add(objplasma);
		}
		for (int i=0; i<4; i++){
			GameObject objplaser=(GameObject)Instantiate(lasershot, new Vector3(-10, 0, 13), Quaternion.identity);
			objplaser.SetActive(false);
			lasershots.Add(objplaser);
		}
		
		for (int i=0; i<20; i++){
			
			GameObject objgatling=(GameObject)Instantiate(gatlingshot, new Vector3(-10, 0, 13), Quaternion.identity);
			objgatling.SetActive(false);
			gatlingshots.Add(objgatling);
		}

		for (int i=0; i<20; i++){
			
			GameObject objgatling2=(GameObject)Instantiate(gatlingshot2, new Vector3(-10, 0, 13), Quaternion.identity);
			objgatling2.SetActive(false);
			gatlingshots2.Add(objgatling2);
		}

		for (int i=0; i<20; i++){
			
			GameObject obj=(GameObject)Instantiate(railgun_shot, new Vector3(-10, 0, 13), Quaternion.identity);
			obj.SetActive(false);
			railshots.Add(obj);
		}
		
		poolIndex = 0;
		poolIndex_double = 0;
		poolIndex_triple = 0;
		poolIndex_quad = 0;
		poolIndex_plasma = 0;
		poolIndex_gatling = 0;
		poolIndex_gatling2 = 0;
		poolIndex_laser = 0;
		poolIndex_rapid = 0;
		poolIndex_rapid2 = 0;
		poolIndex_rail = 0;
		poolIndex_missile_homing = 0;
		poolIndex_rocket = 0;
		poolIndex_megashot = 0;
		poolIndex_missile_sting1 = 0;
		poolIndex_missile_sting2 = 0;
		poolIndex_missile_sting3 = 0;
		poolIndex_missile_sting4 = 0;
	}
	
	
	
	void FixedUpdate  ()
	{

		if (GameObject.FindGameObjectWithTag("Enemy_pool"))
		{
			enemy_target = GameObject.FindGameObjectWithTag("Enemy_pool");
			this.dist = Vector3.Distance(enemy_target.transform.position, transform.position);
			//Debug.Log ("distance"+dist);
		}
		if (gameController.life<=0)
		{
			gameController.explode_player(this.transform.position, this.transform.rotation);
		}


		if (gameController.beam_flag==1)
		{

			gameController.shoot_flag=0;

		}
		
		if (this.railgun_flag == 1 && gameController.shoot_flag==1) {
			
			MeshRenderer[] render = gameObject.GetComponentsInChildren<MeshRenderer>();
			
			render[7].enabled = true;
			render[6].enabled = true;
			
			StartCoroutine(shoot_rail());
			
		}
		
		
		if (this.minigun_flag == 1 && gameController.shoot_flag==1) {
			if (this.minigun_count==1)
			{
				MeshRenderer[] render = gameObject.GetComponentsInChildren<MeshRenderer>();
				
				render[2].enabled = true;
				render[3].enabled = true;
				
				if (Input.touchCount > 0 && Time.time > nextFire_gatling) {
					
					
					nextFire_gatling = Time.time + fireRate_gatling;
					if(gatlingshots [poolIndex_gatling]){
						
						gatlingshots [poolIndex_gatling].SetActive (true);
						gatlingshots [poolIndex_gatling].transform.position = shotSpawn_gatling.position;
						
						
					}
					
					poolIndex_gatling++;
					
					if (poolIndex_gatling == 19) {
						poolIndex_gatling = 0;
					}
					
					
				}
			}
			else if (this.minigun_count==2)
			{
				MeshRenderer[] render = gameObject.GetComponentsInChildren<MeshRenderer>();
				

				render[8].enabled = true;
				render[9].enabled = true;
				if (Input.touchCount > 0 && Time.time > nextFire_gatling) {
					
					
					nextFire_gatling = Time.time + fireRate_gatling;

					// fire right gun
					if(gatlingshots [poolIndex_gatling]){
						
						gatlingshots [poolIndex_gatling].SetActive (true);
						gatlingshots [poolIndex_gatling].transform.position = shotSpawn_gatling.position;
						
						
					}
					
					poolIndex_gatling++;
					
					if (poolIndex_gatling == 19) {
						poolIndex_gatling = 0;
					}

					// fire left gun
					if(gatlingshots2 [poolIndex_gatling2]){
						
						gatlingshots2 [poolIndex_gatling2].SetActive (true);
						gatlingshots2 [poolIndex_gatling2].transform.position = shotSpawn_gatling2.position;
						
						
					}
					
					poolIndex_gatling2++;
					
					if (poolIndex_gatling2 == 19) {
						poolIndex_gatling2 = 0;
					}
					
					
				}
			}

		}
		
		
		if (this.railgun_flag == 0) {
			MeshRenderer[] render = gameObject.GetComponentsInChildren<MeshRenderer> ();
			render [7].enabled = false;
			render [6].enabled = false;
		}
//		if (gameController.beam_flag == 0 && this.megashot_flag==1) {
//			
//			MeshRenderer[] render = gameObject.GetComponentsInChildren<MeshRenderer> ();
//			render [1].enabled = true;
//			
//		}
		if (this.minigun_flag == 0) {
			MeshRenderer[] render = gameObject.GetComponentsInChildren<MeshRenderer> ();
			render [2].enabled = false;
			render [3].enabled = false;
			render[8].enabled = false;
			render[9].enabled = false;
		}
		
		if (gameController.beam_flag_green==0 )
		{
			MeshRenderer[] render = gameObject.GetComponentsInChildren<MeshRenderer> ();
			render [4].enabled = false;

		}
		if (gameController.beam_flag_green==1)
		{
			MeshRenderer[] render = gameObject.GetComponentsInChildren<MeshRenderer> ();
			render [4].enabled = true;
		}
		
		if (this.megashot_flag == 0) {
			MeshRenderer[] render = gameObject.GetComponentsInChildren<MeshRenderer> ();
			render [1].enabled = false;
//			if (this.selectshot==10)
//			{
//				render [1].enabled = true;
//			}

			
		}

		if (this.megashot_flag == 1) {
			MeshRenderer[] render = gameObject.GetComponentsInChildren<MeshRenderer> ();
			render [1].material=raygun;
			render [1].enabled = true;

			
		}
		
		if (gameController.shoot_flag == 1) {
			
			// testing
			//if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			if (Input.touchCount > 0 && Time.time > nextFire) {
				
				
				nextFire = Time.time + fireRate;
				if (selectshot == 1) {
					
					fireRate=(float)0.16;
					//	fireRate=(float)0.08;
					if(singleshots[poolIndex]!=null){
						singleshots[poolIndex].SetActive(true);
						singleshots[poolIndex].transform.position = transform.position;
						GetComponent<AudioSource> ().Play ();
					}
					
					poolIndex++;
					
					if (poolIndex == 9)
					{
						poolIndex = 0;
					}
					
					//fireRate=(float)0.16;
					//Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				}
				if (selectshot == 2) {
					fireRate=(float)0.18;
					//Instantiate (doubleshot, shotSpawn_double.position, shotSpawn_double.rotation);
					if(singleshots[poolIndex_double]!=null){
						
						singleshots[poolIndex_double].SetActive(true);
						doubleshots[poolIndex_double].SetActive(true);
						
						singleshots[poolIndex_double].transform.position = shotSpawn_double.position;
						doubleshots[poolIndex_double].transform.position = shotSpawn_double1.position;
						
						GetComponent<AudioSource> ().Play ();
					}
					
					poolIndex_double++;
					
					if (poolIndex_double ==10)
					{
						poolIndex_double = 0;
					}
					GetComponent<AudioSource> ().Play ();
				}
				if (selectshot == 3) {
					fireRate=(float)0.22;
					//Instantiate (plasmashot, shotSpawn_plasma.position, shotSpawn_plasma.rotation);
					//Instantiate(flash_plasma, transform.position+offset, transform.rotation);
					gameController.flash_plasma(this.transform.position+offset, this.transform.rotation);
					plasmashots[poolIndex_plasma].SetActive(true);
					plasmashots[poolIndex_plasma].transform.position = transform.position;
					audio.PlayOneShot(plasma_sound, 1.0F);
					poolIndex_plasma++;
					
					if (poolIndex_plasma == 7)
					{
						poolIndex_plasma = 0;
					}
					
					//Instantiate (plasmashot, shotSpawn_plasma.position, shotSpawn_plasma.rotation);
				}
				if (selectshot == 4) {
					fireRate=(float)0.2;
					//Instantiate (shot, shotSpawn_tripple_center.position, shotSpawn_tripple_center.rotation);
					//Instantiate (shot, shotSpawn_tripple_right.position, shotSpawn_tripple_right.rotation);
					//Instantiate (shot, shotSpawn_tripple_left.position, shotSpawn_tripple_left.rotation);
					
					if(tripleshots_center[poolIndex_triple]!=null){
						tripleshots_center[poolIndex_triple].SetActive(true);
						tripleshots_center[poolIndex_triple].transform.position = shotSpawn_tripple_center.position;
						tripleshots_center[poolIndex_triple].transform.rotation = shotSpawn_tripple_center.rotation;
						
					}
					if(tripleshots_left[poolIndex_triple]!=null){
						tripleshots_left[poolIndex_triple].SetActive(true);
						tripleshots_left[poolIndex_triple].transform.position = shotSpawn_tripple_left.position;
						tripleshots_left[poolIndex_triple].transform.rotation = shotSpawn_tripple_left.rotation;
					}
					if(tripleshots_right[poolIndex_triple]!=null){
						tripleshots_right[poolIndex_triple].SetActive(true);
						tripleshots_right[poolIndex_triple].transform.position = shotSpawn_tripple_right.position;
						tripleshots_right[poolIndex_triple].transform.rotation = shotSpawn_tripple_right.rotation;
					}
					
					GetComponent<AudioSource> ().Play ();
					poolIndex_triple++;
					
					if (poolIndex_triple == 10)
					{
						poolIndex_triple = 0;
					}
					
					
				}
				// condition for quad
				
				if (selectshot == 8) {
					fireRate=(float)0.25;
					
					if(quadshots1[poolIndex_quad]!=null){
						quadshots1[poolIndex_quad].SetActive(true);
						quadshots1[poolIndex_quad].transform.position = shotSpawn_quad1.position;
						quadshots1[poolIndex_quad].transform.rotation = shotSpawn_quad1.rotation;
						
					}
					if(quadshots2[poolIndex_quad]!=null){
						quadshots2[poolIndex_quad].SetActive(true);
						quadshots2[poolIndex_quad].transform.position = shotSpawn_quad2.position;
						quadshots2[poolIndex_quad].transform.rotation = shotSpawn_quad2.rotation;
						
					}
					if(quadshots3[poolIndex_quad]!=null){
						quadshots3[poolIndex_quad].SetActive(true);
						quadshots3[poolIndex_quad].transform.position = shotSpawn_quad3.position;
						quadshots3[poolIndex_quad].transform.rotation = shotSpawn_quad3.rotation;
						
					}
					
					if(quadshots4[poolIndex_quad]!=null){
						quadshots4[poolIndex_quad].SetActive(true);
						quadshots4[poolIndex_quad].transform.position = shotSpawn_quad4.position;
						quadshots4[poolIndex_quad].transform.rotation = shotSpawn_quad4.rotation;
						
					}
					
					GetComponent<AudioSource> ().Play ();
					poolIndex_quad++;
					
					if (poolIndex_quad == 10)
					{
						poolIndex_quad = 0;
					}
					
					
				}
				
				
				// rapid shot
				
				if (selectshot == 9) {
					
					if (this.rapid_count==1)
					{
						fireRate=(float)0.08;
						if(rapidshots[poolIndex_rapid]!=null){
							rapidshots[poolIndex_rapid].SetActive(true);
							rapidshots[poolIndex_rapid].transform.position = transform.position;
							//GetComponent<AudioSource> ().Play ();
						}
						
						poolIndex_rapid++;
						audio.PlayOneShot(rapid_sound, 1.0F);
						if (poolIndex_rapid == 9)
						{
							poolIndex_rapid = 0;
						}
					}
					else if (this.rapid_count==2)
					{
						fireRate=(float)0.08;

						if(rapidshots[poolIndex_rapid]!=null){
							rapidshots[poolIndex_rapid].SetActive(true);
							rapidshots[poolIndex_rapid].transform.position = shotSpawn_quad2.position;
							//GetComponent<AudioSource> ().Play ();
						}
						
						poolIndex_rapid++;
						audio.PlayOneShot(rapid_sound, 1.0F);
						if (poolIndex_rapid == 9)
						{
							poolIndex_rapid = 0;
						}

						// fire next side rapid shot

						if(rapidshots2[poolIndex_rapid2]!=null){
							rapidshots2[poolIndex_rapid2].SetActive(true);
							rapidshots2[poolIndex_rapid2].transform.position = shotSpawn_quad3.position;
							//GetComponent<AudioSource> ().Play ();
						}
						
						poolIndex_rapid2++;
						audio.PlayOneShot(rapid_sound, 1.0F);
						if (poolIndex_rapid2 == 9)
						{
							poolIndex_rapid2 = 0;
						}

					}

					

				}
				// -- rapid shot
				
				//mega shots
				if (selectshot == 10) {
					fireRate=(float)0.08;
					
					
					if(megashots1[poolIndex_megashot]!=null){
						megashots1[poolIndex_megashot].SetActive(true);
						megashots1[poolIndex_megashot].transform.position = shotSpawn_tripple_center.position;
						megashots1[poolIndex_megashot].transform.rotation = shotSpawn_tripple_center.rotation;
						
					}
					if(megashots2[poolIndex_megashot]!=null){
						megashots2[poolIndex_megashot].SetActive(true);
						megashots2[poolIndex_megashot].transform.position = shotSpawn_tripple_left.position;
						megashots2[poolIndex_megashot].transform.rotation = shotSpawn_tripple_left.rotation;
					}
					if(megashots3[poolIndex_megashot]!=null){
						megashots3[poolIndex_megashot].SetActive(true);
						megashots3[poolIndex_megashot].transform.position = shotSpawn_tripple_right.position;
						megashots3[poolIndex_megashot].transform.rotation = shotSpawn_tripple_right.rotation;
					}
					
					audio.PlayOneShot(rapid_sound, 1.0F);
					poolIndex_megashot++;
					
					if (poolIndex_megashot == 10)
					{
						poolIndex_megashot = 0;
					}
					
					
				}
				
				//-- mega shots
				if (selectshot == 6) {
					fireRate=(float)0.3;
					//Instantiate (plasmashot, shotSpawn_plasma.position, shotSpawn_plasma.rotation);
					
					//Instantiate(flash_laser, transform.position+offset, transform.rotation);
					gameController.flash_laser(this.transform.position+offset, this.transform.rotation);
					lasershots[poolIndex_laser].SetActive(true);
					lasershots[poolIndex_laser].transform.position = transform.position;
					audio.PlayOneShot(laser_sound, 1.0F);
					poolIndex_laser++;
					
					if (poolIndex_laser == 4)
					{
						poolIndex_laser = 0;
					}
					
					//Instantiate (plasmashot, shotSpawn_plasma.position, shotSpawn_plasma.rotation);
				}
				
				
				
				gameController.OnShotFired ();
			}
			
		}	
		
		if (gameController.shoot_rocket_flag==1) {
			
			if (rockettshot == 2 && Time.time > nextFireRocket && this.rocket_away < 1) {
				nextFireRocket = Time.time + fireRateRocket;
				//Instantiate (rocketshot, rocketSpawn.position, rocketSpawn.rotation);
				this.rocket_away += 1;
				//gameController.shoot_flag=1;
				//	StartCoroutine(wait());
			}
		}
		
		
		if (gameController.shoot_rocket_flag_double == 1) {
	//	if (gameController.shoot_rocket_flag_double == 1 && gameController.beam_flag==0 && gameController.beam_flag_green==0) {
			//gameController.shoot_flag=0;
			if (Input.touchCount > 0 && rockettshot == 2 && Time.time > nextFireRocket && this.rocket_away < 30) {
				
				nextFireRocket = Time.time + 0.4f;
				this.rocket_away += 1;
				bool oddeven = Mathf.FloorToInt(Time.time) % 2 == 0;
				
				if(rockets[poolIndex_rocket]!=null){
					rockets[poolIndex_rocket].SetActive(true);
					if (oddeven == true){rockets[poolIndex_rocket].transform.position = shotSpawn_double1.position;}
					if (oddeven == false){rockets[poolIndex_rocket].transform.position = shotSpawn_double.position;}
					
					
				}
				
				poolIndex_rocket++;
				
				if (poolIndex_rocket == 9)
				{
					poolIndex_rocket = 0;
				}
				if (this.rocket_away==30)
				{
					//rocket_trigger.enabled=false;
					gameController.shoot_rocket_flag_double = 0;

				}
				
			}
			
		}


		if (gameController.shoot_rocket_flag_sting == 1) {
			//Debug.Log("Sting fired");
			if (Input.touchCount > 0  && Time.time > nextFireRocket) {
			//if (Input.GetButton ("Fire1") && Time.time > nextFireRocket) {	
				nextFireRocket = Time.time + 1.4f;

				if(missiles_sting1[poolIndex_missile_sting1]!=null){
					missiles_sting1[poolIndex_missile_sting1].SetActive(true);
					missiles_sting1[poolIndex_missile_sting1].transform.position = shotSpawn_double1.position;
					
					
				}
				if(missiles_sting2[poolIndex_missile_sting2]!=null){
					missiles_sting2[poolIndex_missile_sting2].SetActive(true);
					missiles_sting2[poolIndex_missile_sting2].transform.position = shotSpawn_quad4.position;
					
					
				}
				if(missiles_sting3[poolIndex_missile_sting3]!=null){
					missiles_sting3[poolIndex_missile_sting3].SetActive(true);
					missiles_sting3[poolIndex_missile_sting3].transform.position = shotSpawn_gatling2.position;
					
					
				}
				if(missiles_sting4[poolIndex_missile_sting4]!=null){
					missiles_sting4[poolIndex_missile_sting4].SetActive(true);
					missiles_sting4[poolIndex_missile_sting4].transform.position = shotSpawn_quad2.position;
					
					
				}
				poolIndex_missile_sting1++;
				poolIndex_missile_sting2++;
				poolIndex_missile_sting3++;
				poolIndex_missile_sting4++;
				
				if (poolIndex_missile_sting1 == 9 && poolIndex_missile_sting2==9 && poolIndex_missile_sting3==9 && poolIndex_missile_sting4==9)
				{
					poolIndex_missile_sting1 = 0;
					poolIndex_missile_sting2 = 0;
					poolIndex_missile_sting3 = 0;
					poolIndex_missile_sting4 = 0;
				}
				
				
			}
			
		}

		if (Input.touchCount > 0) {
			
			this.touch = Input.GetTouch (0);
			switch (this.touch.phase) 
			{
				case TouchPhase.Moved:
					//move
					
					Vector3 target = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 47.0f));
				this.m_rigidbody.transform.Translate (Vector3.MoveTowards (this.m_rigidbody.transform.position, target, 150 * Time.deltaTime) - this.m_rigidbody.transform.position);
				this.m_rigidbody.transform.position = new Vector3 (this.m_rigidbody.transform.position.x, this.m_rigidbody.transform.position.y, this.m_rigidbody.transform.position.z+1.3f);
				//Rigidbody rb;


				float direction=  Input.GetTouch(0).deltaPosition.x;	

				if (direction>0)
				{
				//	this.m_rigidbody.transform.Rotate(0f, 0f, -45.0f);
					m_rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, -25.0f);
				}
				else if (direction<0)
				{
					//this.m_rigidbody.transform.Rotate(0f, 0f, 45.0f);
					m_rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, 25.0f);
				}	
				else if (direction == 0)
				{
					//this.m_rigidbody.transform.Rotate(0f, 0f, 0f);
					m_rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
				}
			
				break;
					case TouchPhase.Began:
					this.m_rigidbody.transform.position = new Vector3 (this.m_rigidbody.transform.position.x, this.m_rigidbody.transform.position.y, this.m_rigidbody.transform.position.z+1.3f);
				break;
				//	case TouchPhase.Ended:
				// 	this.m_rigidbody.transform.position = new Vector3 (this.m_rigidbody.transform.position.x, this.m_rigidbody.transform.position.y, this.m_rigidbody.transform.position.z-1.0f);

				//break;
					
			}

			
		} else
		{
			
			
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");
			
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			m_rigidbody.velocity = movement * speed;
			//Debug.Log(m_rigidbody.velocity.x);
			m_rigidbody.position = new Vector3
				(
					Mathf.Clamp (m_rigidbody.position.x, boundary.xMin, boundary.xMax), 
					0.0f, 
					Mathf.Clamp (m_rigidbody.position.z, boundary.zMin, boundary.zMax)
					);

			m_rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, -m_rigidbody.velocity.x*0.6f);

		}
		
		
		
		
		
		
		
		
		
	}
	
	public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) {
		Ray ray = Camera.main.ScreenPointToRay(screenPosition);
		Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
		float distance;
		xy.Raycast(ray, out distance);
		return ray.GetPoint(distance);
	}
	
	public void shoot_homming()
	{
		StartCoroutine(homing_missile());
	}
	
	
	
	public IEnumerator homing_missile() {
		
		
		if (gameController.shoot_rocket_flag == 1) {
			gameController.shoot_flag=0;
			yield return new WaitForSeconds (0.2f);
			//Instantiate (rocketshot, rocketSpawn.position, rocketSpawn.rotation);
			
			if(missiles_homing[poolIndex_missile_homing]!=null){
				missiles_homing[poolIndex_missile_homing].SetActive(true);
				missiles_homing[poolIndex_missile_homing].transform.position = shotSpawn_double1.position;
				
			}
			
			poolIndex_missile_homing++;
			
			if (poolIndex_missile_homing == 1)
			{
				poolIndex_missile_homing = 0;
			}
			rocket_trigger.enabled=false;
			gameController.shoot_rocket_flag = 0;
			yield return new WaitForSeconds (0.3f);
			if (gameController.beam_flag_green==0 || gameController.beam_flag==0)
			{
				gameController.shoot_flag=1;
			}

		}
		
		
	}
	
	
	
	
	
	void OnTriggerEnter (Collider other)
	{
		
		
		if (other.tag == "core_minion_boss_trigger")
		{
			gameController.minion_core_boss = 1;

			
		}
		if (other.tag == "core_boss_trigger")
		{
			gameController.spawn_flag = 0;
			gameController.spawn_pup_flag = 0;
			gameController.torus_flag = 0;
			StartCoroutine(init_meteors());
			
		}
		
		if (other.tag == "power_up_rocket")
		{
			if (gameController.shoot_rocket_flag ==0 || gameController.shoot_rocket_flag_double ==0 || gameController.shoot_rocket_flag_sting ==0)
			{
				rocket_trigger.enabled=true;
				this.rockettshot = 2;
				this.rocket_away = 0;
				gameController.shoot_rocket_flag=1;
			}

		}
		
		if (other.tag == "power_up_rocket_double")
		{
			if (gameController.shoot_rocket_flag ==0 || gameController.shoot_rocket_flag_double ==0 || gameController.shoot_rocket_flag_sting ==0)
			{
				this.rockettshot = 2;
				this.rocket_away = 0;
				gameController.shoot_rocket_flag_double=1;
			}
			
		}
		if (other.tag == "power_up_sting")
		{
			if (gameController.shoot_rocket_flag ==0 || gameController.shoot_rocket_flag_double ==0 || gameController.shoot_rocket_flag_sting ==0)
			{
				if (gameController.beam_flag == 0 && gameController.beam_flag_green ==0)
				{
				gameController.shoot_rocket_flag_sting=1;
				StartCoroutine(stings_depleted());
				}
			}
			
		}
		
		if (other.tag == "powerup_laser")
		{
			this.rapid_count=0;
			this.minigun_flag=0;
			this.minigun_count=0;
			this.railgun_flag=0;
			this.selectshot = 6;
			this.megashot_flag = 0;
			//this.laser_flag=1;
			gameController.shoot_flag = 0;
			gameController.beam_flag_green=1;
			gameController.beam_flag=0;
			if (gameController.shoot_rocket_flag==1 || gameController.shoot_rocket_flag_double==1 || gameController.shoot_rocket_flag_sting==1)
			{
				gameController.shoot_rocket_flag=0;
				gameController.shoot_rocket_flag_double=0;
				gameController.shoot_rocket_flag_sting=0;
			}

		}
		if (other.tag == "powerup_megagun")
		{
			this.rapid_count=0;
			this.minigun_flag=0;
			this.railgun_flag=0;
			this.selectshot = 10;
			this.megashot_flag=1;
			this.laser_flag=0;
			gameController.beam_flag_green=0;
			gameController.beam_flag=0;
			gameController.shoot_flag = 1;
			gameController.damage=200;
		}
		if (other.tag == "power_up_railgun")
		{
			this.railgun_flag=1;
			this.minigun_flag=0;
			this.minigun_count=0;
			gameController.damage=80;
			
		}
		if (other.tag == "powerup_minigun")
		{

			this.railgun_flag=0;
			this.minigun_flag=1;
			this.minigun_count++;
			if (this.minigun_count>2)
			{
				this.minigun_count=2;
			}
			gameController.damage=80;
		}
		if (other.tag == "power_up_plasma")
		{
			this.rapid_count=0;
			this.railgun_flag=0;
			this.minigun_count=0;
			this.laser_flag=0;
			this.minigun_flag=0;
			this.selectshot = 3;
			this.megashot_flag = 0;
			gameController.beam_flag_green=0;
			gameController.beam_flag=0;
			gameController.shoot_flag = 1;
			gameController.damage=150;
		}
		if (other.tag == "Powerup_double")
		{
			this.rapid_count=0;
			this.railgun_flag=0;
			this.laser_flag=0;
			this.minigun_flag=0;
			this.minigun_count=0;
			this.selectshot = 2;
			this.megashot_flag = 0;
			gameController.beam_flag_green=0;
			gameController.beam_flag=0;
			gameController.shoot_flag = 1;
			gameController.damage=75;
			
		}
		if (other.tag == "power_up_tripple")
		{
			this.rapid_count=0;
			this.railgun_flag=0;
			this.laser_flag=0;
			this.minigun_flag=0;
			this.minigun_count=0;
			this.selectshot = 4;
			this.megashot_flag = 0;
			gameController.beam_flag_green=0;
			gameController.beam_flag=0;
			gameController.shoot_flag = 1;
			gameController.damage=90;
			
		}
		if (other.tag == "power_up_quad")
		{
			this.rapid_count=0;
			this.railgun_flag=0;
			this.laser_flag=0;
			this.minigun_flag=0;
			this.minigun_count=0;
			this.selectshot = 8;
			this.megashot_flag = 0;
			gameController.beam_flag_green=0;
			gameController.beam_flag=0;
			gameController.shoot_flag = 1;
			gameController.damage=100;
			
		}
		if (other.tag == "power_up_rapid")
		{
			this.megashot_flag = 0;
			this.railgun_flag=0;
			this.selectshot = 9;
			this.laser_flag=0;
			this.minigun_flag=0;
			this.minigun_count=0;
			this.rapid_count++;
			if (this.rapid_count>2)
			{
				this.rapid_count=1;
			}
			gameController.beam_flag_green=0;
			gameController.beam_flag=0;
			gameController.shoot_flag = 1;
			gameController.damage=85;
		}
		
		if (other.tag == "Powerup1")
		{
			this.rapid_count=0;
			this.megashot_flag = 0;
			this.railgun_flag=0;
			this.laser_flag=0;
			this.minigun_flag=0;
			this.minigun_count=0;
			this.selectshot = 1;
			gameController.beam_flag_green=0;
			gameController.beam_flag=0;
			gameController.shoot_flag = 1;
			gameController.damage=60;
			
		}
		if (other.tag == "Powerup2")
		{
			//gameController.life+=10;
			gameController.add_health();
			if (gameController.life>100){gameController.life=100;}
			gameController.lifeText.text = "Life : "+gameController.life;
		}
		
		if (other.tag == "beam_laser")
		{
			gameController.player_shot_beam();
		}
		if (other.tag == "beam_laser1")
		{
			gameController.player_shot_beam_small();
		}
		if (other.tag == "beam_gun")
		{
			this.rapid_count=0;
			this.minigun_flag=0;
			this.minigun_count=0;
			this.railgun_flag=0;
			gameController.shoot_flag = 0;
			gameController.beam_flag=1;
			gameController.beam_flag_green=0;

			if (gameController.shoot_rocket_flag==1 || gameController.shoot_rocket_flag_double==1 || gameController.shoot_rocket_flag_sting==1)
			{
				gameController.shoot_rocket_flag=0;
				gameController.shoot_rocket_flag_double=0;
				gameController.shoot_rocket_flag_sting=0;
			}

		}
		
	}
	private IEnumerator init_meteors()
	{
		yield return new WaitForSeconds(5.0f);
		gameController.spawn_meteors_flag = 1;
	}

	private IEnumerator stings_depleted()
	{
		yield return new WaitForSeconds(35.0f);
		gameController.shoot_rocket_flag_sting = 0;
	}

	private IEnumerator shoot_rail()
	{
		
		
		yield return new WaitForSeconds(0.5f);
		//if (Input.GetButton ("Fire1") && Time.time > nextFire_rail && this.dist <14) {
		if (Input.touchCount > 0 && Time.time > nextFire_rail && dist <14) {
			nextFire_rail = Time.time + fireRate_rail;
			if (railshots [poolIndex_rail]) {
				
				railshots [poolIndex_rail].SetActive (true);
				railshots [poolIndex_rail].transform.position = shotSpawn_rails.transform.position;
				railshots [poolIndex_rail].transform.rotation = shotSpawn_rails.transform.rotation;
				
				
			}
			
			poolIndex_rail++;
			
			if (poolIndex_rail == 19) {
				poolIndex_rail = 0;
			}
		}
	}
	

	
}


