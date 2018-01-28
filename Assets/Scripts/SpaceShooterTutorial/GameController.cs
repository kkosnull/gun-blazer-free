using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using StartApp;
[RequireComponent(typeof(AudioSource))]

public class GameController : MonoBehaviour
{
	// damage made by player shot
	public int damage;
	public int damage_rocket;
	public int damage_beam1;
	public int damage_beam2;
	public string[] boltsArray = { "Bolt", "bolt_laser_rapid", "Bolt_double", "bolt_plasma" ,  "Bolt_laser",  "gatling_bolt",  "bolt_mega_shot",  "bolt_rocket"};

	private GameObject enemy_target;
	public GameObject bgrnd_scroller;
	public AudioClip main_clip;
	public AudioClip meteors_clip;
	public AudioClip torus_clip;
	public AudioClip final_boss_clip;
	public GameObject player;
	public GameObject electric_field;
	public GameObject checkpoint;
	public GameObject player_init_pools;
	public GameObject[] hazards;
	public GameObject[] power_ups;
	public GameObject health_bar;
	private ScriptableObject myscript;
	public GameObject flash_plasma_explosion;
	public GameObject flash_laser_explosion;
	public GameObject basic_explosion;
	public GameObject explosion_player;
	public GameObject explosion_rocket;
	public GameObject explosion_shock;
	public GameObject explosion_nuke;
	public GameObject explosion_player_beam;
	public GameObject explosion_player_beam_mute;
	public GameObject explosion_player_green_beam;
	public GameObject explosion_player_green_beam_mute;
	
	private int basic_explosion_index=0;
	private int explosion_player_index=0;
	private int explosion_green_player_index=0;
	private int explosion_rocket_index=0;
	private int flash_plasma_index=0;
	private int flash_laser_index=0;
	private int end_effect__explosion_index=0;
	private int end_effect__explosion_index_mute=0;
	private int end_effect__explosion_green_index=0;
	private int end_effect__explosion_green_index_mute=0;
	private int nuke_explosion_index=0;

	List<GameObject> nuke_explosions;
	List<GameObject> beam_endeffects_explosions;
	List<GameObject> beam_endeffects_explosions_mute;
	List<GameObject> beam_endeffects_explosions_green;
	List<GameObject> beam_endeffects_explosions_green_mute;
	List<GameObject> basic_explosions;
	List<GameObject> player_flash_plasma;
	List<GameObject> player_flash_laser;
	List<GameObject> player_explosions;
	List<GameObject> rocket_explosions;
	List<GameObject> powerup_shock;
	List<GameObject> goodies;
	List<GameObject> enemies;
	List<GameObject> meteors;
	List<GameObject> spheres;
	List<GameObject> droid_spheres;
	List<GameObject> green_enemies;
	List<GameObject> red_enemy;
	List<GameObject> ravens;
	List<GameObject> laserbots;
	List<GameObject> laserbots_yellow;
	List<GameObject> drone_brain;
	List<GameObject> drone_brain_group;
	List<GameObject> torus;
	List<GameObject> brain_boss;
	List<GameObject> Torus_boggiey;
	List<GameObject> Torus_booggie_ray;
	List<GameObject> brain_enemies;
	List<GameObject> electric_fields;
	List<GameObject> drone66;
	List<GameObject> drone58;
	public float fireRate_goods;
	public float delay;
	public int ammount;
	public int skill_level;
	// Game Parameters
	public Vector3 spawnValues;
	public int hazardCount;
	public float chackpoint_due_time;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public float gameOverWait;
	public int life;
	// Screen text objects
	public GUIText scoreText;
	public GUIText lifeText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText clickToStartText;
	public GUIText brainCloudStatusText;
	public GUIText enemiesKilledText;
	public GUIText asteroidsDestroyedText;
	public GUIText accuracyText;
	public GUIText shotsFiredText;
	public GUIText gamesPlayedText;
	public GUIText messages;
	public GUIText high_score_text;
	public Font highscore_font;
	public int fontsize = 10;
	// spawn va;ues
	private int rand_val;
	private int rand_val_brain;
	public int torus_flag;
	public int boss_brain_flag;
	public int arc_flag;
	private int brain_mini_boss_flag;
	private int index;
	private int spawn_enemies_flag=1;
	public int finished_brain_mini_boss=0;
	public int spawn_number = 23;
	public int spawn_flag;
	public int spawn_pup_flag;
	public int spawn_meteors_flag;
	public int shoot_flag;
	public int beam_flag;
	public int beam_flag_green;
	public int shoot_rocket_flag;
	public int shoot_rocket_flag_double;
	public int shoot_rocket_flag_sting;
	public int torus_is_dead;
	public int minion_core_boss;
	private Light[] lights;
	// States
	private enum eGameState
	{
		GAME_STATE_START_SCREEN,
		GAME_STATE_PLAYING,
		GAME_STATE_GAME_OVER,
		GAME_STATE_SCORE_SCREEN,
		GAME_STATE_WAITING_FOR_BRAINCLOUD
	}
	private eGameState m_state = eGameState.GAME_STATE_START_SCREEN;
	private enum ePlayState
	{
		PLAY_STATE_STARTUP,
		PLAY_STATE_WAVE,
		PLAY_STATE_IN_BETWEEN_WAVES
	}
	private ePlayState m_playState = ePlayState.PLAY_STATE_STARTUP;
	
	
	// our per round values
	private int m_enemiesKilledThisRound = 0;
	private int m_asteroidsDestroyedThisRound = 0;
	private int m_shotsFiredThisRound = 0;
	
	// our statistics
	/*
	private int m_statEnemiesKilled = 0;
	private int m_statAsteroidsDestroyed = 0;
	private int m_statShotsFired = 0;
	private int m_statGamesPlayed = 0;
*/
	// other game vars
	static private int m_score;
	private int highscore=0;
	private int m_hazardSpawned = 0;
	
	// calculated on the fly
	//private double m_accuracy = 0;
	
	// Timers
	private float m_startupTime;
	private float m_spawnTime;
	private float m_gameOverTime;
	private float m_scoreTime;
	private float player_spawnTime;

