using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	GameObject[] mainMenu;
	
	private void Start () {
		Time.timeScale = 1;
		mainMenu = GameObject.FindGameObjectsWithTag("MainMenu");
		goToMainMenu();
	}
	
	public void goToMainMenu(){
		foreach(GameObject g in mainMenu){
			g.SetActive(true);
		}
	}
	
	public void goToLevelSelect(){
		print("goToLevelSelect");
	}
	
	public void goToLevelPlayground(){
		SceneManager.LoadScene("Prototype");
	}
	
	public void goToOptions(){
		print("goToOptions");
	}
	
	public void exitGame(){
		Application.Quit();
	}
	
}
