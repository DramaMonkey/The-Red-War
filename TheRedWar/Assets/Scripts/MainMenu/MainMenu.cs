﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	GameObject[] mainMenu;
	GameObject[] levelSelect;
	GameObject[] characterSelect;
	private static GameMaster instanceGameMaster;
	
	private void Start () {
		Time.timeScale = 1;
		mainMenu = GameObject.FindGameObjectsWithTag("MainMenu");
		levelSelect = GameObject.FindGameObjectsWithTag("MainMenu_LevelSelect");
		characterSelect = GameObject.FindGameObjectsWithTag("MainMenu_CharacterSelect");
		instanceGameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		goToMainMenu();
	}
	
	public void hideAllMenus(){
		foreach(GameObject g in mainMenu){
			g.SetActive(false);
		}
		
		foreach(GameObject g in levelSelect){
			g.SetActive(false);
		}
		
		foreach(GameObject g in characterSelect){
			g.SetActive(false);
		}
	}
	
	
	public void goToMainMenu(){
		hideAllMenus();
		foreach(GameObject g in mainMenu){
			g.SetActive(true);
		}
	}
	
	public void goToCharacterSelect(){
		hideAllMenus();
		foreach(GameObject g in characterSelect){
			g.SetActive(true);
		}
	}
	
	public void goToLevelSelect(){
		hideAllMenus();
		foreach(GameObject g in levelSelect){
			g.SetActive(true);
		}
	}
	
	public void selectCharacter(string characterSelected){
		print("Character : " + characterSelected);
		/*instanceGameMaster.restartSpawnPos = true;
		SceneManager.LoadScene(LevelSelected);*/
	}
	
	public void goToLevel(string LevelSelected){
		instanceGameMaster.restartSpawnPos = true;
		SceneManager.LoadScene(LevelSelected);
	}
	
	public void goToOptions(){
		print("goToOptions");
	}
	
	public void exitGame(){
		Application.Quit();
	}
	
}