	//test value
	public float movementx;
	
	
	void OnGUI () {

		if (Application.loadedLevelName == "Start") {
			 StartAppWrapper.showSplash();
			GUIStyle leftTextStyle = new GUIStyle("label");
			leftTextStyle.alignment = TextAnchor.MiddleLeft;
			GUI.contentColor = Color.cyan;
			GUI.skin.font = highscore_font;
			//Debug.Log (Screen.width/2-120);
			GUI.skin.label.fontSize = (Screen.width<1280)?30:50;
			//GUI.Label (new Rect (66, 420, 300, 50), "High score : "+PlayerPrefs.GetInt ("highscore", highscore));
			GUI.Label (new Rect (Screen.width/2-120, Screen.height/2, 500, 500), "High score : "+PlayerPrefs.GetInt ("highscore", highscore));

			//GUI.Label (new Rect (10, Screen.height/2, 500, 500), "High score : "+PlayerPrefs.GetInt ("highscore", highscore));
			
			
		}
		else if (Application.loadedLevelName == "Game" )
		{
			 StartAppWrapper.removeBanner();
			GUI.contentColor = Color.cyan;
			GUI.skin.font = highscore_font;
			GUI.skin.label.fontSize = (Screen.width<1280)?30:50;
			GUI.Label (new Rect (10, 0, 1000, 400), "Score : "+m_score+" / "+highscore);
			//GUI.Label (new Rect (Screen.width/2-120, Screen.height/2, 500, 500), "movex "+movementx);


		}


	}
	
	
	void Awake() {
		play_music (1);
		this.minion_core_boss = 0;
		this.torus_flag = 0;
		this.boss_brain_flag=1;
		torus_is_dead = 0;
		
		if (Screen.width>1280 )
		{
			//Screen.SetResolution(1280, 720, true);
			Screen.SetResolution(1024, 600, true);
		}
		this.damage_beam1=40;
		this.damage_beam2=80;
		this.shoot_flag = 1;
		this.damage = 60;
		this.damage_rocket = 400;
		this.spawn_meteors_flag = 0;
		this.spawn_flag = 1;
		this.spawn_pup_flag = 1;
		//Application.targetFrameRate = 600;
		if (Application.loadedLevelName == "Game" )
		{
			m_score=0;
			messages.gameObject.SetActive(false);
			
			GameObject rocket_button = GameObject.FindGameObjectWithTag ("rocket_trigger");
			rocket_button.GetComponent<MeshRenderer>().enabled = false;
			//Destroy (rocket_button);
		}
	}
	void Start(){
	 StartAppWrapper.init();
	 StartAppWrapper.loadAd();
		//this.beam_flag = 1;
		highscore = PlayerPrefs.GetInt ("highscore", highscore);

		
		
		if (Application.loadedLevelName == "Game" )
		{
			
			
			
			GameObject.Find("Player").transform.position=new Vector3(0,0,0);
			electric_fields = new List<GameObject> ();
			for (int i=0; i<3; i++){
				
				GameObject obj=(GameObject)Instantiate(electric_field, new Vector3(0, 0, 16), Quaternion.identity);
				
				obj.SetActive(false);
				electric_fields.Add(obj);
			}
			
			nuke_explosions = new List<GameObject> ();
			for (int i=0; i<=20; i++) {
				GameObject obj_explosions_nukes = (GameObject)Instantiate (explosion_nuke, new Vector3 (0, 0, 0), Quaternion.identity);
				obj_explosions_nukes.SetActive (false);
				nuke_explosions.Add (obj_explosions_nukes);
				
			}

			basic_explosions = new List<GameObject> ();
			for (int i=0; i<=80; i++) {
				GameObject obj_explosions = (GameObject)Instantiate (basic_explosion, new Vector3 (0, 0, 0), Quaternion.identity);
				obj_explosions.SetActive (false);
				basic_explosions.Add (obj_explosions);
				
			}


			beam_endeffects_explosions = new List<GameObject> ();
			for (int i=0; i<=80; i++) {
				GameObject obj_endeffect = (GameObject)Instantiate (explosion_player_beam, new Vector3 (0, 0, 0), Quaternion.identity);
				obj_endeffect.SetActive (false);
				beam_endeffects_explosions.Add (obj_endeffect);
			}

			beam_endeffects_explosions_green = new List<GameObject> ();
			for (int i=0; i<=80; i++) {
				GameObject obj_endeffect_green = (GameObject)Instantiate (explosion_player_green_beam, new Vector3 (0, 0, 0), Quaternion.identity);
				obj_endeffect_green.SetActive (false);
				beam_endeffects_explosions_green.Add (obj_endeffect_green);
			}
			

			beam_endeffects_explosions_mute = new List<GameObject> ();
			for (int i=0; i<=80; i++) {
				GameObject obj_endeffect_mute = (GameObject)Instantiate (explosion_player_beam_mute, new Vector3 (0, 0, 0), Quaternion.identity);
				obj_endeffect_mute.SetActive (false);
				beam_endeffects_explosions_mute.Add (obj_endeffect_mute);
			}

			beam_endeffects_explosions_green_mute = new List<GameObject> ();
			for (int i=0; i<=80; i++) {
				GameObject obj_endeffect_green_mute = (GameObject)Instantiate (explosion_player_green_beam_mute, new Vector3 (0, 0, 0), Quaternion.identity);
				obj_endeffect_green_mute.SetActive (false);
				beam_endeffects_explosions_green_mute.Add (obj_endeffect_green_mute);
			}

			player_flash_plasma = new List<GameObject> ();
			for (int i=0; i<=40; i++) {
				GameObject obj_explosions_plasma_flash = (GameObject)Instantiate (flash_plasma_explosion, new Vector3 (0, 0, 0), Quaternion.identity);
				obj_explosions_plasma_flash.SetActive (false);
				player_flash_plasma.Add (obj_explosions_plasma_flash);
				
			}
			player_flash_laser = new List<GameObject> ();
			for (int i=0; i<=40; i++) {
				GameObject obj_explosions_laser_flash = (GameObject)Instantiate (flash_laser_explosion, new Vector3 (0, 0, 0), Quaternion.identity);
				obj_explosions_laser_flash.SetActive (false);
				player_flash_laser.Add (obj_explosions_laser_flash);
				
			}
			player_explosions = new List<GameObject> ();
			for (int i=0; i<=40; i++) {
				GameObject obj_explosions_player = (GameObject)Instantiate (explosion_player, new Vector3 (0, 0, 0), Quaternion.identity);
				obj_explosions_player.SetActive (false);
				player_explosions.Add (obj_explosions_player);
				
			}
			rocket_explosions = new List<GameObject> ();
			for (int i=0; i<=80; i++) {
				GameObject obj_explosions_rocket = (GameObject)Instantiate (explosion_rocket, new Vector3 (0, 0, 0), Quaternion.identity);
				obj_explosions_rocket.SetActive (false);
				rocket_explosions.Add (obj_explosions_rocket);
				
			}	
			
			powerup_shock = new List<GameObject> ();
			GameObject obj_shock = (GameObject)Instantiate (explosion_shock, new Vector3 (-60, 0,-60), Quaternion.identity);
			obj_shock.SetActive (false);
			powerup_shock.Add (obj_shock);
			
			
			
			
			meteors = new List<GameObject> ();
			for (int i=15; i<=22; i++) {
				GameObject obj_meteors = (GameObject)Instantiate (hazards [i], new Vector3 (UnityEngine.Random.Range (-6, 6), 0, 16), Quaternion.identity);
				
				obj_meteors.SetActive (false);
				meteors.Add (obj_meteors);
				
			}
			
			drone58 = new List<GameObject> ();
			for (int i=0; i<=1; i++){
				
				GameObject obj=(GameObject)Instantiate (hazards[10], new Vector3(-10, 0, 14), Quaternion.identity);
				obj.SetActive(false);
				drone58.Add(obj);
			}
			
			drone66 = new List<GameObject> ();
			for (int i=0; i<=10; i++){
				
				GameObject obj=(GameObject)Instantiate (hazards[11], new Vector3(-10, 0, 14), Quaternion.identity);
				obj.SetActive(false);
				drone66.Add(obj);
			}
			
			drone_brain = new List<GameObject> ();
			for (int i=0; i<=11; i++){
				
				GameObject obj=(GameObject)Instantiate(hazards[12], new Vector3(-10, 0, 13), Quaternion.identity);
				obj.SetActive(false);
				drone_brain.Add(obj);
			}
			
			drone_brain_group = new List<GameObject> ();
			for (int i=0; i<4; i++){
				
				GameObject obj=(GameObject)Instantiate(hazards[24], new Vector3(UnityEngine.Random.Range(-6, 6), 0, 20), Quaternion.identity);
				obj.SetActive(false);
				drone_brain_group.Add(obj);
			}


			Torus_booggie_ray = new List<GameObject> ();
			for (int i=0; i<2; i++){
				
				GameObject obj=(GameObject)Instantiate(hazards[9], new Vector3(UnityEngine.Random.Range(-3, 3), 0, 20), Quaternion.identity);
				obj.SetActive(false);
				Torus_booggie_ray.Add(obj);
			}
			
			Torus_boggiey = new List<GameObject> ();
			for (int i=0; i<5; i++){
				
				GameObject obj=(GameObject)Instantiate(hazards[9], new Vector3(UnityEngine.Random.Range(-3, 3), 0, 20), Quaternion.identity);
				obj.SetActive(false);
				Torus_boggiey.Add(obj);
			}
			
			torus = new List<GameObject> ();
			for (int i=0; i<1; i++){
				
				GameObject obj=(GameObject)Instantiate(hazards[14], new Vector3(UnityEngine.Random.Range(-3, 3), 0, 20), Quaternion.identity);
				
				obj.SetActive(false);
				torus.Add(obj);
			}
			
			brain_boss = new List<GameObject> ();
			for (int i=0; i<1; i++){
				
				GameObject obj=(GameObject)Instantiate(hazards[23], new Vector3(UnityEngine.Random.Range(-3, 3), 0, 20), Quaternion.identity);
				
				obj.SetActive(false);
				brain_boss.Add(obj);
			}
			
			
			ravens = new List<GameObject> ();
			for (int i=0; i<10; i++){
				
				GameObject obj=(GameObject)Instantiate(hazards[1], new Vector3(UnityEngine.Random.Range(-3, 3), 0, 16), Quaternion.identity);
				
				obj.SetActive(false);
				ravens.Add(obj);
			}

			laserbots_yellow = new List<GameObject> ();
			for (int i=0; i<10; i++){

				GameObject obj=(GameObject)Instantiate(hazards[8], new Vector3(UnityEngine.Random.Range(-6, 6), 0, 16), Quaternion.identity);

				obj.SetActive(false);
				laserbots_yellow.Add(obj);
			}

			laserbots = new List<GameObject> ();
			for (int i=0; i<10; i++){
				
				GameObject obj=(GameObject)Instantiate(hazards[25], new Vector3(UnityEngine.Random.Range(-6, 6), 0, 16), Quaternion.identity);
				
				obj.SetActive(false);
				laserbots.Add(obj);
			}
			
			red_enemy = new List<GameObject> ();
			for (int i=0; i<10; i++){
				
				GameObject obj=(GameObject)Instantiate(hazards[3], new Vector3(UnityEngine.Random.Range(-3, 3), 0, 16), Quaternion.identity);
				GameObject obj1=(GameObject)Instantiate(hazards[5], new Vector3(UnityEngine.Random.Range(-3, 3), 0, 16), Quaternion.identity);
				
				obj.SetActive(false);
				obj1.SetActive(false);
				if (i%2==0)
				{
					red_enemy.Add(obj1);
				}
				else 
				{
					red_enemy.Add(obj);
				}
				
			}
			
			green_enemies = new List<GameObject> ();
			for (int i=0; i<6; i++){
				
				GameObject obj=(GameObject)Instantiate(hazards[7], new Vector3(UnityEngine.Random.Range(-3, 3), 0, 16), Quaternion.identity);
				
				obj.SetActive(false);
				green_enemies.Add(obj);
			}
			
			brain_enemies = new List<GameObject> ();
			for (int i=0; i<3; i++){
				
				GameObject obj=(GameObject)Instantiate(hazards[13], new Vector3(UnityEngine.Random.Range(-3, 3), 0, 16), Quaternion.identity);
				
				obj.SetActive(false);
				brain_enemies.Add(obj);
			}
			
			spheres = new List<GameObject> ();
			for (int i=0; i<8; i++){
				
				GameObject obj=(GameObject)Instantiate(hazards[0], new Vector3(UnityEngine.Random.Range(-3, 3), 0, 18), Quaternion.identity);
				
				obj.SetActive(false);
				spheres.Add(obj);
			}
			
			
			droid_spheres = new List<GameObject> ();
			for (int i=0; i<8; i++){
				
				GameObject obj=(GameObject)Instantiate(hazards[2], new Vector3(-10, 0, 15), Quaternion.identity);
				
				obj.SetActive(false);
				droid_spheres.Add(obj);
			}
			
			
			enemies= new List<GameObject> ();
			for (int i=0; i<=13; i++){
				
				GameObject obj_enemy=(GameObject)Instantiate(hazards[i], new Vector3(UnityEngine.Random.Range(-3, 3), 0, 16), Quaternion.identity);
				
				obj_enemy.SetActive(false);
				enemies.Add(obj_enemy);
			}
			
			
			goodies = new List<GameObject> ();
			
			if (Application.loadedLevelName == "Game") {
				
				for (int i=0; i<17; i++){
					
					GameObject obj=(GameObject)Instantiate(power_ups[i]);
					obj.SetActive(false);
					goodies.Add(obj);
				}
				//ammount = 9;
			}
			
		}

		if (Application.loadedLevelName == "Credits" || Application.loadedLevelName == "End" || Application.loadedLevelName == "Briefing") {
		 StartAppWrapper.addBanner( 
		 StartAppWrapper.BannerType.THREED,
		 StartAppWrapper.BannerPosition.BOTTOM);
		}

		
		
		
		if (Application.loadedLevelName != "Start" && Application.loadedLevelName != "Credits" && Application.loadedLevelName != "End" && Application.loadedLevelName != "Briefing") {
			InvokeRepeating ("Fire_up_pup", delay, fireRate_goods);
		
		}
	}
	// power_up control
	void Fire_up_pup ()
	{
		if (this.spawn_pup_flag==1){
			this.index = UnityEngine.Random.Range (0, 17);
			Debug.Log("PUP IDNEX :"+this.index);
			if (this.shoot_rocket_flag==1 || this.shoot_rocket_flag_double == 1 || this.shoot_rocket_flag_sting == 1)
			{
				index=12;
			}

			if (this.beam_flag==1 || this.beam_flag_green==1)
			{
				if (index==9 || index==10 || index==15 || index==6 || index==16)
				{
					index=12;
				}
			}

			if (!goodies[index].activeInHierarchy)
			{
				goodies[index].transform.position=new Vector3(UnityEngine.Random.Range (-4, 4), 0, 20);
				goodies[index].transform.rotation=transform.rotation;
				goodies[index].SetActive(true);
				StartCoroutine(disable_powerup(index));
			}
			if (this.index>10)
			{
				goodies[0].transform.position=new Vector3(UnityEngine.Random.Range (-4, 4), 0, 22);
				goodies[0].transform.rotation=transform.rotation;
				goodies[0].SetActive(true);
				StartCoroutine(disable_powerup(0));
			}
		}	
		
		
		
	}
	
