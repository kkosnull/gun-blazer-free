using UnityEngine;
using System.Collections;
using StartApp;


public class start_game : MonoBehaviour
{

	private bool SceneUpdateRequired;
	private bool loading;

	void Start()
	{
		StartAppWrapper.init();
		StartAppWrapper.loadAd();
		SceneUpdateRequired = true;
		loading = false;
	}

	void OnGUI() {
		StartAppWrapper.showSplash();
		if (Application.loadedLevelName == "Briefing") 
		{
			if (this.loading)
			{
				GUIStyle myBoxStyle = new GUIStyle("box");
				myBoxStyle.fontSize = 50;
				GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "LOADING...", myBoxStyle);
				
				//	GUI.Label(new Rect(10, 10, 100, 20), "LOADING...");
			}
		}


	}


	void Update () 
	{

		if (Input.GetMouseButtonDown(0))
			{
			loading=true;
			if (Application.loadedLevelName == "Start")
				{
					if(SceneUpdateRequired)
					{
						Application.LoadLevel("Briefing");
						SceneUpdateRequired = false;        
					}

				}
			else if (Application.loadedLevelName == "Briefing")
			{

					if(SceneUpdateRequired)
					{

						Application.LoadLevel("Game");
						SceneUpdateRequired = false;        
					}

			}
			else if (Application.loadedLevelName == "End")
				{
					if(SceneUpdateRequired)
					{
						Application.LoadLevel("Credits");
						SceneUpdateRequired = false;        
					}
					
				}
			else if (Application.loadedLevelName == "Credits")
			{
					if(SceneUpdateRequired)
					{
						Application.LoadLevel("Start");
						SceneUpdateRequired = false;        
					}

			}
		}
	}




}
