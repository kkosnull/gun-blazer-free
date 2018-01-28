using UnityEngine;
using System.Collections;


public class goto_google_play : MonoBehaviour
{


	void Update () 
	{

		if (Input.GetMouseButtonDown(0))
			{
			Application.OpenURL("http://play.google.com/store/apps/details?id=com.PixelDrive.GunBlazer");
			}
	}




}