	void FixedUpdate ()
	{
		
		switch (m_state)
		{
		case eGameState.GAME_STATE_START_SCREEN:
			
			StartRound();
			
			break;
		case eGameState.GAME_STATE_PLAYING:
			
			if (Application.loadedLevelName == "Start" ) {
				
				messages.gameObject.SetActive (true);
				scoreText.gameObject.SetActive (false);
				
			}
			switch (m_playState)
			{
			case ePlayState.PLAY_STATE_STARTUP:
			case ePlayState.PLAY_STATE_IN_BETWEEN_WAVES:
				m_startupTime -= Time.deltaTime;
				if (m_startupTime <= 0)
				{
					StartWave();
				}
				break;
			case ePlayState.PLAY_STATE_WAVE:
				
				m_spawnTime -= Time.deltaTime;
				if (m_spawnTime <= 0)
				{
					if (m_hazardSpawned >= hazardCount)
					{
						
						m_playState = ePlayState.PLAY_STATE_IN_BETWEEN_WAVES;
						hazardCount+=3;
						m_startupTime = waveWait;
					}
					else
					{
						m_hazardSpawned++;
						m_spawnTime = spawnWait;
						SpawnHazard();
					}
				}
				break;
			}
			break;
		case eGameState.GAME_STATE_GAME_OVER:
			m_gameOverTime -= Time.deltaTime;
			if (m_gameOverTime <= 0)
			{
				m_state = eGameState.GAME_STATE_SCORE_SCREEN;
				scoreText.gameObject.SetActive(true);
				gameOverText.gameObject.SetActive(false);
				
				
				Caching.CleanCache ();
				Application.LoadLevel(0);
				
				
			}
			break;
			
		case eGameState.GAME_STATE_SCORE_SCREEN:
			if (Application.loadedLevelName == "Game") {
				this.life = 100;
				
				
			}
			else 
			{
				StartRound();
			}
			
			
			break;
		}
	}
	
