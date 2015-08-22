﻿/// <summary>
/// Main menu.
/// Attached to Main Camera (or so says YouTube)
/// https://www.youtube.com/watch?v=xoaYzfCix3c
/// </summary>

using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public Texture backgroudTexture;

	public float guiPlacementX1 = .25f;
	public float guiPlacementY1 = .45f;
	public float guiPlacementX2 = .25f;
	public float guiPlacementY2 = .6f;
	public float guiPlacementX3 = .25f;
	public float guiPlacementY3 = .75f;
	public string CurrentMenu = "Main";
	public GUIStyle Random1;

	void OnGUI(){

		if (CurrentMenu == "Main")
			Main_Menu();


		if (CurrentMenu == "Options")
			Options_Menu();


	
		}


	public void NavGate(string nextmenu){
		CurrentMenu = nextmenu;
	
	}


	public void Main_Menu(){
		// Displays background texture
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroudTexture);
			
			
			// Displays our Buttons (with GUI Outline)
			//button location x, button location y, buttion size x, button size y
			if(GUI.Button (new Rect (Screen.width * guiPlacementX1, Screen.height * guiPlacementY1, Screen.width * .5f, Screen.height * .1f), "Play Game")){
				print ("Clicked Play Game");
			}
			
			if(GUI.Button (new Rect (Screen.width * guiPlacementX2, Screen.height * guiPlacementY2, Screen.width * .5f, Screen.height * .1f), "Options")){
				NavGate("Options");
				print ("Clicked Options");
			}
			
			// Displays our Buttons (with GUI Outline)
			//button location x, button location y, buttion size x, button size y
			if(GUI.Button (new Rect (Screen.width * guiPlacementX1, Screen.height * guiPlacementY1, Screen.width * .5f, Screen.height * .1f), "", Random1)){
				print ("Clicked Play Game");
			}
			
			if(GUI.Button (new Rect (Screen.width * guiPlacementX2, Screen.height * guiPlacementY2, Screen.width * .5f, Screen.height * .1f),"", Random1)){
				print ("Clicked Options");
			}
		}

	public void Options_Menu(){
		// Displays background texture
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroudTexture);


	
		if(GUI.Button (new Rect (Screen.width * guiPlacementX1, Screen.height * guiPlacementY1, Screen.width * .5f, Screen.height * .1f), "Singleplayer")){
			NavGate("Main");
			//set to single player
			print ("Clicked single player, returning to main menu");
		}

		if(GUI.Button (new Rect (Screen.width * guiPlacementX2, Screen.height * guiPlacementY2, Screen.width * .5f, Screen.height * .1f), "Multiplayer")){
			NavGate("Main");
			//set to multiplayer
			print ("Clicked multiplayer, returning to main menu");
		}

		if(GUI.Button (new Rect (Screen.width * guiPlacementX3, Screen.height * guiPlacementY3, Screen.width * .5f, Screen.height * .1f), "Back")){
			NavGate("Main");
			//set to multiplayer
			print ("Clicked back, returning to main menu");
		}
	
	}
	}