	void StartRound()
	{
		
		if (Application.loadedLevelName != "End" && Application.loadedLevelName != "Credits" && Application.loadedLevelName != "Briefing" && Application.loadedLevelName != "tests") {
			enemiesKilledText.gameObject.SetActive (false);
			asteroidsDestroyedText.gameObject.SetActive (false);
			shotsFiredText.gameObject.SetActive (false);
			accuracyText.gameObject.SetActive (false);
			gamesPlayedText.gameObject.SetActive (false);
			clickToStartText.gameObject.SetActive (false);
			brainCloudStatusText.gameObject.SetActive (false);
			scoreText.gameObject.SetActive (true);
			lifeText.gameObject.SetActive (false);
			
			lifeText.text = "Life : " + this.life;
			m_enemiesKilledThisRound = 0;
			m_asteroidsDestroyedThisRound = 0;
			m_shotsFiredThisRound = 0;
			//UpdateScoreText ();
			m_state = eGameState.GAME_STATE_PLAYING;
			m_playState = ePlayState.PLAY_STATE_STARTUP;
			m_startupTime = startWait;
			
		}
	}
	
	
	void StartWave()
	{
		m_hazardSpawned = 1;
		m_spawnTime = spawnWait;
		m_playState = ePlayState.PLAY_STATE_WAVE;
		SpawnHazard();
		
	}
	
	// spawn player is obsolete 
	void SpawnPlayer()
	{
		
		GameObject.Instantiate (player, Vector3.zero, Quaternion.identity);
		
	}
	
	void Spawn_brains()
	{
		for (int i=0; i<4; i++) {	
			if (!drone_brain_group [i].activeInHierarchy) {
				//Debug.Log ("DRONE BRAIN");
				drone_brain_group [i].transform.position = new Vector3 (UnityEngine.Random.Range (-8, 8), 0, 15 + i);
				drone_brain_group [i].transform.rotation = Quaternion.identity;
				drone_brain_group [i].SetActive (true);	
				StartCoroutine (drone_brain_group [i].GetComponent<EvasiveManeuver> ().Evade ());
				drone_brain_group [i].GetComponent<WeaponController_droid_brain> ().InvokeRepeating ("Shoot", 1f, 1f);
				
				//break;
			}
		} 
		
		
	}
	
	

	
	
	
	void Spawn_brain()
	{

		int rand_val_x = UnityEngine.Random.Range (0, 20);
		int xpos;
		if (rand_val_x > 10) {
			xpos = 10;
		} else {
			xpos = -10;
		}
			for (int i=0; i<1; i++) {	
				if (!drone_brain [i].activeInHierarchy) {
					
					drone_brain [i].transform.position = new Vector3 (xpos, 0, 13);
					drone_brain [i].transform.rotation = Quaternion.identity;
					drone_brain [i].SetActive (true);	
					StartCoroutine (drone_brain [i].GetComponent<EvasiveManeuver> ().Evade ());
					
				}
			} 
	
		
	}
	
	void Spawn_torus()
	{
		
		for (int i=0; i<1; i++) {	
			if (!torus [i].activeInHierarchy) {
				torus [i].transform.position = new Vector3 (10, 0, 11);
				torus [i].transform.rotation = Quaternion.identity;
				torus [i].SetActive (true);	
				//StartCoroutine(torus [i].GetComponent<laser_beam_resize_torus>().pulse());
				//StartCoroutine(torus [i].GetComponent<EvasiveManeuver>().Evade());
				//break;
			}
		}
	}
	
	void Spawn_brain_boss()
	{
		
		for (int i=0; i<1; i++) {	
			if (!brain_boss [i].activeInHierarchy) {
				brain_boss [i].transform.position = new Vector3 (8, 0, 10);
				brain_boss [i].transform.rotation = Quaternion.identity;
				brain_boss [i].SetActive (true);	

				
			}
		}
	}
	
	
	void Spawn_drone58()
	{
		//GameObject.Instantiate (power_up, new Vector3(UnityEngine.Random.Range(-3, 3), 0, 20), Quaternion.identity);
		this.rand_val = UnityEngine.Random.Range (0, 20);
		
		
		
		if (this.rand_val > 10) {
			//GameObject.Instantiate (hazards[10], new Vector3(-10, 0, 14), Quaternion.identity);
			if (!drone58 [0].activeInHierarchy) {
				drone58 [0].transform.position = new Vector3 (-11, 0, 14);
				drone58 [0].transform.rotation = Quaternion.identity;
				drone58 [0].SetActive (true);
				StartCoroutine(drone58 [0].GetComponent<EvasiveManeuver>().Evade());
				
				drone58 [0].GetComponent<WeaponController_d58> ().InvokeRepeating ("Shoot", 4f, 2f);
				//StartCoroutine(drone58 [0].GetComponent<WeaponController_d58>().rapid());
			}
			
		} else {
			//GameObject.Instantiate (hazards[10], new Vector3(10, 0, 14), Quaternion.identity);
			if (!drone58 [0].activeInHierarchy) {
				drone58 [0].transform.position = new Vector3 (11, 0, 14);
				drone58 [0].transform.rotation = Quaternion.identity;
				drone58 [0].SetActive (true);
				StartCoroutine(drone58 [0].GetComponent<EvasiveManeuver>().Evade());
				
				drone58 [0].GetComponent<WeaponController_d58> ().InvokeRepeating ("Shoot", 4f, 2f);
				//StartCoroutine(drone58 [0].GetComponent<WeaponController_d58>().rapid());
			}
			
		}
		
	}
	
	
	void Spawn_drone66()
	{
		
		this.rand_val = UnityEngine.Random.Range (0, 20);
		
		if (Time.timeSinceLevelLoad < 600) 
		{
			if (this.rand_val > 10) {
				if (!drone66 [0].activeInHierarchy) {
					drone66 [0].transform.position = new Vector3 (-11, 0, 14);
					drone66 [0].transform.rotation = Quaternion.identity;
					drone66 [0].SetActive (true);
					StartCoroutine(drone66 [0].GetComponent<EvasiveManeuver>().Evade());
					
					drone66 [0].GetComponent<WeaponController_d66> ().InvokeRepeating ("Shoot", 2f, 2f);
					//StartCoroutine(drone66 [0].GetComponent<WeaponController_d66>().rapid66());
				}
				
			} else {
				if (!drone66 [0].activeInHierarchy) {
					drone66 [0].transform.position = new Vector3 (11, 0, 14);
					drone66 [0].transform.rotation = Quaternion.identity;
					drone66 [0].SetActive (true);
					StartCoroutine(drone66 [0].GetComponent<EvasiveManeuver>().Evade());
					
					drone66 [0].GetComponent<WeaponController_d66> ().InvokeRepeating ("Shoot", 2f, 2f);
					//StartCoroutine(drone66 [0].GetComponent<WeaponController_d66>().rapid66());
				}
			}
		} else 
		{
			for (int i=0; i<3; i++) 
			{	
				if (!drone66 [i].activeInHierarchy) 
				{
					drone66 [i].transform.position = new Vector3 (UnityEngine.Random.Range (-8, 8), 0, 15 + i);
					drone66 [i].transform.rotation = Quaternion.identity;
					drone66 [i].SetActive (true);
					StartCoroutine(drone66 [i].GetComponent<EvasiveManeuver>().Evade());
					drone66 [i].GetComponent<WeaponController_d66> ().InvokeRepeating ("Shoot", 2f, 2.5f);
					//StartCoroutine(drone66 [i].GetComponent<WeaponController_d66>().rapid66());
				}
				
			}
		}
		
		
		
	} 
	
	
	void Spawn_Torus_boggie_ray()
	{
		int rand_val_x = UnityEngine.Random.Range (0, 20);
		int xpos;
		if (rand_val_x > 10) {
			xpos = 10;
		} else {
			xpos = -10;
		}

		for (int i=0; i<1; i++) {	
			if (!Torus_booggie_ray [i].activeInHierarchy) {
				Torus_booggie_ray [i].transform.position = new Vector3 (xpos, 0, 14);
				Torus_booggie_ray [i].transform.rotation = Quaternion.identity;
				Torus_booggie_ray [i].SetActive (true);		
				StartCoroutine(Torus_booggie_ray [i].GetComponent<EvasiveManeuver>().Evade());
				
				//break;
			}
		}
		
		
	}
	void Spawn_Torus_boggiey()
	{
		for (int i=0; i<5; i++) {	
			if (!Torus_boggiey [i].activeInHierarchy) {
				Torus_boggiey [i].transform.position = new Vector3 (UnityEngine.Random.Range (-3, 3), 0, 16+i);
				Torus_boggiey [i].transform.rotation = Quaternion.identity;
				Torus_boggiey [i].SetActive (true);		

				//break;
			}
		}
		
		
	}
	
	
	void Spawn_electric_field()
	{
		
		
		if (!electric_fields [0].activeInHierarchy) {
			electric_fields [0].transform.position = new Vector3 (-0.6f, 0, 15);
			electric_fields [0].transform.rotation = Quaternion.identity;
			electric_fields [0].SetActive (true);
			
		}
		
	}
	public void stopElectric_pulse()
	{
		if (electric_fields [0].activeInHierarchy) {
			
			//StopCoroutine(electric_fields [0].GetComponentsInChildren<laser_beam_resize_trap>().pulse());
		}
	}
	
	void Spawn_meteors()
	{
		
		for (int i=0; i<=7; i++) {		
			if (!meteors [i].activeInHierarchy) {
				meteors [i].transform.position = new Vector3 (UnityEngine.Random.Range (-6, 6), 0, UnityEngine.Random.Range (15, 20));
				meteors [i].transform.rotation = Quaternion.identity;
				meteors [i].SetActive (true);
			}	
		}
		
	}
	
	
	
	
	void Spawn_red_boogey()
	{
		bool oddeven = Mathf.FloorToInt(Time.timeSinceLevelLoad) % 4 == 0;
		if (oddeven==true)
		{
			for (int i=0; i<2; i++) {	
				if (!red_enemy [i].activeInHierarchy) {
					red_enemy [i].transform.position = new Vector3 (UnityEngine.Random.Range (-8, 8), 0, 15 + i);
					red_enemy [i].transform.rotation = Quaternion.identity;
					red_enemy [i].SetActive (true);
					
					StartCoroutine (red_enemy [i].GetComponent<EvasiveManeuver> ().Evade ());
					//StartCoroutine(red_enemy [i].GetComponent<WeaponController>().FireShots());
					red_enemy [i].GetComponent<WeaponController> ().InvokeRepeating ("Shoot", 1f, 1f);
					//break;
				}
			}
		}
		else 
		{
			for (int i=0; i<4; i++) {	
				if (!red_enemy [i].activeInHierarchy) {
					red_enemy [i].transform.position = new Vector3 (UnityEngine.Random.Range (-8, 8), 0, 15 + i);
					red_enemy [i].transform.rotation = Quaternion.identity;
					red_enemy [i].SetActive (true);
					
					StartCoroutine (red_enemy [i].GetComponent<EvasiveManeuver> ().Evade ());
					//StartCoroutine(red_enemy [i].GetComponent<WeaponController>().FireShots());
					red_enemy [i].GetComponent<WeaponController> ().InvokeRepeating ("Shoot", 1f, 1f);
					//break;
				}
			}
		}
		
		
		
	}
	
	void Spawn_ravens()
	{
		for (int i=0; i<4; i++) {	
			if (!ravens [i].activeInHierarchy) {
				ravens [i].transform.position = new Vector3 (UnityEngine.Random.Range (-4, 4), 0, 15+i);
				ravens [i].transform.rotation = Quaternion.identity;
				ravens [i].SetActive (true);	
				StartCoroutine(ravens [i].GetComponent<EvasiveManeuver>().Evade());
				//StartCoroutine(ravens [i].GetComponent<WeaponController>().FireShots());
				ravens [i].GetComponent<WeaponController_raven>().InvokeRepeating ("Shoot", 1f, 1f);
				//break;
			}
		}
		
		
	}
	
	void Spawn_laserbots()
	{
		int bot_number=UnityEngine.Random.Range (1, 2);
				
		
		for (int i=0; i<=bot_number; i++) {	
			if (!laserbots [i].activeInHierarchy) {
				laserbots [i].transform.position = new Vector3 (UnityEngine.Random.Range (-4, 4), 0, 15+i);
				laserbots [i].transform.rotation = Quaternion.identity;
				laserbots [i].SetActive (true);	
				StartCoroutine(laserbots [i].GetComponent<EvasiveManeuver_laserbot>().Evade());
				
			}
		}
		
		
		
		
	}
	void Spawn_laserbots_yellow()
	{
		int bot_number=UnityEngine.Random.Range (1, 2);


		for (int i=0; i<=bot_number; i++) {	
			if (!laserbots_yellow [i].activeInHierarchy) {
				laserbots_yellow [i].transform.position = new Vector3 (UnityEngine.Random.Range (-4, 4), 0, 15+i);
				laserbots_yellow [i].transform.rotation = Quaternion.identity;
				laserbots_yellow [i].SetActive (true);	
				StartCoroutine(laserbots_yellow [i].GetComponent<EvasiveManeuver_laserbot>().Evade());

			}
		}




	}
	void Spawn_green_boogeys()
	{
		for (int i=0; i<6; i++) {	
			if (!green_enemies [i].activeInHierarchy) {
				green_enemies [i].transform.position = new Vector3 (UnityEngine.Random.Range (-3, 3), 0, 15+i);
				green_enemies [i].transform.rotation = Quaternion.identity;
				green_enemies [i].SetActive (true);	
				StartCoroutine(green_enemies [i].GetComponent<EvasiveManeuver>().Evade());
				
				//break;
			}
		}
		
		
	}
	void Spawn_brain_drones()
	{
		for (int i=0; i<3; i++) {	
			if (!brain_enemies [i].activeInHierarchy) {
				brain_enemies [i].transform.position = new Vector3 (UnityEngine.Random.Range (-3, 3), 0, 15+i);
				brain_enemies [i].transform.rotation = Quaternion.identity;
				brain_enemies [i].SetActive (true);	
				StartCoroutine(brain_enemies [i].GetComponent<EvasiveManeuver>().Evade());
				
				//break;
			}
		}
		
		
	}
	void Spawn_sphere_mine()
	{
		for (int i=0; i<8; i++) {	
			if (!spheres [i].activeInHierarchy) {
				spheres [i].transform.position = new Vector3 (UnityEngine.Random.Range (-3, 3), 0, 20+i);
				spheres [i].transform.rotation = Quaternion.identity;
				spheres [i].SetActive (true);		
				//StartCoroutine(spheres [i].GetComponent<EvasiveManeuver_spin>().Evade());
				
				//break;
			}
		}
		
		
	}
	void Spawn_enemy_droid_sphere()
	{
		for (int i=0; i<8; i++) {
			if (!droid_spheres [i].activeInHierarchy) {
				
				droid_spheres [i].transform.position = new Vector3 (UnityEngine.Random.Range (-3, 3), 0, 16+i);
				droid_spheres [i].transform.rotation = Quaternion.identity;
				droid_spheres [i].SetActive (true);	
				StartCoroutine(droid_spheres [i].GetComponent<EvasiveManeuver>().Evade());
				//break;
			}
		}
		
		
	}
	
	//test
	void SpawnHazard()
	{
		if (Application.loadedLevelName == "Game") {
			//Spawn_laserbots();
			//Spawn_enemy_droid_sphere ();
		//this.spawn_flag=0;
			//Spawn_laserbots_yellow();
			GameObject hazard = hazards [UnityEngine.Random.Range (0, 14)];
			this.brain_mini_boss_flag = UnityEngine.Random.Range (0, 10);

			//this.spawn_flag=0;
			if (Time.timeSinceLevelLoad>250 && Time.timeSinceLevelLoad<420)
			{
				this.skill_level=2;
				this.waveWait-=1;
				
			}
			if (Time.timeSinceLevelLoad>420)
			{
				this.skill_level=3;
				
			}
			
			
			if (this.torus_flag ==0 && this.torus_is_dead==0 && this.spawn_meteors_flag==0)
				//if (Time.timeSinceLevelLoad<=15)
			{

				if (hazard.name == "Enemy Ship" && this.spawn_flag == 1) {


					Spawn_brain ();
					Spawn_red_boogey ();
					
					
				} 
				else if (hazard.name == "Torus_boggiey_ray" && this.spawn_flag == 1) {

					Spawn_enemy_droid_sphere ();
					Spawn_laserbots();
					if (this.minion_core_boss==1)
					{
						Spawn_Torus_boggie_ray ();
					}

					
					
				} 
				else if (hazard.name == "enemy_droid_sphere" && this.spawn_flag == 1) {
					
					
					
					
					this.rand_val_brain = UnityEngine.Random.Range (0, 20);
					if (this.rand_val_brain > 15 && spawn_flag == 1) {
						Spawn_enemy_droid_sphere ();
						Spawn_brain ();
					}
					else if (this.rand_val_brain < 15 && spawn_flag == 1 )
					{
						
						Spawn_laserbots();
					}


					
				} 
				
				else if (hazard.name == "seeker" && this.spawn_flag == 1) {
					this.arc_flag = UnityEngine.Random.Range (0, 30);
					
					Spawn_sphere_mine ();
					Spawn_laserbots();
					
				} 
				
				else if (hazard.name == "raven" && this.spawn_flag == 1) {
					Spawn_ravens ();
					int spawn_check = UnityEngine.Random.Range (0, 8);
					if (spawn_check > 4) {
						Spawn_brain ();
					} else 
					{
						Spawn_laserbots_yellow();
					}
				} 
				else if (hazard.name == "drone66_rapid" && this.spawn_flag == 1) {
					
					
					Spawn_drone66 ();
					int spawn_check = UnityEngine.Random.Range (0, 8);
					if (spawn_check>4)
					{
						Spawn_laserbots ();
					}

					
				} 
				else if (hazard.name == "drone58_ray" && this.spawn_flag == 1) {
					
					Spawn_red_boogey ();
					Spawn_drone58 ();
					
				} 
				else if (hazard.name == "drone_brain" && this.spawn_flag == 1 && Time.timeSinceLevelLoad<300) {

					Spawn_laserbots();
					Spawn_brain ();
					
				} 
				else if (hazard.name == "Laserbot_stinger" && this.spawn_flag == 1 ) {

					Spawn_laserbots_yellow();

				} 
			
				
			} 
			else if ( this.spawn_meteors_flag ==1)
			{
				

				bgrnd_scroller.GetComponent<BGScroller>().scrollSpeed=-8;
				//play_music(2);
				if (GetComponent<AudioSource>()!=null)
				{
					AudioSource audio = GetComponent<AudioSource>();
					audio.Pause();
					audio.clip = meteors_clip;
					audio.PlayDelayed(1.0f);	


				}
				Spawn_meteors ();
				StartCoroutine(meteor_shower_end());
				
				
			}
			else if ( this.torus_flag ==1 && this.torus_is_dead==0)
			{
				
				
				bgrnd_scroller.GetComponent<BGScroller>().scrollSpeed=-0.5f;
				if (GetComponent<AudioSource>()!=null)
				{
					AudioSource audio = GetComponent<AudioSource>();
					audio.Pause();
					audio.clip = torus_clip;
					audio.PlayDelayed(1.0f);	
					
					
				}
				this.spawn_flag = 0;

				Spawn_torus ();
			//	play_music(3);

				
			}
//			else if (this.torus_flag ==0 && this.torus_is_dead==1)
//			{
//				EndGame();
//			}
					
			// if level is Game
		}
		
		
		
	}
	public void show_text (float value)
	{

		movementx = value;
			
	}

	public void AddScore (int newScoreValue)
	{
		m_score += newScoreValue;
		if (m_score >= highscore){
			highscore = m_score;
			PlayerPrefs.SetInt ("highscore", highscore);
		}

		
	}
	
	public void player_hit_mine()
	{
		GameObject healthbar = GameObject.Find("DriveBar");
		GameObject g = GameObject.Find("Main Camera");
		CameraShake shakeDuration = g.GetComponent<CameraShake>();
		shakeDuration.shakeDuration = (float)0.6;
		
		this.life -= 40;
		//this.life -= 1;
		//	lifeText.text = "Life : "+this.life;
		healthbar.GetComponent<GUIBarScript> ().Value -= 0.1f;
		//health_bar.transform.localScale -= new Vector3 (0.4f, 0, 0);
		
		if (this.life <= 0) {
			healthbar.GetComponent<GUIBarScript> ().Value = 0.0f;
			//health_bar.transform.localScale=new Vector3 (0, 0, 0);
			this.GameOver();
			
		}
		
	}
	
	public void player_shot()
	{
		GameObject healthbar = GameObject.Find("DriveBar");
		GameObject g = GameObject.Find("Main Camera");
		CameraShake shakeDuration = g.GetComponent<CameraShake>();
		shakeDuration.shakeDuration = (float)0.6;
		healthbar.GetComponent<GUIBarScript> ().Value -= 0.1f;
		this.life -= 10;
		//this.life -= 1;
		if (this.life <= 0) {
			healthbar.GetComponent<GUIBarScript> ().Value = 0.0f;
			this.GameOver();
			
		}
		
	}
	
	public void player_hit_meteor()
	{
		GameObject healthbar = GameObject.Find("DriveBar");
		GameObject g = GameObject.Find("Main Camera");
		CameraShake shakeDuration = g.GetComponent<CameraShake>();
		shakeDuration.shakeDuration = (float)0.6;
		healthbar.GetComponent<GUIBarScript> ().Value -= 0.1f;
		this.life -= 25;
		//this.life -= 1;
		if (this.life <= 0) {
			healthbar.GetComponent<GUIBarScript> ().Value = 0.0f;
			this.GameOver();
			
		}
		
	}
	
	public void player_zapped()
	{
		GameObject healthbar = GameObject.Find("DriveBar");
		GameObject g = GameObject.Find("Main Camera");
		CameraShake shakeDuration = g.GetComponent<CameraShake>();
		shakeDuration.shakeDuration = (float)0.8;
		healthbar.GetComponent<GUIBarScript> ().Value -= 0.4f;
			this.life -= 40;
		//this.life -= 1;
		if (this.life <= 0) {
			healthbar.GetComponent<GUIBarScript> ().Value = 0.0f;
			this.GameOver();
			
		}
		
	}
	
	public void player_killed()
	{
		GameObject healthbar = GameObject.Find("DriveBar");
		GameObject deadplayer = GameObject.Find("Player");
		GameObject g = GameObject.Find("Main Camera");
		CameraShake shakeDuration = g.GetComponent<CameraShake>();
		shakeDuration.shakeDuration = (float)1;
		healthbar.GetComponent<GUIBarScript> ().Value = 0.0f;
		Destroy (deadplayer);
		this.GameOver();
		

		
	}
	
	public void player_shot_beam()
	{
		GameObject healthbar = GameObject.Find("DriveBar");
		GameObject g = GameObject.Find("Main Camera");
		CameraShake shakeDuration = g.GetComponent<CameraShake>();
		shakeDuration.shakeDuration = (float)0.6;
		
		this.life -= 20;
		//this.life -= 1;
		healthbar.GetComponent<GUIBarScript> ().Value -= 0.2f;
		
		
		if (this.life <= 0) {
			healthbar.GetComponent<GUIBarScript> ().Value = 0.0f;
			this.GameOver();
			
		}
		
	}
	
	public void player_shot_beam_small()
	{
		GameObject healthbar = GameObject.Find("DriveBar");
		GameObject g = GameObject.Find("Main Camera");
		CameraShake shakeDuration = g.GetComponent<CameraShake>();
		shakeDuration.shakeDuration = (float)0.6;
		
		this.life -= 15;
		//this.life -= 1;
		healthbar.GetComponent<GUIBarScript> ().Value -= 0.1f;
		
		
		if (this.life <= 0) {
			//health_bar.transform.localScale=new Vector3 (0, 0, 0);
			healthbar.GetComponent<GUIBarScript> ().Value = 0.0f;
			this.GameOver();
			
		}
		
	}
	public void add_health()
	{
		GameObject healthbar = GameObject.Find("DriveBar");
		if (this.life < 100) {
			this.life += 10;
			//if (health_bar){health_bar.transform.localScale += new Vector3 (0.1f, 0, 0);}
			healthbar.GetComponent<GUIBarScript> ().Value += 0.1f;
			//health_bar.transform.localScale += new Vector3 (0.1f, 0, 0);
		} else if (this.life > 100) {
			this.life=100;
			//health_bar.transform.localScale += new Vector3 (1, 0, 0);
			healthbar.GetComponent<GUIBarScript> ().Value = 1;
		}
		
		
	}

	public void EndGame()
	{
		GameObject deadplayer = GameObject.Find("Player");
		explode(deadplayer.transform.position, deadplayer.transform.rotation);
		Destroy (deadplayer);
		m_state = eGameState.GAME_STATE_GAME_OVER;
		m_gameOverTime = gameOverWait;
		//Caching.CleanCache ();
		//Application.LoadLevel("End");
		StartCoroutine(finish_game());

	}
	
	public void GameOver()
	{

		GameObject deadplayer = GameObject.Find("Player");
		explode(deadplayer.transform.position, deadplayer.transform.rotation);
		Destroy (deadplayer);

		m_state = eGameState.GAME_STATE_GAME_OVER;
		m_gameOverTime = gameOverWait;
		Caching.CleanCache ();

	}
	
	public void OnEnemyKilled()
	{
		m_enemiesKilledThisRound++;
	}
	
	public void OnAsteroidDestroyed()
	{
		m_asteroidsDestroyedThisRound++;
	}
	
	public void OnShotFired()
	{
		m_shotsFiredThisRound++;
	}
	
	public IEnumerator Start_game () {
		
		
		yield return new WaitForSeconds(3.0f);
		Application.LoadLevel("Game");
		
		
	}
	
	public void explode_end_effect(Vector3 position, Quaternion rotation)
	{
		
		if (!beam_endeffects_explosions [end_effect__explosion_index].activeInHierarchy) {
			beam_endeffects_explosions [end_effect__explosion_index].transform.position = position;
			beam_endeffects_explosions [end_effect__explosion_index].transform.rotation = rotation;
			beam_endeffects_explosions [end_effect__explosion_index].SetActive (true);
			StartCoroutine(disable_explosion(7,end_effect__explosion_index));
			end_effect__explosion_index+=1;
		}	
		if (end_effect__explosion_index>=80)
		{
			end_effect__explosion_index=0;
		}
	}
	public void explode_end_effect_mute(Vector3 position, Quaternion rotation)
	{
		
		if (!beam_endeffects_explosions_mute [end_effect__explosion_index_mute].activeInHierarchy) {
			beam_endeffects_explosions_mute [end_effect__explosion_index_mute].transform.position = position;
			beam_endeffects_explosions_mute [end_effect__explosion_index_mute].transform.rotation = rotation;
			beam_endeffects_explosions_mute [end_effect__explosion_index_mute].SetActive (true);
			StartCoroutine(disable_explosion(8,end_effect__explosion_index_mute));
			end_effect__explosion_index_mute+=1;
		}	
		if (end_effect__explosion_index_mute>=80)
		{
			end_effect__explosion_index_mute=0;
		}
	}

	public void explode_end_effect_green(Vector3 position, Quaternion rotation)
	{
		
		if (!beam_endeffects_explosions_green [end_effect__explosion_green_index].activeInHierarchy) {
			beam_endeffects_explosions_green [end_effect__explosion_green_index].transform.position = position;
			beam_endeffects_explosions_green [end_effect__explosion_green_index].transform.rotation = rotation;
			beam_endeffects_explosions_green [end_effect__explosion_green_index].SetActive (true);
			StartCoroutine(disable_explosion(10,end_effect__explosion_green_index));
			end_effect__explosion_green_index+=1;
		}	
		if (end_effect__explosion_green_index>=80)
		{
			end_effect__explosion_green_index=0;
		}
	}
	public void explode_end_effect_mute_green(Vector3 position, Quaternion rotation)
	{
		
		if (!beam_endeffects_explosions_green_mute [end_effect__explosion_green_index_mute].activeInHierarchy) {
			beam_endeffects_explosions_green_mute [end_effect__explosion_green_index_mute].transform.position = position;
			beam_endeffects_explosions_green_mute [end_effect__explosion_green_index_mute].transform.rotation = rotation;
			beam_endeffects_explosions_green_mute [end_effect__explosion_green_index_mute].SetActive (true);
			StartCoroutine(disable_explosion(11,end_effect__explosion_green_index_mute));
			end_effect__explosion_green_index_mute+=1;
		}	
		if (end_effect__explosion_green_index_mute>=80)
		{
			end_effect__explosion_green_index_mute=0;
		}
	}

	public void explode(Vector3 position, Quaternion rotation)
	{
		
		if (!basic_explosions [basic_explosion_index].activeInHierarchy) {
			basic_explosions [basic_explosion_index].transform.position = position;
			basic_explosions [basic_explosion_index].transform.rotation = rotation;
			basic_explosions [basic_explosion_index].SetActive (true);
			StartCoroutine(disable_explosion(1,basic_explosion_index));
			basic_explosion_index+=1;
		}	
		if (basic_explosion_index>80)
		{
			basic_explosion_index=0;
		}
	}
	
	public void flash_plasma(Vector3 position, Quaternion rotation)
	{
		
		if (!player_flash_plasma [flash_plasma_index].activeInHierarchy) {
			player_flash_plasma [flash_plasma_index].transform.position = position;
			player_flash_plasma [flash_plasma_index].transform.rotation = rotation;
			player_flash_plasma [flash_plasma_index].SetActive (true);
			StartCoroutine(disable_explosion(4,flash_plasma_index));
			flash_plasma_index+=1;
		}	
		if (flash_plasma_index>40)
		{
			flash_plasma_index=0;
		}
	}
	public void flash_laser(Vector3 position, Quaternion rotation)
	{
		
		if (!player_flash_laser [flash_laser_index].activeInHierarchy) {
			player_flash_laser [flash_laser_index].transform.position = position;
			player_flash_laser [flash_laser_index].transform.rotation = rotation;
			player_flash_laser [flash_laser_index].SetActive (true);
			StartCoroutine(disable_explosion(5,flash_laser_index));
			flash_laser_index+=1;
		}	
		if (flash_laser_index>40)
		{
			flash_laser_index=0;
		}
	}
	public void explode_player(Vector3 position, Quaternion rotation)
	{
		
		if (!player_explosions [explosion_player_index].activeInHierarchy) {
			player_explosions [explosion_player_index].transform.position = position;
			player_explosions [explosion_player_index].transform.rotation = rotation;
			player_explosions [explosion_player_index].SetActive (true);
			StartCoroutine(disable_explosion(2, explosion_player_index));
			explosion_player_index+=1;
		}	
		if (explosion_player_index>40)
		{
			explosion_player_index=0;
		}
	}
	public void shock(Vector3 position, Quaternion rotation)
	{
		
		if (!powerup_shock [0].activeInHierarchy) {
			powerup_shock [0].transform.position = position;
			powerup_shock [0].transform.rotation = rotation;
			powerup_shock [0].SetActive (true);
			StartCoroutine(disable_explosion(6,0));
			
		}	
	}
	public void explode_rocket(Vector3 position, Quaternion rotation)
	{
		
		if (!rocket_explosions [explosion_rocket_index].activeInHierarchy) {
			rocket_explosions [explosion_rocket_index].transform.position = position;
			rocket_explosions [explosion_rocket_index].transform.rotation = rotation;
			rocket_explosions [explosion_rocket_index].SetActive (true);
			StartCoroutine(disable_explosion(3,explosion_rocket_index));
			explosion_rocket_index+=1;
		}	
		if (explosion_rocket_index>80)
		{
			explosion_rocket_index=0;
		}
	}
	
	public IEnumerator disable_explosion (int selector, int index) {
		
		
		yield return new WaitForSeconds(1.5f);
		if (selector==1)
		{
			basic_explosions [index].SetActive (false);
		}
		else if (selector==2)
		{
			player_explosions [index].SetActive (false);
		}
		else if (selector==3)
		{
			rocket_explosions [index].SetActive (false);
		}
		else if (selector==4)
		{
			player_flash_plasma [index].SetActive (false);
		}
		else if (selector==5)
		{
			player_flash_laser [index].SetActive (false);
		}
		else if (selector==6)
		{
			powerup_shock [0].SetActive (false);
		}
		else if (selector==7)
		{
			beam_endeffects_explosions [index].SetActive (false);
		}
		else if (selector==8)
		{
			beam_endeffects_explosions_mute [index].SetActive (false);
		}
		else if (selector==9)
		{
			nuke_explosions [index].SetActive (false);
		}
		else if (selector==10)
		{
			beam_endeffects_explosions_green [index].SetActive (false);
		}
		else if (selector==11)
		{
			beam_endeffects_explosions_green_mute [index].SetActive (false);
		}
	}
	
	public void restore_light()
	{
		lights = FindObjectsOfType(typeof(Light)) as Light[];
		foreach(Light light in lights)
		{
			if (light.name=="Main Light")
			{
				light.color = Color.Lerp(Color.red, Color.white, Mathf.PingPong(Time.time, 20));
				
			}
		}
	}
	public void play_music(int selector)
	{
		if (GetComponent<AudioSource>()!=null)
		{
			AudioSource audio = GetComponent<AudioSource>();
			//audio.Stop();
			if (selector==1)
			{
				audio.clip = main_clip;
				audio.Play();
				//audio.Play(44100);
			}
			else if (selector==2)
			{
				audio.clip = meteors_clip;
				audio.Play();
				//audio.Play(44100);
			}
			else if (selector==3)
			{
				audio.clip = torus_clip;
				audio.Play();
			//	audio.Play(44100);
			}


		}
		
		
		
	}

	private IEnumerator disable_powerup(int index)
	{
		yield return new WaitForSeconds(10.0f);
		this.goodies [index].SetActive(false);
	}

	public IEnumerator finish_game () {
		
		
		yield return new WaitForSeconds(4.0f);
		Application.LoadLevel("Credits");
		
		
		
		
	}


	public IEnumerator meteor_shower_end () {
		
	
			yield return new WaitForSeconds(90.0f);
			bgrnd_scroller.GetComponent<BGScroller>().scrollSpeed=-0.5f;
			this.spawn_flag = 0;
			this.spawn_pup_flag = 1;
			this.torus_flag = 1;
			this.spawn_meteors_flag = 0;

	}

}